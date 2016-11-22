using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddEcommerceApp.Domain;
using Xunit;
using FluentAssertions;

namespace TddEcommerceApp.Tests
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
