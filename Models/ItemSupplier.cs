namespace Inventory.Models
{
    public class ItemSupplier
    {
        //public int Id { get; set; } 
        public int Item_Id { get; set; }
        public Item? Item { get; set; }
        public int Supplier_Id { get; set; } 
        public Supplier? Supplier { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? Desctiption { get; set; }
    }
}
