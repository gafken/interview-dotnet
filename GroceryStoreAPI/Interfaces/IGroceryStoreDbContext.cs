using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPI.Interfaces
{
    public interface IGroceryStoreDbContext
    {
        List<Customer> Customers { get; set; }
        List<Order> Orders { get; set; }
        List<Product> Products { get; set; }

        void Save();
    }
}