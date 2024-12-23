namespace CheckoutKata
{
    public interface IPricingRule
    {
        char SKU { get; set; }
        int UnitPrice { get; set; }
    }
}