using AutoMapper;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using OZBAY.Core.Aspects.Postsharp.CacheAspects;
using OZBAY.Core.Aspects.Postsharp.ValidationAspects;
using OZBAY.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Concrete.Managers
{
    public class OrderDetailManager : IOrderDetailService
    {
        private IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public OrderDetail Add(OrderDetail orderDetail)
        {
            return _orderDetailDal.Add(orderDetail);
        }
        [SecuredOperation(Roles = "Admin,Editor")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
        }
        [SecuredOperation(Roles = "Admin,Editor")]
        public OrderDetail Get(int id)
        {
            return _orderDetailDal.Get(x => x.Id == id);
        }
        [SecuredOperation(Roles = "Admin,Editor")]
        public List<OrderDetail> GetAll()
        {
            return _orderDetailDal.GetAll();
        }
        [SecuredOperation(Roles = "Admin,Editor")]
        public List<OrderDetailItem> GetAllItems()
        {
            return _orderDetailDal.GetOrderDetailItems();
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public OrderDetail Update(OrderDetail orderDetail)
        {
            return _orderDetailDal.Update(orderDetail);
        }
    }
}
