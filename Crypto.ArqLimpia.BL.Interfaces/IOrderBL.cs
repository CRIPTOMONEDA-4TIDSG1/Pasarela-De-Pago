using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.EN;


namespace Crypto.ArqLimpia.BL.Interfaces
{
    public interface IOrderBL
    {
        public Task<OrderEN> GetOrderById(int Id);
        public Task<List<OrderEN>> getAllOrder();
        public Task<CreateOrderInputDTOs> AddOrder(CreateOrderInputDTOs order);

    }
}