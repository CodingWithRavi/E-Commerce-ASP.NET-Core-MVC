using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required (ErrorMessage = "Product Name is required")]
        public string? ProductName { get; set; }

        [Required (ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(28,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        //foreignkey
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        //navigation 
        public Category? Category { get; set; }
    }
}
