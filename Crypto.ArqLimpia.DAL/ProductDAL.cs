using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;
using Crypto.ArqLimpia.BL.DTOs;

namespace Crypto.ArqLimpia.DAL
{
    public class ProductDAL : IProduct
    {
        readonly CryptoDbContext dbContext;

        public ProductDAL(CryptoDbContext pdbContext)
        {
            dbContext = pdbContext;
        }

        public void Create(ProductEN pProducts)
        {
            dbContext.Products.Add(pProducts);
        }

        public void Delete(ProductEN pProducts)
        {
            dbContext.Products.Remove(pProducts);
        }

        public async Task<ProductEN> GetById(ProductEN pProducts)
        {
            ProductEN? product = await dbContext.Products.FirstOrDefaultAsync(s => s.Id == pProducts.Id);
            if (product != null)
                return product;
            else
                return new ProductEN();
        }


        public void Update(ProductEN pProducts)
        {
            dbContext.Products.Update(pProducts);
        }

        public async Task<List<ProductEN>> Search(getProductsInputDTOs pProducts)
        {
            IQueryable<ProductEN> query = dbContext.Products.AsQueryable();

            // Filtrar por Nombre
            if (!string.IsNullOrEmpty(pProducts.ProductName))
            {
                query = query.Where(p => p.NameProduct.Contains(pProducts.ProductName));
            }

            // Filtrar por Tipo
            if (!string.IsNullOrEmpty(pProducts.Type))
            {
                query = query.Where(p => p.Tipe.Contains(pProducts.Type));
            }

            return await query.ToListAsync();
        }

        public async Task<ProductEN> GetById(int id)
        {
            ProductEN product = await dbContext.Products.FindAsync(id);
            return product;
        }
    }
    }
