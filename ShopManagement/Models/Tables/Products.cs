using ShopManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopManagement.Models.Tables
{
    public class Products
    {
        SqlConnection conn;

        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Create(Product p)
        {
            conn.Open();
            string query = string.Format("insert into Product values ('{0}', {1}, {2}, '{3}')", p.Name, p.Qty, p.Price, p.Desc);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();
            conn.Open();
            string query = "select * from Product";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader(); 
            while(reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = reader.GetDouble(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Description"))
                };
                products.Add(p);
            }
            conn.Close();
            return products;
        }


        public Product Get(int Id)
        {
            Product product = new Product();
            conn.Open();
            string query = string.Format("select * from Product where Id = {0}", Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = reader.GetDouble(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Description"))
                };
                product = p;
            }
            conn.Close();
            return product;
        }

        public void Edit(Product p)
        {
            conn.Open();
            string query = string.Format("update Product set Name = '{0}', Qty = {1}, Price = {2}, Description = '{3}' where Id = {4}", p.Name, p.Qty, p.Price, p.Desc, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int Id)
        {
            conn.Open();
            string query = string.Format("delete from Product where Id = {0}", Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}