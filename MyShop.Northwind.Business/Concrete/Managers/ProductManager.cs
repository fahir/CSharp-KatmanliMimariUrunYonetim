using AutoMapper;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Business.ValidationRules.FluentValidation;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.Aspects.Postsharp.CacheAspects;
using OZBAY.Core.Aspects.Postsharp.TransactionAspects;
using OZBAY.Core.Aspects.Postsharp.ValidationAspects;
using OZBAY.Core.CrossCuttingConcerns.Caching.Microsoft;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor")]

        public Product Add(Product product)
        {
            return  _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor")]
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]

        public Product Get(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin,Editor")]
        public Product Update(Product product)
        {
            return  _productDal.Update(product);
        }
    }
}
