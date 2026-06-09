using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Full Name is requred")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is requred")]
        public string? Address { get; set; }

        [Required (ErrorMessage ="Phone Number is requred")]
        public string? PhoneNumber { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Price { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
