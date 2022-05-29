using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.interfaces
{
    public interface IVacanciesRepository
    {
        IEnumerable<Vacancy> AllVacanciesByCompanyId(int id);
        Vacancy FirstVacancy();
        Vacancy LastVacancy();
        Vacancy NextVacancy(int currentVacancyId);
        Vacancy PrevVacancy(int currentVacancyId);
        Vacancy VacancyById(int id);
        Vacancy VacancyByName(string name);
    }
}
