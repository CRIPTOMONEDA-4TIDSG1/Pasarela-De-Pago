using System;
using System.Threading.Tasks;
using System.Web;
using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.ArqLimpia.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderBL _orderBL;

        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(CreateOrderInputDTOs order, int quantity, int product_id)
        {
            try
            {
                order.Quantity = quantity;
                order.product_id = product_id;
                var createdOrder = await _orderBL.AddOrder(order);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Agregar mensajes de depuración
                Console.WriteLine($"Error en AddOrder: {ex.Message}");
                ViewBag.ErrorMessage = "Se produjo un error al agregar la orden.";
                return View("Error");
            }
        }



        public async Task<IActionResult> Index()
        {
            var list = await _orderBL.getAllOrder();
            return View(list);
        }

        public async Task<ActionResult> OrderDetails(int Id)
        {
                GetAllOrderOutputDTOs order = await _orderBL.GetOrderById(Id);
                
                return View(order);
           
        }
    }
}

