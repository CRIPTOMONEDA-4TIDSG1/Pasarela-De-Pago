using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.EN;


namespace Crypto.ArqLimpia.BL.Interfaces
{
    public interface IOrderBL
    {
        public Task<GetAllOrderOutputDTOs> GetOrderById(int Id);
        public Task<List<GetAllOrderOutputDTOs>> getAllOrder();
        public Task<CreateOrderInputDTOs> AddOrder(CreateOrderInputDTOs order);

    }
}