using System.Collections.Generic;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.MvcWebUI
{
    public class UserRoleUpdateViewModel
    {
        public UserRole UserRole { get;  set; }
        public List<Role> Roles { get;  set; }
        public User User { get; set; }
    }
}