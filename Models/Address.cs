using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int SupplierRefId { get; set; }   
        public string? City { get; set; }
        public string? ProvinceName { get; set; }
        public string? DistrictName { get; set; }
        public string? CommuneName { get; set; }
        public string? Village { get; set; }
        [ForeignKey("SupplierRefId")]
        public Supplier? Supplier { get; set; } 
    }
}
