using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
    }
}