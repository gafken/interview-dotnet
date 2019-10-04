﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
