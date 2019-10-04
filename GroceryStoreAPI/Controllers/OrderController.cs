using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IGroceryStoreDbContext GroceryStoreDbContext { get; }

        public OrderController(IGroceryStoreDbContext groceryStoreDbContext)
        {
            GroceryStoreDbContext = groceryStoreDbContext;
        }

        [Route("orders")]
        public Order[] GetOrders()
        {
            return GroceryStoreDbContext.Orders.ToArray();
        }
    }
}
