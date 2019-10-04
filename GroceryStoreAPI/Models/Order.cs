using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Item> Items { get; set; }
    }
}
