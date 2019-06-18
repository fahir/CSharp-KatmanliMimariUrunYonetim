using AutoMapper;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.Aspects.Postsharp.AuthorizationAspects;
using OZBAY.Core.Aspects.Postsharp.CacheAspects;
using OZBAY.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Concrete.Managers
{
    public class UserRoleManager : IUserRoleService
    {
        private IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin")]
        public UserRole Add(UserRole userRole)
        {
            return _userRoleDal.Add(userRole);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin")]
        public void Delete(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
        }

        public UserRole Get(int id)
        {
            return _userRoleDal.Get(x => x.Id == id);
        }
        [SecuredOperation(Roles = "Admin")]
        public List<UserRole> GetAll()
        {
            return _userRoleDal.GetAll();
        }
        [SecuredOperation(Roles = "Admin")]

        public List<UserRoleItem> GetAllItems()
        {
            return _userRoleDal.GetUserRoleItems();
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin")]

        public UserRole Update(UserRole userRole)
        {
            return _userRoleDal.Update(userRole);

        }
    }
}
