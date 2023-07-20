using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.BL.Interfaces;
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.EN.Interfaces;

namespace Crypto.ArqLimpia.BL{
    public class OrderBL : IOrderBL
    {
        readonly IPucharseOrder _orderDAL;
        readonly IUnitOfWork _unitWork;

        public OrderBL(IPucharseOrder orderDAL, IUnitOfWork unitOfWork){
            _orderDAL = orderDAL;
            _unitWork = _unitWork;
        }

        public async Task<CreateOrderInputDTOs> AddOrder(CreateOrderInputDTOs order)
        {
            OrderEN newOrder = new OrderEN(){
                email = order.email,
                DateOrder = order.DateOrder,
                CryptoName = order.CryptoName ,
                price= order.price,
                Amount = order.Amount,
                Total = order.total
            };

            _orderDAL.Create(newOrder);
            await _unitWork.SaveChangesAsync();

            return order;
        }

        public async Task<OrderEN> GetOrderById(int Id)
        {
            OrderEN order = await _orderDAL.GetById(Id);
            if( order != null )
            throw new Exception($"Order by id:{Id} is not exits");

            return order;
            
        }
    }
}