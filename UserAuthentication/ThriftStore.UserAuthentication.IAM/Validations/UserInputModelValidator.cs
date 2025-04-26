using FluentValidation;
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;

namespace ThriftStore.UserAuthentication.IAM.Validations
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
