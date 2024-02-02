using System.Collections.Generic;
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
               DateOrder = DateTime.Now,
                Quantity = order.Quantity,
                product_id = order.product_id,
            };

            _orderDAL.Create(newOrder);
            await _unitWork.SaveChangesAsync();
            
            return order;
            }catch(Exception err){
                throw new Exception($"{err}");
            }
        }

        public async Task<GetAllOrderOutputDTOs> GetOrderById(int Id)
        {
            OrderEN isOrder = await _orderDAL.GetById(Id);
            if( isOrder == null )
            throw new Exception($"Order by id:{Id} is not exits");
            GetAllOrderOutputDTOs order = new GetAllOrderOutputDTOs()
            {
                Id = isOrder.Id,
                DateOrder = isOrder.DateOrder,
                product_id = isOrder.product_id,
                Quantity = isOrder.Quantity,
            };
            return order;
            
        }

        public async Task<List<GetAllOrderOutputDTOs>> getAllOrder()
        {
            List<OrderEN> orders = await _orderDAL.Search();
            List<GetAllOrderOutputDTOs> order = new List<GetAllOrderOutputDTOs>();
            orders.ForEach(p => order.Add(new GetAllOrderOutputDTOs(){
                Id = p.Id,
                DateOrder = p.DateOrder,
                product_id = p.product_id,
                Quantity = p.Quantity,
            }));
            return order;
        }
    }
}