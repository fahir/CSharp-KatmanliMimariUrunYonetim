using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface IShippingDetailService
    {
        List<ShippingDetail> GetAll();

        ShippingDetail Get(int id);

        ShippingDetail Add(ShippingDetail shippingDetail);

        ShippingDetail Update(ShippingDetail shippingDetail);

        void Delete(ShippingDetail shippingDetail);
    }
}
