namespace Inventory.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderRefId { get; set; }
        public int ItemRefId { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }


        private decimal _subtotal;
        public decimal SubTotal 
        {
            get
            {
                return Quantity * Price;
            }
            set
            {
                _subtotal = value;  
            }
        } 
        public Item? Item { get; set; }
        public Order? Order { get; set; } 
    }
}
