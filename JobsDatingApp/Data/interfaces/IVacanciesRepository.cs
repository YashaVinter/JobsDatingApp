using JobsDatingApp.Models;

namespace JobsDatingApp.Data.interfaces
{
    public interface IVacanciesRepository
    {
        IEnumerable<Vacancy> AllVacancies { get; }
        IEnumerable<Vacancy> AllVacanciesByCompanyId(int id);
        Vacancy VacancyById(int id);
        Vacancy VacancyByName(string name);
    }
}
