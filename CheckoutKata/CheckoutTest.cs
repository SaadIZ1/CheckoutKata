using FluentAssertions;


namespace CheckoutKata
{
    public class CheckoutTest
    {
        ICheckout checkout = new Checkout();

        [Theory]
        [InlineData("")]
        public void ShouldReturnZeroWhenStringIsEmpty(string val1)
        {
            checkout.Scan(val1);
            var result = checkout.GetTotaPrice();
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("A")]
        public void GetCorrectTotalPriceFor1Items(string val1)
        {
            checkout.Scan(val1);
            var result = checkout.GetTotaPrice();
            result.Should().Be(50);
        }

        [Theory]
        [InlineData("A","B")]
        public void GetCorrectTotalPriceFor2Items(string val1, string val2)
        {
            checkout.Scan(val1);
            checkout.Scan(val2);
            var result = checkout.GetTotaPrice();
            result.Should().Be(80);
        }

    }
}