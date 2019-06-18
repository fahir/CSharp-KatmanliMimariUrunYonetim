using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.DataAccess.Concrete.Context;
using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles on ur.RoleId equals r.Id
                             where ur.UserId == user.Id
                             select new UserRoleItem
                             {
                                 UserName=user.UserName,
                                 RoleName = r.RoleName,
                                 RoleId=r.Id,
                                 UserRoleId=ur.Id

                             };
                return result.ToList();
            }
        }
    }
}
