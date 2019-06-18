using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface ICartService
    {
        List<Cart> GetAll();

        Cart Get(int id);

        Cart Add(Cart cart);

        Cart Update(Cart cart);

        void Delete(Cart cart);
    }
}
