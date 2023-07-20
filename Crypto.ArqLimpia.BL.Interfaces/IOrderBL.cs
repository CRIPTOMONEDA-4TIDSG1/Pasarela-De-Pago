using Crypto.ArqLimpia.BL.DTOs;



namespace Crypto.ArqLimpia.BL.Interfaces
{
    public interface IOrderBL
    {
        public List<CreateOrderInputDTOs> GetAllOrders();
        public SearchOrderOutputDTOs GetOrderById(int Id);
        public void AddOrder(CreateOrderInputDTOs order);

    }
}