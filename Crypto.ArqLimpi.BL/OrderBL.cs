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
            _unitWork = unitOfWork;
        }

        public async Task<CreateOrderInputDTOs> AddOrder(CreateOrderInputDTOs order)
        {
            try{
                OrderEN newOrder = new OrderEN(){
                DateOrder = order.DateOrder,
                email = order.email,
                Quantity = order.Quantity,
                product_id = order.product_id,
                Total = order.total
            };

            _orderDAL.Create(newOrder);
            await _unitWork.SaveChangesAsync();
            
            return order;
            }catch(Exception err){
                throw new Exception($"{err}");
            }
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