using AutoMapper;
using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Business.ValidationRules.FluentValidation;
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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [FluentValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public User Add(User user)
        {
            return _userDal.Add(user);
        }

        [FluentValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin")]
        public void Delete(User user)
        {
            _userDal.Delete(user);
        }
        [SecuredOperation(Roles = "Admin,Editor,Student")]

        public User Get(int id)
        {
            return _userDal.Get(x => x.Id == id);
        }
        [SecuredOperation(Roles = "Admin")]

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(u => u.UserName == userName);

        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName && u.Hashword == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }

        [FluentValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Admin")]

        public User Update(User user)
        {
            return _userDal.Update(user);
        }
    }
}
