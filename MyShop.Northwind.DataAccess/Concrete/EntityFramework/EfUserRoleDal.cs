using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.DataAccess.Concrete.Context;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole, NorthwindContext>, IUserRoleDal
    {
       

        public List<UserRoleItem> GetUserRoleItems(Expression<Func<UserRole, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                             join u in context.Users on ur.UserId equals u.Id
                             join r in context.Roles on ur.RoleId equals r.Id

                             select new UserRoleItem
                             {
                                 RoleId = r.Id,
                                 UserId = u.Id,
                                 Id = ur.Id,
                                 RoleName = r.RoleName,
                                 UserName = u.UserName
                             };
                return result.ToList();
            }
        }

    }
}
