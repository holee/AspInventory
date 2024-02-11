using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models;

public class Item
{
    public int Id { get; set; }
    [ForeignKey(nameof(Supplier))]
    public int SupplierRefId { get; set; }
    [Display(Name ="Product Code")]
    public string ProductCode { get; set; } = default!;
    public string ProductName { get; set; } = default!;
    public decimal? StandardPrice { get; set; }
    public string? ImageUrl { get; set; }

    //public int CateId { get; set; }
    public Category? Category { get; set; }
}
