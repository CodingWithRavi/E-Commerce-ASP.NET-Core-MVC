using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public Product? Product{ get; set; }
        public int Quantity { get; set; }
        public string? UserId { get; set; }
    }
}
