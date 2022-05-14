using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;

namespace JobsDatingApp.Data.mocks
{
    public class MockCompanies : ICompaniesRepository
    {
        private List<Company> companies;
        public MockCompanies()
        {
            companies = DBObjects.Companies;
        }
        public IEnumerable<Company> Companies => companies;
        public Company CompanyById(int id)
        {
            return companies.First(c => c.Id == id);
        }
        public Company CompanyByName(string name)
        {
            return companies.First(c => c.Name == name);
        }
    }
}
