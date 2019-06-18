using MyShop.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace MyShop.Northwind.Business.Abstract
{
    public interface IRoleService
    {
        List<Role> GetAll();

        Role Get(int id);

        Role Add(Role role);

        Role Update(Role role);

        void Delete(Role role);
    }
}
