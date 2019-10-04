using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
