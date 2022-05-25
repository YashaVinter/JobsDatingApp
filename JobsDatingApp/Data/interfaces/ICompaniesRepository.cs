using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.interfaces
{
    public interface ICompaniesRepository
    {
        Company CompanyById(int id);
        Company CompanyByName(string name);
    }
}
