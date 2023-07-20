
namespace Crypto.ArqLimpia.EN
{
    public class OrderEN
    {
        public int Id { get; set; }

        public DateTime DateOrder { get; set; }

        public string email { get; set; }
        
        public string CryptoName { get; set; }

        public decimal price { get; set; }

        public int Amount { get; set; }

        public int Total { get; set; }
    }
}
