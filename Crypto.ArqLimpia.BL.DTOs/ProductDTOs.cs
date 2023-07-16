
using System.ComponentModel.DataAnnotations;




namespace Crypto.ArqLimpia.BL.DTOs
{
    //  DTOs PARA CREAR PRODUCTOS
    public class CreateProductInputDTOs
    {
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "The Title must have at least 5 characters.")]
        public string NameProduct { get; set; }


        [Required(ErrorMessage = "The field Description is required")]
        [StringLength(150)]
        public string DescriptionProduct { get; set; }


        [Required(ErrorMessage = "The field Tipe is required")]
        [StringLength(50)]
        public string Tipe { get; set; }


        [Required(ErrorMessage = "The field Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The field Amount must be greater than 1")]
        public int Amount { get; set; }


    }
    public class CreateProductOutputDTOs
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public string Tipe { get; set; }
        public int Amount { get; set; }

    }

    //  DTOs PARA ELIMINAR PRODUCTOS
    public class DeleteProductsInputDTOs
    {
        [Required]
        public int Id { get; set; }
    }

    public class DeleteProductsOutputDTOs
    {
        public bool IsDeleted { get; set; }
    }


    //  DTOs PARA ACTUALIZAR PRODUCTOS
    public class UpdateProductInputDTOs
    {
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "The Title must have at least 5 characters.")]
        public string NameProduct { get; set; }


        [Required(ErrorMessage = "The field Description is required")]
        [StringLength(150)]
        public string DescriptionProduct { get; set; }


        [Required(ErrorMessage = "The field Tipe is required")]
        [StringLength(50)]
        public string Tipe { get; set; }


        [Required(ErrorMessage = "The field Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The field Amount must be greater than 1")]
        public int Amount { get; set; }


    }


    //  DTOs PARA EDITAR PRODUCTOS
    public class UpdateProductOutputDTOs
    {
        public int Id { get; set; }
        public string NameProduct  { get; set; }
        public string DescriptionProduct { get; set; }
        public string Tipe { get; set; }
        public int Amount { get; set; }

    }

    public class GetByIdProductOutputDTO
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public string Tipe { get; set; }
        public int Amount { get; set; }
    }

    //  DTOs PARA BUSCAR PRODUCTOS
    public class SearchProductInputDTOs
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
    }
    public class SearchProducOutputDTOs
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public string Tipe { get; set; }
        public int Amount { get; set; }

    }
}
