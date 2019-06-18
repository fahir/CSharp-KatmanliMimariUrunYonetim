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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(CategoryValidator))]

        public Category Add(Category category)
        {
            return _categoryDal.Add(category);
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(CategoryValidator))]
        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        [FluentValidationAspect(typeof(CategoryValidator))]
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        [SecuredOperation(Roles = "Admin,Editor")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(CategoryValidator))]
        public Category Update(Category category)
        {
            return _categoryDal.Update(category) ;
        }
    }
}
