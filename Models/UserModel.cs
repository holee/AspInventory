namespace Inventory.Models
{
    public class UserModel
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool RememberMe { get; set; } = false;
    }
}
