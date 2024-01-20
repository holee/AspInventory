using System.ComponentModel.DataAnnotations;

namespace Inventory.Models;

public class Item
{
    public int Id { get; set; }
    public int CategoryRefId { get; set; } 
    public int SupllierRefId { get; set; }

    [Display(Name ="Product Code")]
    public string ProductCode { get; set; } = default!;
    public string ProductName { get; set; } = default!;
    public decimal? StandardPrice { get; set; }
    public string? ImageUrl { get; set; } 
}
