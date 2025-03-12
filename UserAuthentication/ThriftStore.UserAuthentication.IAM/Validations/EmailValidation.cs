using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ThriftStore.UserAuthentication.IAM.Constants;

namespace ThriftStore.UserAuthentication.IAM.Validations
{
    public class EmailValidation : ValidationAttribute
    {
        private readonly string _regexPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string email)
            {
                if (!Regex.IsMatch(email, _regexPattern))
                    return new ValidationResult(ModelErrorConstant.EmailNotValid);
            }

            return ValidationResult.Success;
        }
    }
}
