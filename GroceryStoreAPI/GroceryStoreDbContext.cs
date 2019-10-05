using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace GroceryStoreAPI
{
    //This would normally be through EFCore for data persistance
    //Since the Json is used to simulate a database, I will bypass this setup
    public class GroceryStoreDbContext : IGroceryStoreDbContext //: DbContext
    {
        private JObject _jsonData { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }

        public GroceryStoreDbContext()
        {
            _jsonData = JObject.Parse(GetSeedData());

            Customers = _jsonData.GetValue("customers").ToObject<List<Customer>>();
            Orders = _jsonData.GetValue("orders").ToObject<List<Order>>();
            Products = _jsonData.GetValue("products").ToObject<List<Product>>();
        }

        public void Save()
        {
            Customers.Add(new Customer
            {
                Id = 345,
                Name = "Idk"
            });
            _jsonData["customers"] = JsonConvert.SerializeObject(Customers);
            _jsonData["orders"] = JsonConvert.SerializeObject(Orders);
            _jsonData["products"] = JsonConvert.SerializeObject(Products);

            using (var writer = new StreamWriter("database.json", false))
            {
                writer.Write(_jsonData);
            }
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
