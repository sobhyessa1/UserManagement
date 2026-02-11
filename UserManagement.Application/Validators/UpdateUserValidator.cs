using FluentValidation;
using UserManagement.Application.Features.Users.Commands.UpdateUser;

namespace UserManagement.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Request.Id)
                .GreaterThan(0)
                .WithMessage("User ID must be greater than 0");

            RuleFor(x => x.Request.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Request.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Request.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters");
        }
    }
}
