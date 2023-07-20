
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;

namespace Crypto.ArqLimpia.DAL
{
    public class PucharseOrderDAL : IPucharseOrder
    {
        public void Create(OrderEN pOrder)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderEN>> Search(OrderEN pOrder)
        {
            throw new NotImplementedException();
        }

        Task<OrderEN> IPucharseOrder.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
