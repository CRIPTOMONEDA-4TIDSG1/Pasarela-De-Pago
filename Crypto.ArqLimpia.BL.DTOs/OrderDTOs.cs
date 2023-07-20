
using Crypto.ArqLimpia.BL.DTOs;

namespace Crypto.ArqLimpia.BL.DTOs
{
    public class CreateOrderInputDTOs
    {
        public int Id {  get; set; }
        public List<CreateProductOutputDTOs> Products { get; set; }
        public DateTime DateOrder { get; set; }
        public string HeadLine { get; set; }
    }

    public class SearchOrderInputDTOs
    {
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public DateTime? DateOrder { get; set; }
    }

    public class SearchOrderOutputDTOs
    {
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public DateTime? DateOrder { get; set; }
    }
}
