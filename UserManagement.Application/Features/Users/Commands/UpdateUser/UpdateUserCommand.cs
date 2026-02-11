using Ardalis.Result;
using MediatR;

namespace UserManagement.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result<UpdateUserResponse>>
    {
        public UpdateUserRequest Request { get; set; }

        public UpdateUserCommand(UpdateUserRequest request)
        {
            Request = request;
        }
    }
}
