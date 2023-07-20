
using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.EN;

namespace Crypto.ArqLimpia.EN.Interfaces
{
    public  interface IPucharseOrder
    {
        void Create(PurchaseOrder pOrder);
        Task<PurchaseOrder> GetById(int id);
        Task<List<PurchaseOrder>> Search(PurchaseOrder pOrder);
    }
}
