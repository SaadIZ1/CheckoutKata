

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private List<char> _items;
        private IEnumerable<PricingRule> _pricingRules;


        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules;
            _items = new List<char> { };
        }

        public int GetTotaPrice()
        {
            var totalPrice = 0;

            for (int i = 0; i < _items.Count; i++)
            {
                var pricingRule = _pricingRules.FirstOrDefault(pricingRule => pricingRule.SKU == _items[i]); //.FirstOrDefault(pricingRule => pricingRule.UnitPrice);
                if (pricingRule != null)
                {
                    totalPrice += pricingRule.UnitPrice;
                }
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