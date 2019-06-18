using OZBAY.Core.DataAccess.EntityFramework;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.Concrete;
using MyShop.Northwind.DataAccess.Concrete.Context;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }



}
