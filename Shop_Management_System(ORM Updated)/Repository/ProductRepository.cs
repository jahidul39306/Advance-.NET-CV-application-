using Shop_Management_System_ORM_Updated_.Models.EF;
using Shop_Management_System_ORM_Updated_.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Management_System_ORM_Updated_.Repository
{
    public class ProductRepository
    {
        static ShopMSEntities db;
        static ProductRepository()
        {
            db = new ShopMSEntities();
        }

        public static ProductModel Get(int Id)
        {
            var p = (from pr in db.Products
                     where pr.Id == Id
                     select pr).FirstOrDefault();
            return new ProductModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            };    
        }

        public static List<ProductModel> GetAll()
        {
            var products = new List<ProductModel>();
            foreach(var pr in db.Products)
            {
                var product = new ProductModel()
                {
                    Id = pr.Id,
                    Name = pr.Name,
                    Price = pr.Price,
                    Description = pr.Description
                };
                products.Add(product);
            }
            return products;
        }
    }
}