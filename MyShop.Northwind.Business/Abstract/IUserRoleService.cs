using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface IUserRoleService
    {
        List<UserRole> GetAll();

        List<UserRoleItem> GetAllItems();

        UserRole Get(int id);

        UserRole Add(UserRole userRole);

        UserRole Update(UserRole userRole);

        void Delete(UserRole userRole);
    }
}
