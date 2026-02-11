using Ardalis.Result;
using MediatR;
using UserManagement.Application.Features.Users.Commands.CreateUser;

namespace UserManagement.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Result<CreateUserDTO>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
