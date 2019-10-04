using FluentAssertions;
using GroceryStoreAPI;
using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace GroceryStoreAPITests
{
    public class GroceryStoreDbContextShould
    {
        [Fact]
        public void SetPropertiesOnInitialization()
        {
            var context = new GroceryStoreDbContext();
            context.Customers.Should().BeEquivalentTo(new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Bob"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mary"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Joe"
                }
            });

            context.Products.Should().BeEquivalentTo(new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Description = "apple",
                    Price = 0.5m
                },
                new Product
                {
                    Id = 2,
                    Description = "orange",
                    Price = 0.75m
                },
                new Product
                {
                    Id = 3,
                    Description = "banana",
                    Price = 0.85m
                }
            });

            context.Orders.Should().BeEquivalentTo(new List<Order>
            {
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Parse("2012-04-23T18:25:43.511"),
                    Items = new List<Item>
                    {
                        new Item
                        {
                            ProductId = 1,
                            Quantity = 2
                        },
                        new Item
                        {
                            ProductId = 2,
                            Quantity = 3
                        }
                    }
                }
            });
        }
    }
}
