using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }

        [Required (ErrorMessage = "Category Name is required")]
        public string? Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
