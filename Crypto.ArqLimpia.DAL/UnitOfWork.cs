using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crypto.ArqLimpia.EN.Interfaces;
namespace Crypto.ArqLimpia.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly CryptoDbContext dbContext;

        public UnitOfWork(CryptoDbContext pDbContext)
        {
            dbContext = pDbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();

        }
    }
}
