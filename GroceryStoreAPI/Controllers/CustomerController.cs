using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public IGroceryStoreDbContext GroceryStoreDbContext { get; }

        public CustomerController(IGroceryStoreDbContext groceryStoreDbContext)
        {
            GroceryStoreDbContext = groceryStoreDbContext;
        }

        [Route("/customers")]
        public Customer[] GetCustomers()
        {
            return GroceryStoreDbContext.Customers.ToArray();
        }
    }
}
