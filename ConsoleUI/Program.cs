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

            var resultAll = productManager.GetAll();

            if (resultAll.Success == true)
            {
                foreach (var product in productManager.GetAll().Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(resultAll.Message);
            }



            Console.WriteLine("------------------CATEGORY ID = 2------------------------");

            var resultCategoryId = productManager.GetAllByCategoryId(2);

            if (resultCategoryId.Success == true)
            {
                foreach (var product in productManager.GetAllByCategoryId(2).Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(resultCategoryId.Message);
            }



            Console.WriteLine("------------------PRICE MIN = 40 MAX = 100------------------------");

            var resultPrice = productManager.GetByUnitPrice(40, 100);

            if (resultPrice.Success == true)
            {
                foreach (var product in productManager.GetByUnitPrice(40, 100).Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(resultPrice.Message);
            }


            Console.WriteLine("------------------ProductName + / + CategoryName------------------------");

            var resultCategoryName = productManager.GetProductDetails();

            if (resultCategoryName.Success == true)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(resultCategoryName.Message);
            }        
        }
    }
}
