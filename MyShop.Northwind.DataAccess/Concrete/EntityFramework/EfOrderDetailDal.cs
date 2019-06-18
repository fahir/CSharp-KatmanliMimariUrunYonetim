using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.DataAccess.Concrete.Context;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, NorthwindContext>, IOrderDetailDal
    {
        
        public List<OrderDetailItem> GetOrderDetailItems()
        {

            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from o in context.OrderDetail
                             join s in context.ShippingDetails on o.ShippingDetailId equals s.Id
                             join c in context.Carts on o.CartId equals c.Id
                             join u in context.Users on o.UserId equals u.Id

                             select new OrderDetailItem
                             {
                                 OrderDetailId = o.Id,
                                 UserName = u.UserName,
                                 IsCompleted = o.IsCompleted,
                                 List = c.CartList
                             };
                return result.ToList();
            }
        }
    }
}
