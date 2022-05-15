using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;

namespace JobsDatingApp.Data.mocks
{
    public class MockUsers : IUsersRepository
    {
        private readonly List<User> users;
        public MockUsers()
        {
            users = DBObjects.Users;
        }
        public IEnumerable<User> Users => users;
        public User UserById(Guid id)
        {
            return users.First(u => u.Id == id);
        }
    }
}
