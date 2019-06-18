using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category Get(int id);

        Category Add(Category category);

        Category Update(Category category);

        void Delete(Category category);

    }
}
