using FluentAssertions;

namespace CheckoutKata
{
    public class CheckoutTest
    {
        [Fact]
        public void ShouldReturnZeroWhenStringIsEmpty()
        {
            String item = "";
            var result = Checkout.GetTotaPrice(item);
            result.Should().Be(0);

        }
    }
}