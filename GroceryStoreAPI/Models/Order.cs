using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CusomerId { get; set; }
        public List<Item> Items { get; set; }
    }
}
