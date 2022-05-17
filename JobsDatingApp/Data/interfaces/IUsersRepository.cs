using JobsDatingApp.Models;

namespace JobsDatingApp.Data.interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> Users(bool hasAllEntities = false);
        User? UserById(Guid id);
        User? UserByEmail(string email);
        bool AddUser(User user);
        bool UpdateUser(User user);
        Task<bool> UpdateUserAsync(User user);
    }
}
