using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User Add(User user);
        User Update(User user);
        void Delete(int id);
    }
}
