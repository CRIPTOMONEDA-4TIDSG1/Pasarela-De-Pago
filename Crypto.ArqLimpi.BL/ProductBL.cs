using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.BL.Interfaces;
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;


namespace Crypto.ArqLimpia.BL
{
    public class ProductBL : IProductBL
    {
        readonly IProduct _productDAL;
        readonly IUnitOfWork _unitWork;

        public ProductBL( IProduct productDAL, IUnitOfWork unitOfWork)
        {
            _productDAL = productDAL;
            _unitWork = unitOfWork;
        }

        public async Task<CreateProductOutputDTOs> Create(CreateProductInputDTOs pProducts)
        {
            ProductEN newProduct = new ProductEN()
            {
                ProductName = pProducts.ProductName,
                DescriptionsProduct = pProducts.DescriptionsProduct,
                Tipe = pProducts.Type,
                Amount = pProducts.Amount,
            };
            ProductEN existingProduct = await _productDAL.GetById(newProduct);

            // Verificar si ya existe un producto con el mismo nombre (NO FUNCIONA)
            if (existingProduct != null)
            {
                throw new ArgumentException("Ya existe un producto con este nombre.");
            }
            _productDAL.Create(newProduct);
            await _unitWork.SaveChangesAsync();
            CreateProductOutputDTOs productsOutput = new CreateProductOutputDTOs()
            {
                Id = newProduct.Id,
                ProductName = newProduct.ProductName,
                DescriptionsProduct = newProduct.DescriptionsProduct,
                Type = newProduct.Tipe,
                Amount = newProduct.Amount,

            };
            return productsOutput;
        }

        public async Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProducts)
        {
            ProductEN productToDelete = await _productDAL.GetById(new ProductEN { Id = pProducts.Id });

            if (productToDelete != null)
            {
                _productDAL.Delete(productToDelete);
                await _unitWork.SaveChangesAsync();
            }

            return new DeleteProductsOutputDTOs { IsDeleted = true };
        }

        public async Task<GetByIdProductOutputDTO> GetById(int id)
        {
            ProductEN product = await _productDAL.GetById(new ProductEN { Id = id });
            return new GetByIdProductOutputDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                DescriptionsProduct = product.DescriptionsProduct
            };
        }

        public async Task<List<getProductsOutputDTOs>> Search(getProductsInputDTOs pProducts)
        {
            List<ProductEN> products = await _productDAL.Search(pProducts);

            List<getProductsOutputDTOs> list = new List<getProductsOutputDTOs>();
            products.ForEach(p => list.Add(new getProductsOutputDTOs
            {
                Id = p.Id,
                ProductName = p.ProductName,
                DescriptionsProduct = p.DescriptionsProduct,
                Type = p.Tipe,
                Amount = p.Amount
            }));
            return list;

        }

        public async Task<UpdateProductOutputDTOs> Update(UpdateProductInputDTOs pProducts)
        {
            ProductEN productUpdate = await _productDAL.GetById(pProducts.Id);

            if (productUpdate.Id == pProducts.Id)
            {
                productUpdate.ProductName = pProducts.ProductName;
                productUpdate.DescriptionsProduct = pProducts.DescriptionsProduct;
                productUpdate.Tipe = pProducts.Type;
                productUpdate.Amount = pProducts.Amount;

                _productDAL.Update(productUpdate);

                await _unitWork.SaveChangesAsync();

                UpdateProductOutputDTOs product = new UpdateProductOutputDTOs()
                {
                    Id = productUpdate.Id,
                    ProductName = productUpdate.ProductName,
                    DescriptionsProduct = productUpdate.DescriptionsProduct,
                    Type = productUpdate.Tipe,
                    Amount = productUpdate.Amount
                };
                return product;
            }

            throw new Exception($"The product with id: {pProducts.Id} not found");

        }
    }
  }
