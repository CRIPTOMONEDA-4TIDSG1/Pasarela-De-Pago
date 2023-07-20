
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;

namespace Crypto.ArqLimpia.DAL
{
    public class PucharseOrderDAL : IPucharseOrder
    {
        public void Create(PurchaseOrder pOrder)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseOrder>> Search(PurchaseOrder pOrder)
        {
            throw new NotImplementedException();
        }

        Task<PurchaseOrder> IPucharseOrder.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
