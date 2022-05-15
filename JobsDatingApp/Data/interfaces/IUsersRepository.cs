using JobsDatingApp.Models;

namespace JobsDatingApp.Data.interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> Users { get; }
        User UserById(Guid id);
        //User UserByLogin(string login);
    }
}
