using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAll()
        {
            var users = _userRepository.GetAll();

            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var dto = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt
                };
                userDtos.Add(dto);
            }

            return userDtos;
        }

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return userDto;
        }

        public UserDto Create(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var createdUser = _userRepository.Add(user);

            var userDto = new UserDto
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                CreatedAt = createdUser.CreatedAt,
                UpdatedAt = createdUser.UpdatedAt
            };

            return userDto;
        }

        public UserDto Update(int id, CreateUserDto dto)
        {
            var existingUser = _userRepository.GetById(id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;
            existingUser.Password = dto.Password;
            existingUser.UpdatedAt = DateTime.Now;

            _userRepository.Update(existingUser);

            var userDto = new UserDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                Email = existingUser.Email,
                CreatedAt = existingUser.CreatedAt,
                UpdatedAt = existingUser.UpdatedAt
            };

            return userDto;
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
