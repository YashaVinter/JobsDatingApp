using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;

namespace JobsDatingApp.Data.Repository
{
    public class CompaniesRepository : ICompaniesRepository
    {
        public IEnumerable<Company> Companies => throw new NotImplementedException();

        public Company CompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public Company CompanyByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
