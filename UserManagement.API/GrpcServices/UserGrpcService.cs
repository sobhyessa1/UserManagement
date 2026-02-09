using Grpc.Core;
using UserManagement.API.Protos;
using UserManagement.Application.Services;

namespace UserManagement.API.GrpcServices
{
     public class UserGrpcService : UserGrpc.UserGrpcBase
    {
        private readonly IUserService _userService;

        public UserGrpcService(IUserService userService)
        {
            _userService = userService;
        }
        public override Task<UserResponse> GetUserById(GetUserRequest request, ServerCallContext context)
        {
            var userDto = _userService.GetById(request.Id);

            if (userDto == null)
            {
                return Task.FromResult(new UserResponse());
            }

            var response = new UserResponse
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email
            };

            return Task.FromResult(response);
        }

        public override Task<UserExistsResponse> IsUserExists(GetUserRequest request, ServerCallContext context)
        {
            var userDto = _userService.GetById(request.Id);
            var response = new UserExistsResponse
            {
                Exists = userDto != null
            };

            return Task.FromResult(response);
        }
    }
}
