using System.ComponentModel.DataAnnotations;

namespace Inventory.Models;

public class Item
{
    public int Id { get; set; }

    [Display(Name ="Product Code")]
    public string ProductCode { get; set; } = default!;
    public string ProductName { get; set; } = default!;
    public decimal? StandardPrice { get; set; }
    public string? ImageUrl { get; set; }
    public int CateId { get; set; }
    public Supplier? Supplier { get; set; } 
    public Category? Category { get; set; } 
    public List<Customer>? Cusomter { get; set; }
}
