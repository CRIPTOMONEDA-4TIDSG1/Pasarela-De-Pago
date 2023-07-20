using Crypto.ArqLimpia.BL.DTOs;



namespace Crypto.ArqLimpia.BL.Interfaces
{
    public interface IOrderBL
    {
        public List<OrderInputDTOs> GetAllOrders();
        public OrderInputDTOs GetOrderById(int Id);
        public void AddOrder(OrderInputDTOs order);

    }
}