using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public object GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
