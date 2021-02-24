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
        List<Product> GetAll(); //tümünü getir
        List<Product> GetAllByCategoryId(int id); //kategori id sine göre tümünü getir
        List<Product> GetByUniyPrice(decimal min, decimal max); //fiyata göre getir min - max
        List<ProductDetailDto> GetProductDetails();
        Product GetById(int productId);
        IResult Add(Product product);


    }
}
