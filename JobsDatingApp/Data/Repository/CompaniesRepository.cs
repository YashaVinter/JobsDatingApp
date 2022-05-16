using Microsoft.EntityFrameworkCore;

using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;

namespace JobsDatingApp.Data.Repository
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly AppDBContext context;
        public CompaniesRepository(AppDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Company> Companies => context.Companies.Include(c => c.Vacancies);

        public Company CompanyById(int id)
        {
            return context.Companies.First(c => c.Id == id);
        }

        public Company CompanyByName(string name)
        {
            return context.Companies.First(c => c.Name == name);
        }
    }
}
