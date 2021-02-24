using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle - Yazılıma yeni özellik eklerken mevcut kodlara dokunamazsın.
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //Ioc
            //CategoryTest();
            //DTO - Data Transformation Object



        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


            Console.WriteLine("------------------ALL------------------------");


            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());


            Console.WriteLine("------------------ALL------------------------");


            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }


            Console.WriteLine("------------------CATEGORY ID = 2------------------------");


            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }


            Console.WriteLine("------------------PRICE MIN = 40 MAX = 100------------------------");


            foreach (var product in productManager.GetByUniyPrice(40, 100))
            {
                Console.WriteLine(product.ProductName);
            }


            Console.WriteLine("------------------ProductName + CategoryName------------------------");


            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }
    }
}
