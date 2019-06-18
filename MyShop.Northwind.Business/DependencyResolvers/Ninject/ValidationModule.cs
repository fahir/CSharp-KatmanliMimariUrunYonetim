using FluentValidation;
using MyShop.Northwind.Business.ValidationRules.FluentValidation;
using MyShop.Northwind.Entities.Concrete;
using Ninject.Modules;

namespace MyShop.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Category>>().To<CategoryValidator>().InSingletonScope();
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
            Bind<IValidator<ShippingDetail>>().To<ShippingDetailValidator>().InSingletonScope();
            Bind<IValidator<User>>().To<UserValidator>().InSingletonScope();
        }
    }
}
