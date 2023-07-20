using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Crypto.ArqLimpia.EN;

namespace PASARELASTRIPE.Controllers
{
    public class CheckOutController : Controller
    {
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
                return View("Succes");
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


        public IActionResult CheckOut()
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
                    CryptoName = "Ether",
                    DescriptionCrypto = "Ether is a cryptoCurrenci",
                    price = 25,
                    Amount= 2

                },
                        new ProductEN
                {
                    CryptoName = "NFT",
                    DescriptionCrypto = "NFT is a cryptoCurrenci",
                    price = 25,
                    Amount= 2

                }
            };

            var domain = "https://localhost:7090/";

            var options = new SessionCreateOptions
            {
                SuccessUrl=domain + $"CheckOut/OrderConfirmation",
                CancelUrl = domain + "CheckOut/Login",
                LineItems = new List<SessionLineItemOptions>(),
                Mode ="payment"
            };

            foreach (var item in productList)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(item.price * item.Amount),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.CryptoName.ToString(),
                        }
                    },
                    Quantity = item.Amount
                };

                options.LineItems.Add(sessionListItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);

            TempData["Session"] = session.Id;

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

          
        }
    }
}
