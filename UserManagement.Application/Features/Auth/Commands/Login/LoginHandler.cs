using Ardalis.Result;
using MediatR;
using UserManagement.Application.Services;
using UserManagement.Application.Validators.Auth;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        private readonly IGenericRepository<User> _repository;
        private readonly ITokenService _tokenService;
        public LoginHandler(IGenericRepository<User> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        public Task<Result<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var validator = new LoginValidator();
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new ValidationError(e.ErrorMessage))
                    .ToList();
                return Task.FromResult(Result<LoginResponse>.Invalid(errors));
            }

            var users = _repository.GetAll();
            var user = users.FirstOrDefault(u => u.Email == command.Request.Email);
            if (user == null)
                return Task.FromResult(
                    Result<LoginResponse>.NotFound("Invalid email or password")
                );


            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                command.Request.Password, user.Password
            );
            if (!isPasswordValid)
                return Task.FromResult(
                    Result<LoginResponse>.NotFound("Invalid email or password")
                );


            var token = _tokenService.GenerateToken(user.Id, user.Name, user.Email);

            var response = new LoginResponse
            {
                LoginDto = new LoginResponseDto
                {
                    Token = token,
                    UserName = user.Name
                }
            };
            return Task.FromResult(Result.Success(response));
        }
    }
}
