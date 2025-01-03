using CheckoutKata.Logic;
using FluentAssertions;


namespace CheckoutKata.Tests
{
    public class CheckoutTest
    {
        IEnumerable<IPricingRule> pricingRule = new[] {
            new PricingRule{SKU = 'A', UnitPrice = 50, SpecialPriceQuantity = 3, SpecialPriceAmount = 130 },
            new PricingRule{SKU = 'B', UnitPrice = 30 },
            new PricingRule{SKU = 'C', UnitPrice = 20, SpecialPriceQuantity = 2, SpecialPriceAmount = 30 },
            new PricingRule{SKU = 'D', UnitPrice = 10 },
        };

        [Theory]
        [InlineData("")]
        public void ShouldReturnZeroWhenStringIsEmpty(string val1)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            var result = checkout.GetTotalPrice();
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("A")]
        public void GetCorrectTotalPriceFor1Items(string val1)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            var result = checkout.GetTotalPrice();
            result.Should().Be(50);
        }

        [Theory]
        [InlineData("A", "B")]
        public void GetCorrectTotalPriceFor2Items(string val1, string val2)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            var result = checkout.GetTotalPrice();
            result.Should().Be(80);
        }

        [Theory]
        [InlineData("A", "B", "C", "A")]
        public void GetCorrectTotalPriceFor4ItemsWithOneDuplicate(string val1, string val2, string val3, string val4)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            checkout.Scan(val3);
            checkout.Scan(val4);
            var result = checkout.GetTotalPrice();
            result.Should().Be(150);
        }

        [Theory]
        [InlineData("A", "B", "C", "F")]
        public void GetCorrectTotalPriceForWhilePassingAnIncorrectSKU(string val1, string val2, string val3, string val4)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            checkout.Scan(val3);
            checkout.Scan(val4);
            var result = checkout.GetTotalPrice();
            result.Should().Be(100);
        }

        [Theory]
        [InlineData("A", "A", "A", "B")]
        public void ShouldGiveDiscountedPrice(string val1, string val2, string val3, string val4)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            checkout.Scan(val3);
            checkout.Scan(val4);
            var result = checkout.GetTotalPrice();
            result.Should().Be(160);
        }

        [Theory]
        [InlineData("A", "C", "D", "A", "C", "A", "C")]
        public void ShouldGiveDiscountedPriceWhenPassing7UnorderedItems(string val1, string val2, string val3, string val4, string val5, string val6, string val7)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            checkout.Scan(val3);
            checkout.Scan(val4);
            checkout.Scan(val5);
            checkout.Scan(val6);
            checkout.Scan(val7);
            var result = checkout.GetTotalPrice();
            result.Should().Be(190);
        }

        [Theory]
        [InlineData("a", "c", "d")]
        public void ScanningLowerCaseLetterShouldNotCauseAnIssue(string val1, string val2, string val3)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            checkout.Scan(val2);
            checkout.Scan(val3);
            var result = checkout.GetTotalPrice();
            result.Should().Be(80);
        }

        [Theory]
        [InlineData("0")]
        public void ShouldReturnZeroWhenStringIsNotALetter(string val1)
        {
            ICheckout checkout = new Checkout((IEnumerable<PricingRule>)pricingRule);

            checkout.Scan(val1);
            var result = checkout.GetTotalPrice();
            result.Should().Be(0);
        }
    }
}