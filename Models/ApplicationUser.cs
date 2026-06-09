using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required (ErrorMessage = "First Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 100 characters")]
        public String? FirstName { get; set; }

        [Required (ErrorMessage = "Last Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 100 characters")]
        public String? LastName { get; set; }

        [Required (ErrorMessage = "Address is required")]
        [StringLength(300, ErrorMessage = "Address maximum length is 300 characters")]
        public String? Address { get; set; }
    }
}
