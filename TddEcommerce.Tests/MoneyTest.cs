using FluentAssertions;
using TddEcommerce.Domain;
using Xunit;

namespace TddEcommerce.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void AddMoney()
        {
            new Money(3, 50).Add(new Money(4, 20)).Should().Be(new Money(7,70));
        }
    }
}
