using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result<LoginResponse>>
    {
        public LoginRequest Request { get; set; }
        public LoginCommand(LoginRequest request)
        {
            Request = request;
        }
    }
}
