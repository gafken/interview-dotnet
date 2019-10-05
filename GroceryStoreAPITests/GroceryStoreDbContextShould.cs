using FluentAssertions;
using GroceryStoreAPI;
using GroceryStoreAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace GroceryStoreAPITests
{
    public class GroceryStoreDbContextShould
    {
        [Fact]
        public void SetPropertiesOnInitialization()
        {
            JObject jsonData = null;
            using (var reader = new StreamReader("database.json"))
            {
                jsonData = JObject.Parse(reader.ReadToEnd());
            }

            var context = new GroceryStoreDbContext();

            context.Customers.Should().NotBeEmpty();
            context.Customers.Should().BeEquivalentTo(
                jsonData.GetValue("customers").ToObject<List<Customer>>());

            context.Products.Should().NotBeEmpty();
            context.Products.Should().BeEquivalentTo(
                jsonData.GetValue("products").ToObject<List<Product>>());

            context.Orders.Should().NotBeEmpty();
            context.Orders.Should().BeEquivalentTo(
                jsonData.GetValue("orders").ToObject<List<Order>>());
        }

        [Fact]
        public void X()
        {
            new GroceryStoreDbContext().Save();
        }
    }
}
