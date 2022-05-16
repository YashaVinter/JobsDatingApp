using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDBContext context;
        public UsersRepository(AppDBContext context)
        {
            this.context = context;
        }
        IEnumerable<User> IUsersRepository.Users(bool hasAllEntities)
        {
            var users = context.Users;
            if (hasAllEntities){
                context.Users.Load();
            }
            return users;
        }
        public User UserById(Guid id)
        {
            var user = context.Users.Where(u => u.Id == id);
            user.Load();
            return user.First();
        }
        public bool AddUser(User user)
        {
            if (context.Users.Contains(user)) { 
                return false;
            }
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool UpdateUser(User user)
        {
            if (!context.Users.Contains(user)){
                return false;
            }
            context.Users.Update(user);
            context.SaveChanges();
            return true;
        }


    }
}
