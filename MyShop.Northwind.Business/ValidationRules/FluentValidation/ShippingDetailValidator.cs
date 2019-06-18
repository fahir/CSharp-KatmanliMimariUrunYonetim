using FluentValidation;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.Business.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.Address1).NotEmpty();
            RuleFor(s => s.City).NotEmpty();
            RuleFor(s => s.Country).NotEmpty();
            RuleFor(s => s.Name).NotEmpty();

        }
    }
}
