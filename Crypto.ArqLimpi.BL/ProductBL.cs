using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.BL.Interfaces;
using Crypto.ArqLimpia.DAL;
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.ArqLimpia.BL
{
    public class ProductBL : IProductBL
    {
        readonly IProduct _productDAL;
        readonly IUnitOfWork _unitWork;

        public async Task<CreateProductOutputDTOs> CreateProduct(CreateProductInputDTOs pProducts)
        {
            ProductEN newProduct = new ProductEN()
            {
                NameProduct = pProducts.NameProduct,
                DescriptionsProduct = pProducts.DescriptionProduct,
                Tipe = pProducts.Tipe,
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
                NameProduct = newProduct.NameProduct,
                DescriptionProduct = newProduct.DescriptionsProduct,
                Tipe = newProduct.Tipe,
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

        public async Task<GetByIdProductOutputDTO> GetById(GetByIdProductOutputDTO pProducts)
        {
            ProductEN product = await _productDAL.GetById(new ProductEN { Id = pProducts.Id });
            return new GetByIdProductOutputDTO
            {
                Id = product.Id,
                NameProduct = product.NameProduct,
                DescriptionProduct = product.DescriptionsProduct
            };
        }

        public async Task<List<SearchProducOutputDTOs>> Search(SearchProducOutputDTOs pProducts)
        {
            List<ProductEN> products = await _productDAL.Search(new ProductEN { NameProduct = pProducts.NameProduct, DescriptionsProduct = pProducts.DescriptionProduct, Tipe = pProducts.Tipe, Amount = pProducts.Amount });
            List<SearchProducOutputDTOs> list = new List<SearchProducOutputDTOs>();
            products.ForEach(p => list.Add(new SearchProducOutputDTOs
            {
                Id = p.Id,
                NameProduct = p.NameProduct,
                DescriptionProduct = p.DescriptionsProduct,
                Tipe = p.Tipe,
                Amount = p.Amount
            }));
            return list;

        }

        public async Task<UpdateProductOutputDTOs> Update(UpdateProductOutputDTOs pProducts)
        {
            ProductEN productUpdate = await _productDAL.GetById(pProducts.Id);

            if (productUpdate.Id == pProducts.Id)
            {
                productUpdate.NameProduct = pProducts.NameProduct;
                productUpdate.DescriptionsProduct = pProducts.DescriptionProduct;
                productUpdate.Tipe = pProducts.Tipe;
                productUpdate.Amount = pProducts.Amount;

                _productDAL.Update(productUpdate);
                await _unitWork.SaveChangesAsync();
                UpdateProductOutputDTOs product = new UpdateProductOutputDTOs()
                {
                    Id = productUpdate.Id,
                    NameProduct = productUpdate.NameProduct,
                    DescriptionProduct = productUpdate.DescriptionsProduct,
                    Tipe = productUpdate.Tipe,
                    Amount = productUpdate.Amount
                };
                return product;
            }

            throw new Exception($"The product with id: {pProducts.Id} not found");

        }
    }
  }
