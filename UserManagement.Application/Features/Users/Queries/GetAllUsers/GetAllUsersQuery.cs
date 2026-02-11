using Ardalis.Result;
using MediatR;
using UserManagement.Application.Features.Users.Commands.CreateUser;

namespace UserManagement.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<Result<List<CreateUserDTO>>>
    {
    }
}
