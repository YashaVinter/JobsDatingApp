using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.SeedData
{
    public interface IDBSeed
    {
        IEnumerable<Company> GetCompanies();
        IEnumerable<Vacancy> GetVacancies();
        IEnumerable<User> GetUsers();
    }
}