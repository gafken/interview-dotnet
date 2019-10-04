using GroceryStoreAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI
{
    //This would normally be through EFCore for data persistance
    //Since the Json is used to simulate a database, I will bypass this setup
    public class GroceryStoreDbContext //: DbContext
    {
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }

        public GroceryStoreDbContext()
        {
            var jsonData = JObject.Parse(GetSeedData());

            Customers = jsonData.GetValue("customers").ToObject<List<Customer>>();
            Orders = jsonData.GetValue("orders").ToObject<List<Order>>();
            Products = jsonData.GetValue("products").ToObject<List<Product>>();
        }

        private string GetSeedData()
        {
            using (var reader = new StreamReader("database.json"))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
