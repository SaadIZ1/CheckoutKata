namespace CheckoutKata.Logic
{
    public class Checkout : ICheckout
    {
        private Dictionary<char, int> _items;
        private IEnumerable<PricingRule> _pricingRules;


        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules;
            _items = new Dictionary<char, int> { };
        }

        public void Scan(string item)
        {
            int currentCount;

            if (!string.IsNullOrEmpty(item))
            {
                item = item.ToUpper();
                var charItem = char.Parse(item);

                if (char.IsLetter(charItem))
                {
                    if (!_items.ContainsKey(charItem))
                    {
                        _items.Add(charItem, 1);
                    }
                    else
                    {
                        _items.TryGetValue(charItem, out currentCount);
                        _items[charItem] = currentCount + 1;
                    }
                }
            }
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach (var item in _items)
            {
                var pricingRule = _pricingRules.FirstOrDefault(pricingRule => pricingRule.SKU == item.Key);
                if (pricingRule != null)
                {
                    if (pricingRule.SpecialPriceQuantity != 0)
                    {
                        // Assuming that if X is the quantity to activate the special price, all Multiples of X will have the discount applied to them
                        if (item.Value >= pricingRule.SpecialPriceQuantity)
                        {
                            totalPrice += item.Value / pricingRule.SpecialPriceQuantity * pricingRule.SpecialPriceAmount;
                            //To find the remainder of the items that won't have a discount apllied to them
                            totalPrice += item.Value % pricingRule.SpecialPriceQuantity * pricingRule.UnitPrice;
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


    }
}