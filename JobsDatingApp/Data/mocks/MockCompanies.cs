using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using JobsDatingApp.Data.SeedData;

namespace JobsDatingApp.Data.mocks
{
    public class MockCompanies : ICompaniesRepository
    {
        private List<Company> _companies;
        public MockCompanies(DBSeed seed)
        {
            _companies = seed.Companies;
        }
        public IEnumerable<Company> Companies => _companies;
        public Company CompanyById(int id)
        {
            return _companies.First(c => c.Id == id);
        }
        public Company CompanyByName(string name)
        {
            return _companies.First(c => c.Name == name);
        }
    }
}
