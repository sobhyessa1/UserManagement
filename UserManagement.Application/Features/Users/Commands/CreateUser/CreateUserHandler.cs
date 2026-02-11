using Ardalis.Result;
using MediatR;
using UserManagement.Application.Validators;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
    {
        private readonly IGenericRepository<User> _repository;

        public CreateUserHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<Result<CreateUserResponse>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            // 1. Validation
            var validator = new CreateUserValidator();
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new ValidationError(e.ErrorMessage))
                    .ToList();
                return Task.FromResult(Result<CreateUserResponse>.Invalid(errors));
            }

            // 2. Create User
            var user = new User
            {
                Name = command.Request.Name,
                Email = command.Request.Email,
                Password = command.Request.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var createdUser = _repository.Add(user);

            // 3. Map to Response
            var response = new CreateUserResponse
            {
                User = new CreateUserDTO
                {
                    Id = createdUser.Id,
                    Name = createdUser.Name,
                    Email = createdUser.Email,
                    CreatedAt = createdUser.CreatedAt,
                    UpdatedAt = createdUser.UpdatedAt
                }
            };

            return Task.FromResult(Result.Success(response));
        }
    }
}
