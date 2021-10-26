using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Management_System_ORM_Updated_.Models.ViewModel
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int FK_Orders_Id { get; set; }
        public int FK_Products_Id { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
    }
}