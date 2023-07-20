


namespace Crypto.ArqLimpia.BL.DTOs
{
    public class CreateOrderInputDTOs
    {
        public DateTime DateOrder { get; set; }
        public string email { get; set; }        
        public string CryptoName { get; set; }
        public decimal price { get; set; }
        public int Amount { get; set; }
        public int total { get; set; }
    }
}
