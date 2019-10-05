using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        [Route("/customer/{id}")]
        public Customer GetCustomerById(int id)
        {
            return GroceryStoreDbContext.Customers.SingleOrDefault(x => x.Id == id);
        }

        [Route("customer/{id}/orders")]
        public Order[] GetCustomerOrders(int id)
        {
            return GroceryStoreDbContext.Orders.Where(x => x.CustomerId == id).ToArray();
        }

        [Route("customer/new/{name}")]
        [HttpPost]
        public void AddCustomer(string name)
        {
            var nextIndex = GroceryStoreDbContext.Customers.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;

            GroceryStoreDbContext.Customers.Add(new Customer
            {
                Id = nextIndex,
                Name = name
            });
            GroceryStoreDbContext.Save();
        }

        //[Route("/customer/{firstName}/{lastName}")]
        //public Customer[] SearchCustomersByName(string firstName, string lastName)
    }
}
