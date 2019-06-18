using AutoMapper;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using OZBAY.Core.Aspects.Postsharp.CacheAspects;
using OZBAY.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Concrete.Managers
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Cart Add(Cart cart)
        {
            return _cartDal.Add(cart);
        }
        [SecuredOperation(Roles = "Admin,Editor")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Cart cart)
        {
            _cartDal.Delete(cart);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Cart Get(int id)
        {
            return _cartDal.Get(x => x.Id == id);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Cart> GetAll()
        {
            return _cartDal.GetAll();
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Cart Update(Cart cart)
        {
            return _cartDal.Update(cart);
        }
    }
}
