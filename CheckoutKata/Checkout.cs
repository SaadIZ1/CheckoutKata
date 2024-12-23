

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private List<char> _items;
        private Dictionary<char, int> skuDict;

        public Checkout()
        {
            _items = new List<char> { };
            skuDict = new Dictionary<char, int> { { 'A', 50 } };
        }

        public int GetTotaPrice()
        {
            var totalPrice = 0;

            for (int i = 0; i < _items.Count; i++)
            {
                totalPrice += skuDict[_items[i]];   
            }

            return totalPrice;
        }

        public void Scan(string item)
        {
            if (!String.IsNullOrEmpty(item))
            {
                _items.AddRange(item);
            }
        }
    }
}