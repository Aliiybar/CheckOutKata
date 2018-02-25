namespace CheckOut.Models
{
    public class Item
    {

        public Item(string sku, int unitPrice, int discountQuantity, int discountedTotal)
        {
            Sku = sku;
            UnitPrice = unitPrice;
            DiscountQuantity = discountQuantity;
            DiscountedTotal = discountedTotal;
        }
        public string Sku { get; private set; }
        public int UnitPrice { get; private set; }
        public int DiscountQuantity { get; private set; }
        public int DiscountedTotal { get; private set; }
    }
}