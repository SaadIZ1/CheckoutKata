namespace CheckoutKata
{
    public class PricingRule : IPricingRule
    {
        public char SKU { get; set; }
        public int UnitPrice { get; set; }
    }
}