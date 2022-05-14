using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;

namespace JobsDatingApp.Data.mocks
{
    public class MockVacancies : IVacanciesRepository
    {
        private List<Vacancy> vacancies;
        public MockVacancies()
        {
            vacancies = DBObjects.Vacancies;
        }
        public IEnumerable<Vacancy> AllVacancies => vacancies;
        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            return vacancies.Where(v => v.CompanyId == id);
        }
        public Vacancy VacancyById(int id)
        {
            return vacancies.First(v => v.Id == id);
        }
        public Vacancy VacancyByName(string name) 
        {
            return vacancies.First(v => v.Name == name);
        }
    }
}
