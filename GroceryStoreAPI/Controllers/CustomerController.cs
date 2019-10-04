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

        public Order[] GetCustomerOrders(int id)
        {
            throw new NotImplementedException();
        }

        //[Route("/customer/{firstName}/{lastName}")]
        //public Customer[] SearchCustomersByName(string firstName, string lastName)
    }
}
