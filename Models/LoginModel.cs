using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class LoginModel 
    {

        [Remote(action: "CheckUser", controller: "Auth")]
        [Required(ErrorMessage ="Please enter your username")]
        [StringLength(maximumLength:20,ErrorMessage ="User Name must be between 3 characters and 20 characteres",MinimumLength=3)]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage ="Please enter your password.")]
        [MinLength(4,ErrorMessage ="Password is at leat 4 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        public bool RememberMe { get; set; } = false;
    }
}
