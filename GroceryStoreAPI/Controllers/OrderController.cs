using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        [Route("orders/{dateTime}")]
        public Order[] GetOrdersByDate(DateTime queryDate)
        {
            return GroceryStoreDbContext.Orders.Where(x => x.OrderDate.Date == queryDate.Date).ToArray();
        }
    }
}
