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
            var money = new Money(3, 50);
            money.Add(new Money(4, 20)).Should().Be(new Money(7,70));
        }
    }
}
