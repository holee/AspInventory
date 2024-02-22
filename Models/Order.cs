namespace Inventory.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerRefId { get; set; }
        public int EmployeeRefId { get; set; } 
        public DateTime? OrderDate { get; set; }
        public decimal Discount { get; set; }  
        public decimal? Total { get; set; }
        public Employee? Employee { get; set; }
        public Customer? Customer { get; set; }
        public List<OrderLine>? OrderLines { get; set; }
        
    }
}
