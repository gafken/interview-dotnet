using System.Collections.Generic;

namespace GroceryStoreAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CusomerId { get; set; }
        public List<Item> Items { get; set; }
    }
}
