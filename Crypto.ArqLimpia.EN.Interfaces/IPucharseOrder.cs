
using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.EN;

namespace Crypto.ArqLimpia.EN.Interfaces
{
    public  interface IPucharseOrder
    {
        void Create(OrderEN pOrder);
        Task<OrderEN> GetById(int id);
    }
}
