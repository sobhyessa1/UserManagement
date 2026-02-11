using Ardalis.Result;
using MediatR;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<CreateUserDTO>>>
    {
        private readonly IGenericRepository<User> _repository;

        public GetAllUsersQueryHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<Result<List<CreateUserDTO>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = _repository.GetAll();

            var userDtos = new List<CreateUserDTO>();
            foreach (var user in users)
            {
                userDtos.Add(new CreateUserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt
                });
            }

            return Task.FromResult(Result.Success(userDtos));
        }
    }
}
