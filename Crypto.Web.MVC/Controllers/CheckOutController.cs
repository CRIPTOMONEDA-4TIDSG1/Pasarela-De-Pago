using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.BL.Interfaces;
using Crypto.ArqLimpia.BL.DTOs;


namespace PASARELASTRIPE.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IOrderBL _orderBL;

        public CheckOutController(IOrderBL orderBL) {
          _orderBL = orderBL;
        }

        public IActionResult Index()
        {
            List<ProductEN> productList = new List<ProductEN>();
            productList = new List<ProductEN>
            {
                new ProductEN
                {
                    CryptoName = "Bitcoin",
                    DescriptionCrypto = "Bitcoins is a cryptoCurrenci",
                    price = 25,
                    Amount= 2

                },
                    new ProductEN
                {
                    CryptoName= "Ether",
                    DescriptionCrypto = "Ether is a cryptoCurrenci",
                    price = 25,
                    Amount= 2

                },
                        new ProductEN
                {
                    CryptoName= "NFT",
                    DescriptionCrypto = "NFT is a cryptoCurrenci",
                    price = 25,
                    Amount= 2

                }
            };
            return View(productList);
        }

        public IActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());


            if(session.PaymentStatus == "paid")
            {
                var transaction = session.PaymentIntentId.ToString();
                return View();
            }
            return View("Login");


        }

        public IActionResult Succes()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult CheckOut(string productName, decimal price, int Id)
        {
            
            CreateOrderInputDTOs order = new CreateOrderInputDTOs()
            {
                DateOrder = DateTime.Now,
                Quantity = 23,
                email = "kalet@gmail.com",
                product_id = Id, 
                total = price * 23
            };

            var setOrder = _orderBL.AddOrder(order);

           
            
            var domain = "https://localhost:7090/";

            var options = new SessionCreateOptions
            {
                SuccessUrl=domain + $"CheckOut/OrderConfirmation/",
                CancelUrl = domain + "CheckOut/Login",
                LineItems = new List<SessionLineItemOptions>(),
                Mode ="payment"
            };

                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(price * 23),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = productName.ToString(),
                        }
                    },
                    Quantity = 23
                };

                options.LineItems.Add(sessionListItem);
            

            var service = new SessionService();
            Session session = service.Create(options);

            TempData["Session"] = session.Id;

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

          
        }
    }
}
