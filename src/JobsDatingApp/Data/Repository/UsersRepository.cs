using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDBContext _context;
        public UsersRepository(AppDBContext context)
        {
            _context = context;
        }
        IEnumerable<User> IUsersRepository.Users(bool hasAllEntities)
        {
            var users = _context.Users;
            if (hasAllEntities){
                _context.Users.Load();
            }
            return users;
        }
        public User UserById(Guid id)
        {
            return _context.Users
                   .Where(u => u.Id == id)
                   .Include(u => u.LastViewedVacancy)
                       .ThenInclude(v => v!.Vacancy)
                           .ThenInclude(v => v!.Company)
                   .Include(u => u.LikedVacancies)
                        !.ThenInclude(v => v!.Company)
                   .First();
        }
        public User? UserByEmail(string email)
        {
            return _context.Users
                   .Where(u => string.Equals(u.Email,email))
                   .Include(u => u.LastViewedVacancy)
                   .FirstOrDefault();
        }
        public bool AddUser(User user)
        {
            if (_context.Users.Contains(user)) { 
                return false;
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUser(User user)
        {
            if (!_context.Users.Contains(user)){
                return false;
            }
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}
