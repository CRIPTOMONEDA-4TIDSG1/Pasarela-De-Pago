
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;

namespace Crypto.ArqLimpia.DAL
{
    public class PucharseOrderDAL : IPucharseOrder
    {
        private readonly CryptoDbContext _dbContext;

        public PucharseOrderDAL(CryptoDbContext dbContext){
            _dbContext = dbContext;
        }

        public void Create(OrderEN pOrder)
        {
            _dbContext.CryptoOrder.Add(pOrder);
        }

        public async Task<OrderEN> GetById(int id)
        {
            OrderEN order = await _dbContext.CryptoOrder.FindAsync(id);
            return order;
        }

        public Task<List<OrderEN>> Search(OrderEN pOrder)
        {
            throw new NotImplementedException();
        }
    }
}
