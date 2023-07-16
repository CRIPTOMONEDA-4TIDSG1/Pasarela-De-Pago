using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<ProductEN>> Search(ProductEN pProducts)
        {
            IQueryable<ProductEN> query = dbContext.Products.AsQueryable();

            // Filtrar por Nombre
            if (!string.IsNullOrEmpty(pProducts.NameProduct))
            {
                query = query.Where(p => p.NameProduct.Contains(pProducts.NameProduct));
            }

            // Filtrar por Tipo
            if (!string.IsNullOrEmpty(pProducts.Tipe))
            {
                query = query.Where(p => p.Tipe.Contains(pProducts.Tipe));
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
