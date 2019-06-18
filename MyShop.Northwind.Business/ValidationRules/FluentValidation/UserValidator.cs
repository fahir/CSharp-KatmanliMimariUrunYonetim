using FluentValidation;
using MyShop.Northwind.Entities.Concrete;

namespace MyShop.Northwind.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty().Length(3, 25);
            RuleFor(u => u.Hashword).NotEmpty().MinimumLength(6);
            RuleFor(u => u.LastName).NotEmpty().Length(3, 50);
            RuleFor(u => u.UserName).NotEmpty().Length(3, 15);
        }
    }
}
