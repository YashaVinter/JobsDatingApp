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
        IEnumerable<User> IUsersRepository.Users(bool hasAllEntities)
        {
            return users;
        }

        public User UserById(Guid id)
        {
            return users.First(u => u.Id == id);
        }
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }


    }
}
