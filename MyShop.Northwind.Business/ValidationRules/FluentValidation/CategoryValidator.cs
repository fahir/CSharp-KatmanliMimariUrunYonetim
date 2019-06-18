using FluentValidation;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty();
            RuleFor(c => c.CategoryName).Length(3, 15);
            RuleFor(c => c.Picture).NotEmpty();
        }
    }
}
