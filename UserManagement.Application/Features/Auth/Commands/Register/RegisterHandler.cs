using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Validators.Auth;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Result<RegisterResponse>>
    {
        private readonly IGenericRepository<User> _repository;
        public RegisterHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }
        public Task<Result<RegisterResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            var validator=new RegisterValidator();
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new ValidationError(e.ErrorMessage));
                return Task.FromResult(Result<RegisterResponse>.Invalid(errors));
            }

            var users = _repository.GetAll();
            var existingUser = users.FirstOrDefault(u => u.Email == command.Request.Email);
            if (existingUser != null)
                return Task.FromResult(
                    Result<RegisterResponse>.Conflict("Email already exists")
                );

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Request.Password);

            var user = new User
            {
                Name = command.Request.UserName,
                Email = command.Request.Email,
                Password = hashedPassword,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var createdUser = _repository.Add(user);

            var response = new RegisterResponse
            {
                registerDto = new RegisterDto
                {
                    Id = createdUser.Id,
                    Name = createdUser.Name,
                    Email = createdUser.Email
                }
            };
           
            return Task.FromResult(Result.Success(response));
        }
    }
}
