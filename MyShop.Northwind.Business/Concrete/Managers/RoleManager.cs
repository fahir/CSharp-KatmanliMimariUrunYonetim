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
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        [SecuredOperation(Roles = "Admin")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Role Add(Role role)
        {
            return  _roleDal.Add(role);
        }
        [SecuredOperation(Roles = "Admin")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Role role)
        {
            _roleDal.Delete(role);
        }

        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public Role Get(int id)
        {
            return  _roleDal.Get(x => x.Id == id);
        }

        [SecuredOperation(Roles = "Admin")]
        public List<Role> GetAll()
        {
            return _roleDal.GetAll();
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin")]

        public Role Update(Role role)
        {
            return  _roleDal.Update(role);
        }
    }
}
