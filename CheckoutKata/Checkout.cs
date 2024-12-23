

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private List<char> _items;

        public Checkout()
        {
            _items = new List<char> { };
        }

        public int GetTotaPrice()
        {
            return 0;
        }

        public void Scan(string item)
        {
            if (String.IsNullOrEmpty(item))
            {
                _items.AddRange(item);
            }
        }
    }
}