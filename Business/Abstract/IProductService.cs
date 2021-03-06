using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //tümünü getir
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    
        IDataResult<List<Product>> GetAllByCategoryId(int id); //kategori id sine göre tümünü getir
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); //fiyata göre getir min - max
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult AddTransactionalTest(Product product);

    }
}
