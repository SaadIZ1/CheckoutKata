namespace CheckoutKata.Logic
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();

    }
}