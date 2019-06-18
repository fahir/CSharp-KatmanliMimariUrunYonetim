using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess;

namespace MyShop.Northwind.DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
    }
}
