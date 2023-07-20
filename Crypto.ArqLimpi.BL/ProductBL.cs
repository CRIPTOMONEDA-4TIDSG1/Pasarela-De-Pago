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
                CryptoName = pProducts.ProductName,
                DescriptionCrypto = pProducts.ProductDescription,
                price = pProducts.price,
                Amount = pProducts.Amount,
            };
            
            _productDAL.Create(newProduct);
            await _unitWork.SaveChangesAsync();
            CreateProductOutputDTOs productsOutput = new CreateProductOutputDTOs()
            {
                Id = newProduct.Id,
                ProductName = newProduct.CryptoName,
                ProductDescription = newProduct.DescriptionCrypto,
                price = newProduct.price,
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
                ProductName = product.CryptoName,
                ProductDescription = product.DescriptionCrypto
            };
        }

        public async Task<List<getProductsOutputDTOs>> Search(getProductsInputDTOs pProducts)
        {
            List<ProductEN> products = await _productDAL.Search(pProducts);

            List<getProductsOutputDTOs> list = new List<getProductsOutputDTOs>();
            products.ForEach(p => list.Add(new getProductsOutputDTOs
            {
                Id = p.Id,
                ProductName = p.CryptoName,
                ProductDescription = p.DescriptionCrypto,
                price = p.price,
                Amount = p.Amount
            }));
            return list;

        }

        public async Task<UpdateProductOutputDTOs> Update(UpdateProductInputDTOs pProducts)
        {
            ProductEN productUpdate = await _productDAL.GetById(pProducts.Id);

            if (productUpdate.Id == pProducts.Id)
            {
                productUpdate.CryptoName = pProducts.ProductName;
                productUpdate.DescriptionCrypto = pProducts.ProductDescription;
                productUpdate.price = pProducts.price;
                productUpdate.Amount = pProducts.Amount;

                _productDAL.Update(productUpdate);

                await _unitWork.SaveChangesAsync();

                UpdateProductOutputDTOs product = new UpdateProductOutputDTOs()
                {
                    Id = productUpdate.Id,
                    ProductName = productUpdate.CryptoName,
                    ProductDescription = productUpdate.DescriptionCrypto,
                    price = productUpdate.price,
                    Amount = productUpdate.Amount
                };
                return product;
            }

            throw new Exception($"The product with id: {pProducts.Id} not found");

        }
    }
  }
