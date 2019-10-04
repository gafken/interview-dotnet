using FluentAssertions;
using GroceryStoreAPI;
using Xunit;

namespace GroceryStoreAPITests
{
    public class GroceryStoreDbContextShould
    {
        [Fact]
        public void SetPropertiesOnInitialization()
        {
            var context = new GroceryStoreDbContext();
            context.Customers.Count.Should().Be(3);
            context.Orders.Count.Should().Be(1);
            context.Products.Count.Should().Be(3);
        }
    }
}
