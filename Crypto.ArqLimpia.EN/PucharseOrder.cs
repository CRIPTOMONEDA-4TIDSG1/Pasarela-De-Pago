
namespace Crypto.ArqLimpia.EN
{
    public class OrderEN
    {
        public int Id { get; set; }

        public DateTime DateOrder { get; set; }

        public string email { get; set; }
        
        public int  product_id { get;set; }

        public decimal Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
