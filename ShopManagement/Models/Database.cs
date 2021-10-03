using ShopManagement.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Orders Orders { get; set; }

        public Database()
        {
            string ConnString = @"Server = LAPTOP-V5SVLA1P; Database = ShopMS; User ID = sa; Password = 12345";
            conn = new SqlConnection(ConnString);
            Products = new Products(conn);
            Orders = new Orders(conn);
        }
    }
}