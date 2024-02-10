using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(maximumLength:20,ErrorMessage ="User must be between 3 characters and 20 characteres",MinimumLength=3)]
        public string UserName { get; set; } = default!;

        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = default!;

        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)] 
        public string ConfirmPassword { get; set; } = default!; 
    }
}
