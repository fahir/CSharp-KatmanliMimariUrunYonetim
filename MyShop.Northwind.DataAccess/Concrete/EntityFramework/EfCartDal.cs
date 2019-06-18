using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.DataAccess.Concrete.Context;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess.EntityFramework;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, NorthwindContext>, ICartDal
    {
    }
}
