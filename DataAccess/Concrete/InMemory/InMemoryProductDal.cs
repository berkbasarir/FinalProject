using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, Sql Server, Postgres, MongoDb
            _products = new List<Product> {
                new Product{ProductID=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ProductID=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitInStock=3},
                new Product{ProductID=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitInStock=2},
                new Product{ProductID=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitInStock=65},
                new Product{ProductID=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            // Lambda p=>p.ProductID == product.ProductID
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;

        }
    }
}
