using Ardalis.Result;
using MediatR;
using UserManagement.Application.Validators;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<UpdateUserResponse>>
    {
        private readonly IGenericRepository<User> _repository;

        public UpdateUserHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<Result<UpdateUserResponse>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            // 1. Validation
            var validator = new UpdateUserValidator();
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new ValidationError(e.ErrorMessage))
                    .ToList();
                return Task.FromResult(Result<UpdateUserResponse>.Invalid(errors));
            }

            // 2. Get existing user
            var existingUser = _repository.GetById(command.Request.Id);
            if (existingUser == null)
                return Task.FromResult(Result<UpdateUserResponse>.NotFound("User not found"));

            // 3. Update fields
            existingUser.Name = command.Request.Name;
            existingUser.Email = command.Request.Email;
            existingUser.Password = command.Request.Password;
            existingUser.UpdatedAt = DateTime.Now;

            var updatedUser = _repository.Update(existingUser);

            // 4. Map to Response
            var response = new UpdateUserResponse
            {
                User = new UpdateUserDTO
                {
                    Id = updatedUser.Id,
                    Name = updatedUser.Name,
                    Email = updatedUser.Email,
                    CreatedAt = updatedUser.CreatedAt,
                    UpdatedAt = updatedUser.UpdatedAt
                }
            };

            return Task.FromResult(Result.Success(response));
        }
    }
}
