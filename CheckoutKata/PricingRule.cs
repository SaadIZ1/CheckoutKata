namespace CheckoutKata
{
    public class PricingRule : IPricingRule
    {
        public char SKU { get; set; }
        public int UnitPrice { get; set; }
        public int SpecialPriceQuantity { get; set; }
        public int SpecialPriceAmount { get; set; }
    }
}