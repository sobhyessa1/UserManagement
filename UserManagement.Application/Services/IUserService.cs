using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        UserDto Create(CreateUserDto dto);
        UserDto Update(int id, CreateUserDto dto);
        void Delete(int id);
    }
}
