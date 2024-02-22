namespace Inventory.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Phone { get; set; }
        //public List<Order>? Orders { get; set; }
        public List<Employee>? Employees { get; set; } = new();

    }
}
