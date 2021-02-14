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


            foreach (var product in productManager.GetByUniyPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
            }



        }
    }
}
