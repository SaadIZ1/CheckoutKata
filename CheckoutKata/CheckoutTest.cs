using FluentAssertions;


namespace CheckoutKata
{
    public class CheckoutTest
    {
        // checkout = new Checkout(pricingRule);

            IEnumerable<IPricingRule> pricingRule = new[] {
            new PricingRule{SKU = 'A', UnitPrice = 50 },
            new PricingRule{SKU = 'B', UnitPrice = 30 },
        };

        [Theory]
        [InlineData("")]
        public void ShouldReturnZeroWhenStringIsEmpty(string val1)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            var result = checkout.GetTotaPrice();
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("A")]
        public void GetCorrectTotalPriceFor1Items(string val1)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            var result = checkout.GetTotaPrice();
            result.Should().Be(50);
        }

        [Theory]
        [InlineData("A","B")]
        public void GetCorrectTotalPriceFor2Items(string val1, string val2)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            var result = checkout.GetTotaPrice();
            result.Should().Be(80);
        }

    }
}