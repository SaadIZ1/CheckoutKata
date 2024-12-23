

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private Dictionary<char, int> _items;
        private IEnumerable<PricingRule> _pricingRules;


        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules;
            _items = new Dictionary<char,int> { };
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach(var item in _items)
            {
                var pricingRule = _pricingRules.FirstOrDefault(pricingRule => pricingRule.SKU == item.Key);
                if (pricingRule != null)
                {
                    if (pricingRule.SpecialPriceQuantity != 0)
                    {
                        if (item.Value >= pricingRule.SpecialPriceQuantity)
                        {
                            totalPrice += (item.Value / pricingRule.SpecialPriceQuantity) * pricingRule.SpecialPriceAmount;
                            
                            totalPrice += (item.Value % pricingRule.SpecialPriceQuantity) * pricingRule.UnitPrice;
                        }
                        else
                            totalPrice += pricingRule.UnitPrice * item.Value;
                    }
                    else
                        totalPrice += pricingRule.UnitPrice * item.Value;
                }
            }

            return totalPrice;
        }

        public void Scan(string item)
        {
            int currentCount;
            item = item.ToUpper();
            if (!String.IsNullOrEmpty(item))
            {
                if (!_items.ContainsKey(char.Parse(item)))
                {
                    _items.Add(char.Parse(item), 1);
                }
                else
                {
                    _items.TryGetValue(char.Parse(item), out currentCount);
                    _items[char.Parse(item)] = currentCount + 1;
                }
            }
        }
    }
}