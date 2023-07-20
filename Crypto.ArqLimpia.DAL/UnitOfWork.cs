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
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();

        }
    }
}
