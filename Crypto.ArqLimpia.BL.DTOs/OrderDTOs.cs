using System;


namespace Crypto.ArqLimpia.BL.DTOs
{
    public class CreateOrderInputDTOs
    {
        public DateTime DateOrder { get; set; }
        public string email { get; set; }
        public int product_id { get; set; }
        public int Quantity { get; set; }
        public decimal total { get; set; }
    }
    public class GetAllOrderOutputDTOs{
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public string email { get; set; }
        public int product_id { get; set; }
        public decimal Quantity { get; set; }
        public decimal total { get; set; } 
    }
}
