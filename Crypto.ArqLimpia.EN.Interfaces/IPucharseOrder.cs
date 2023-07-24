
using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.EN;

namespace Crypto.ArqLimpia.EN.Interfaces
{
    public  interface IPucharseOrder
    {
        void Create(OrderEN pOrder);
        Task<List<OrderEN>> Search();
        Task<OrderEN> GetById(int id);
    }
}
