using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class RegisterModel
    {
        //[Required]
        //[StringLength(maximumLength: 100, ErrorMessage = "User must be between 3 characters and 20 characteres", MinimumLength = 3)]
        //public string UserName { get; set; } = default!;
        [Required]
        [EmailAddress]
        [StringLength(maximumLength:100, ErrorMessage = "User must be between 3 characters and 20 characteres", MinimumLength = 3)]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = default!; 
    }
}
