using FluentValidation;
using UserManagement.Application.Features.Auth.Commands.Register;

namespace UserManagement.Application.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Request.UserName)
                .NotEmpty().WithMessage("User name is required.")
                .MinimumLength(3).WithMessage("User name must be at least 3 characters long.");
            RuleFor(x => x.Request.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Request.Password).NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
