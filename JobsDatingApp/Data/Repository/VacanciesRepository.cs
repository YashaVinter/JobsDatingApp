using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;

namespace JobsDatingApp.Data.Repository
{
    public class VacanciesRepository : IVacanciesRepository
    {
        public IEnumerable<Vacancy> AllVacancies => throw new NotImplementedException();

        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            throw new NotImplementedException();
        }

        public Vacancy VacancyById(int id)
        {
            throw new NotImplementedException();
        }

        public Vacancy VacancyByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
