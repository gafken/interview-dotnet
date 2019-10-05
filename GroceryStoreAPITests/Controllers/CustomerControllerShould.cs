using AutoFixture;
using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using NSubstitute;
using System.Collections.Generic;
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

        [Fact]
        public void ReturnCustomerThatMatchesOnIdWhenGetCustomerByIdIsCalled()
        {
            var customers = _fixture.CreateMany<Customer>(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Customers.Returns(customers);

            var expected = customers[2];
            var controller = new CustomerController(context);
            var actual = controller.GetCustomerById(expected.Id);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnNullWhenGetCustomerByIdIsCalledWithInvalidId()
        {
            var customers = _fixture.Build<Customer>()
                .With(x => x.Id, 1)
                .CreateMany(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Customers.Returns(customers);

            var controller = new CustomerController(context);
            var actual = controller.GetCustomerById(2);

            actual.Should().BeNull();
        }

        [Fact]
        public void ReturnOrdersFoundOnCustomerWhenGetCustomerOrdersIsCalled()
        {
            var customer = _fixture.Create<Customer>();
            var expected = _fixture.Build<Order>()
                .With(x => x.CustomerId, customer.Id)
                .CreateMany(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Customers.Returns(new List<Customer> {  customer });
            context.Orders.Returns(expected);

            var controller = new CustomerController(context);
            var actual = controller.GetCustomerOrders(customer.Id);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnEmptyArrayWhenGetCustomerOrdersIsCalledAndHasNoOrders()
        {
            var customer = _fixture.Build<Customer>()
                .With(x => x.Id, 1)
                .Create();
            var orders = _fixture.Build<Order>()
                .With(x => x.CustomerId, 2)
                .CreateMany(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Customers.Returns(new List<Customer> { customer });
            context.Orders.Returns(orders);

            var controller = new CustomerController(context);
            var actual = controller.GetCustomerOrders(customer.Id);

            actual.Should().BeEmpty();
        }

        [Fact]
        public void AddCustomerToDbContextWhenAddCustomerIsCalled()
        {
            var expectedName = "New Customer Name";
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Customers.Returns(new List<Customer>());

            var controller = new CustomerController(context);
            controller.AddCustomer(expectedName);

            context.Customers.First().Name.Should().Be(expectedName);
        }
    }
}

