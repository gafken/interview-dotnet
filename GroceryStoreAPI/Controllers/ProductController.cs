using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IGroceryStoreDbContext GroceryStoreDbContext { get; }

        public ProductController(IGroceryStoreDbContext groceryStoreDbContext)
        {
            GroceryStoreDbContext = groceryStoreDbContext;
        }

        [Route("products")]
        public Product[] GetProducts()
        {
            return GroceryStoreDbContext.Products.ToArray();
        }

        [Route("product/{id}")]
        public object GetProductById(int id)
        {
            return GroceryStoreDbContext.Products.SingleOrDefault(x => x.Id == id);
        }

        [Route("product/new/{description}/{price}")]
        public void AddProduct(string description, decimal price)
        {
            var nextIndex = GroceryStoreDbContext.Products.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;

            GroceryStoreDbContext.Products.Add(new Product
            {
                Id = nextIndex,
                Description = description,
                Price = price
            });
            GroceryStoreDbContext.Save();
        }
    }
}
