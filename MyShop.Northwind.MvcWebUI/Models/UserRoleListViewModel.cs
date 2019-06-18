using MyShop.Northwind.Entities.ComplexTypes;
using System.Collections.Generic;

namespace MyShop.Northwind.MvcWebUI
{
    public class UserRoleListViewModel
    {
        public List<UserRoleItem> UserRoleItemList { get; set; }
        public UserRoleItem UserRoleItem { get; set; }
    }
}