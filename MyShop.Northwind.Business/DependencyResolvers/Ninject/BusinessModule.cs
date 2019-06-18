using MyShop.Northwind.Business.Abstract;
using MyShop.Northwind.Business.Concrete.Managers;
using MyShop.Northwind.DataAccess.Abstract;
using MyShop.Northwind.DataAccess.Concrete.Context;
using MyShop.Northwind.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;

namespace MyShop.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<NorthwindContext>().InSingletonScope();
           
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope();
            Bind<IUserRoleDal>().To<EfUserRoleDal>().InSingletonScope();
            Bind<IShippingDetailService>().To<ShippingDetailManager>().InSingletonScope();
            Bind<IShippingDetailDal>().To<EfShippingDetailDal>().InSingletonScope();
            Bind<ICartService>().To<CartManager>().InSingletonScope();
            Bind<ICartDal>().To<EfCartDal>().InSingletonScope();
            Bind<IOrderDetailService>().To<OrderDetailManager>().InSingletonScope();
            Bind<IOrderDetailDal>().To<EfOrderDetailDal>().InSingletonScope();
        }
    }
}
