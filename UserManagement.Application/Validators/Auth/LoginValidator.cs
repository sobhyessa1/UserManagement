using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Auth.Commands.Login;

namespace UserManagement.Application.Validators.Auth
{
    public class LoginValidator:AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Request.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(l => l.Request.Password).NotEmpty().WithMessage("Password is required")
               .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        }
    }
}
