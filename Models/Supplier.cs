using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public enum Gender
    {
        Female,
        Male,
        Other
    }

    //ItemSupplier
    public class Supplier
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        
        [DataType(DataType.PhoneNumber)] //type="tel"
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }//type="email"
        public string? Gender { get; set; } 
        public string? City { get; set; }
        public Address? Address { get; set; }
        //public List<ItemSupplier>? ItemSuppliers { get; set; }

        public List<Item>? Items { get; set; } 
        public string? Description { get; set; }

    }
}
