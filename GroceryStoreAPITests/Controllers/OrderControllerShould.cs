using AutoFixture;
using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace GroceryStoreAPITests.Controllers
{
    public class OrderControllerShould
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void ReturnAllCustomersWhenGetCustomersIsCalled()
        {
            var expected = _fixture.CreateMany<Order>(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Orders.Returns(expected);

            var controller = new OrderController(context);
            var actual = controller.GetOrders();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnCustomersWithSameDateWhenGetCustomersByDateIsCalled()
        {
            var now = DateTime.Now;
            var expected = _fixture.Build<Order>()
                .With(x => x.OrderDate, now)
                .CreateMany(2).ToList();
            var additionalOrders = _fixture.Build<Order>()
                .With(x => x.OrderDate, DateTime.Now.AddDays(-15))
                .CreateMany(3);

            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Orders.Returns(expected.Concat(additionalOrders).ToList());

            var controller = new OrderController(context);
            var actual = controller.GetOrdersByDate(now.Year, now.Month, now.Day);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnEmptyArrayWhenGetCustomersByDateIsCalledWithDateThatHasNoOrders()
        {
            var now = DateTime.Now;
            var orders = _fixture.Build<Order>()
                .With(x => x.OrderDate, DateTime.Now.AddDays(-15))
                .CreateMany(5).ToList();

            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Orders.Returns(orders);

            var controller = new OrderController(context);
            var actual = controller.GetOrdersByDate(now.Year, now.Month, now.Day);

            actual.Should().BeEmpty();
        }

        [Fact]
        public void ReturnCustomerWithSameIdWhenGetCustomersByIdIsCalled()
        {
            var orders = _fixture.CreateMany<Order>(5).ToList();

            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Orders.Returns(orders);

            var expected = orders[2];
            var controller = new OrderController(context);
            var actual = controller.GetOrdersById(expected.Id);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnNullWhenGetCustomersByIdWithInvalidIdIsCalled()
        {
            var orders = _fixture.Build<Order>()
                .With(x => x.Id, 1)
                .CreateMany(5).ToList();

            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Orders.Returns(orders);

            var controller = new OrderController(context);
            var actual = controller.GetOrdersById(2);

            actual.Should().BeNull();
        }
    }
}
