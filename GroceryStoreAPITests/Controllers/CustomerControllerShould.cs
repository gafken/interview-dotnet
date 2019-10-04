using AutoFixture;
using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using NSubstitute;
using System.Linq;
using Xunit;

namespace GroceryStoreAPITests.Controllers
{
    public class CustomerControllerShould
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void ReturnAllCustomersWhenGetCustomersIsCalled()
        {
            var expected = _fixture.CreateMany<Customer>(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Customers.Returns(expected);

            var controller = new CustomerController(context);
            var actual = controller.GetCustomers();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
