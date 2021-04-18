﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ghadir.Models
{
    public class ShopCartItem
    {
        public int ProductID { get; set; }
        public int Count { get; set; }
    }

    public class ShopCartViewModel
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
        public string ImageName { get; set; }

    }
}