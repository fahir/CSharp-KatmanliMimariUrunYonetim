using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess;
using System.Collections.Generic;

namespace MyShop.Northwind.DataAccess.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
         List<OrderDetailItem> GetOrderDetailItems();
        

    }
}
