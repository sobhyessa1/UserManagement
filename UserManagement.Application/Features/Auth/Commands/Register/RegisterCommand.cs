using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand :IRequest<Result<RegisterResponse>>
    {
        public RegisterRequest Request { get; set; }
        public RegisterCommand(RegisterRequest request)
        {
            Request=request;
        }
    }
}
