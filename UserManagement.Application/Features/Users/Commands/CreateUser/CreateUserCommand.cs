using Ardalis.Result;
using MediatR;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<CreateUserResponse>>
    {
        public CreateUserRequest Request { get; set; }

        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;
        }
    }
}
