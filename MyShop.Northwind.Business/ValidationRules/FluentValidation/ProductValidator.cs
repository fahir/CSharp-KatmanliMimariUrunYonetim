using FluentValidation;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().Length(3, 40);
            RuleFor(p => p.QuantityPerUnit).MaximumLength(20);
            RuleFor(p => p.UnitPrice).GreaterThan(0);
        }
    }
}
