using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        [Route("orders/{year}/{month}/{day}")]
        public Order[] GetOrdersByDate(int year, int month, int day)
        {
            return GroceryStoreDbContext.Orders.Where(x => 
                x.OrderDate.Year == year &&
                x.OrderDate.Month == month &&
                x.OrderDate.Day == day)
                .ToArray();
        }

        [Route("orders/{id}")]
        public Order GetOrdersById(int id)
        {
            return GroceryStoreDbContext.Orders.SingleOrDefault(x => x.Id == id);
        }
    }
}
