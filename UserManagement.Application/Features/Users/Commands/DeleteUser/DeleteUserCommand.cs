using Ardalis.Result;
using MediatR;

namespace UserManagement.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
