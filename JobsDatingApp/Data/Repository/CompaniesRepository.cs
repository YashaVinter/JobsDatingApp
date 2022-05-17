using Microsoft.EntityFrameworkCore;

using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.Repository
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly AppDBContext _context;
        public CompaniesRepository(AppDBContext context)
        {
            this._context = context;
        }
        public IEnumerable<Company> Companies => _context.Companies.Include(c => c.Vacancies);

        public Company CompanyById(int id)
        {
            return _context.Companies.First(c => c.Id == id);
        }

        public Company CompanyByName(string name)
        {
            return _context.Companies.First(c => c.Name == name);
        }
    }
}
