using MyShop.Northwind.Entities.ComplexTypes;
using MyShop.Northwind.Entities.Concrete;
using OZBAY.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyShop.Northwind.DataAccess.Abstract
{
    public interface IUserRoleDal : IEntityRepository<UserRole>
    {
        List<UserRoleItem> GetUserRoleItems(Expression<Func<UserRole, bool>> filter = null);

    }
}
