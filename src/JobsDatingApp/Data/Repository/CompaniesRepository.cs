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
            _context = context;
        }
        public Company CompanyById(int id)
        {
            return _context.Companies.First(c => c.Id == id);
        }
        public Company CompanyByName(string name)
        {
            return _context.Companies.First(c => string.Equals(c.Name,name));
        }
    }
}
