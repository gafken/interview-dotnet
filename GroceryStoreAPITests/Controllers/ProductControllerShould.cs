using AutoFixture;
using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GroceryStoreAPITests.Controllers
{
    public class ProductControllerShould
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void GetAllProductsWhenGetProductsIsCalled()
        {
            var expected = _fixture.CreateMany<Product>(5).ToList();
            var context = Substitute.For<IGroceryStoreDbContext>();
            context.Products.Returns(expected);

            var controller = new ProductController(context);
            var actual = controller.GetProducts();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
