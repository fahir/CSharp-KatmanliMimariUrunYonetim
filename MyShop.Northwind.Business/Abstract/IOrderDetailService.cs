using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAll();

        List<OrderDetailItem> GetAllItems();

        OrderDetail Get(int id);

        OrderDetail Add(OrderDetail orderDetail);

        OrderDetail Update(OrderDetail orderDetail);

        void Delete(OrderDetail orderDetail);

    }
}
