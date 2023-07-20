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
            dbContext.Cryptocurrencies.Add(pProducts);
        }

        public void Delete(ProductEN pProducts)
        {
            dbContext.Cryptocurrencies.Remove(pProducts);
        }

        public async Task<ProductEN> GetById(ProductEN pProducts)
        {
            ProductEN? product = await dbContext.Cryptocurrencies.FirstOrDefaultAsync(s => s.Id == pProducts.Id);
            if (product != null)
                return product;
            else
                return new ProductEN();
        }


        public void Update(ProductEN pProducts)
        {
            dbContext.Cryptocurrencies.Update(pProducts);
        }

        public async Task<List<ProductEN>> Search(getProductsInputDTOs pProducts)
        {
            IQueryable<ProductEN> query = dbContext.Cryptocurrencies.AsQueryable();

            // Filtrar por Nombre
            if (!string.IsNullOrEmpty(pProducts.ProductName))
            {
                query = query.Where(p => p.CryptoName.Contains(pProducts.ProductName));
            }


            return await query.ToListAsync();
        }

        public async Task<ProductEN> GetById(int id)
        {
            ProductEN product = await dbContext.Cryptocurrencies.FindAsync(id);
            return product;
        }
    }
    }
