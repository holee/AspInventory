using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Category
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ICollection<Item>? Item { get; set; }
    }
}
