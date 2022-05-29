using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.SeedData;

namespace JobsDatingApp.Data.mocks
{
    public class MockUsers : IUsersRepository
    {
        private readonly List<User> _users;
        public MockUsers(DBSeed seed)
        {
            _users = seed.Users;
        }
        IEnumerable<User> IUsersRepository.Users(bool hasAllEntities)
        {
            return _users;
        }

        public User UserById(Guid id)
        {
            return _users.First(u => u.Id == id);
        }
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User? UserByEmail(string email)
        {
            return _users.FirstOrDefault(u => string.Equals(u.Email,email));
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
