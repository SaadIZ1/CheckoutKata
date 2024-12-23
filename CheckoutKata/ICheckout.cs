namespace CheckoutKata
{
    public interface ICheckout
    {
        int GetTotaPrice();
        void Scan(string item);
    }
}