using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product Get(int id);

        Product Add(Product product);

        Product Update(Product product);

        void Delete(Product product);

        void TransactionalOperation(Product product1, Product product2);

    }
}
