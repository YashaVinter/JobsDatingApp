using JobsDatingApp.Models;

namespace JobsDatingApp.Data.interfaces
{
    public interface ICompaniesRepository
    {
        IEnumerable<Company> Companies { get; }
        Company CompanyById(int id);
        Company CompanyByName(string name);
    }
}
