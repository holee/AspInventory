namespace Inventory.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Phone { get; set; }
        //public List<Order>? Orders { get; set; }
        public List<Customer>? Customers { get; set; } = new();
    }
}