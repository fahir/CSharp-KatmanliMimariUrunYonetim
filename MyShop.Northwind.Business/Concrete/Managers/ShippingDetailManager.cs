using AutoMapper;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Business.ValidationRules.FluentValidation;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using OZBAY.Core.Aspects.Postsharp.CacheAspects;
using OZBAY.Core.Aspects.Postsharp.ValidationAspects;
using OZBAY.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Concrete.Managers
{
    public class ShippingDetailManager : IShippingDetailService
    {
        private IShippingDetailDal _shippingDetailDal;

        public ShippingDetailManager(IShippingDetailDal shippingDetailDal)
        {
            _shippingDetailDal = shippingDetailDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [FluentValidationAspect(typeof(ShippingDetailValidator))]

        public ShippingDetail Add(ShippingDetail shippingDetail)
        {
            return _shippingDetailDal.Add(shippingDetail);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor")]
        [FluentValidationAspect(typeof(ShippingDetailValidator))]
        public void Delete(ShippingDetail shippingDetail)
        {
            _shippingDetailDal.Delete(shippingDetail);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public ShippingDetail Get(int id)
        {
            return _shippingDetailDal.Get(x => x.Id == id);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]

        public List<ShippingDetail> GetAll()
        {
            return _shippingDetailDal.GetAll();
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor")]
        [FluentValidationAspect(typeof(ShippingDetailValidator))]
        public ShippingDetail Update(ShippingDetail shippingDetail)
        {
            return _shippingDetailDal.Update(shippingDetail);
        }
    }
}
