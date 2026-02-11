using Ardalis.Result;
using MediatR;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<CreateUserDTO>>
    {
        private readonly IGenericRepository<User> _repository;

        public GetUserByIdQueryHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<Result<CreateUserDTO>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(query.Id);
            if (user == null)
                return Task.FromResult(Result<CreateUserDTO>.NotFound("User not found"));

            var dto = new CreateUserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return Task.FromResult(Result.Success(dto));
        }
    }
}
