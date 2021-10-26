using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Management_System_ORM_Updated_.Models.ViewModel
{
    public class OrderModel
    {
        public int Id { get; set; }
        public Nullable<double> Price { get; set; }
        public string Status { get; set; }
    }
}