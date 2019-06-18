using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OZBAY.Core.DataAccess.EntityFramework;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.Entities.ComplexTypes;
using System.Linq;
using MyShop.Northwind.DataAccess.Concrete.Context;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products.Where(filter)
                             join c in context.Categories on p.CategoryId equals c.Id
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}