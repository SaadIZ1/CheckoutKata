namespace CheckoutKata
{
    public interface IPricingRule
    {
        char SKU { get; set; }
        int UnitPrice { get; set; }
        int SpecialPriceQuantity { get; set; }
        int SpecialPriceAmount { get; set; }
    }
}