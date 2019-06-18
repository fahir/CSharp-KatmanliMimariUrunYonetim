using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        List<UserRoleItem> GetUserRoles(User user);
        User Get(int id);
        User GetByUserNameAndPassword(string userName, string password);
        User Add(User user);
        User GetByUserName(string userName);
        User Update(User user);

        void Delete(User user);
    }
}
