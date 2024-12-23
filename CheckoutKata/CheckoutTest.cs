using FluentAssertions;

namespace CheckoutKata
{
    public class CheckoutTest
    {
        [Fact]
        public void ShouldReturnZeroWhenStringIsEmpty()
        {
            Checkout.Scan("");
            var result = Checkout.GetTotaPrice();
            result.Should().Be(0);

        }
    }
}