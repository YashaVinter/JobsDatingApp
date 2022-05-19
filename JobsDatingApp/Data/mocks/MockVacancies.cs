using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.mocks
{
    public class MockVacancies : IVacanciesRepository
    {
        private List<Vacancy> _vacancies;
        public MockVacancies()
        {
            _vacancies = DBObjects.Vacancies;
        }
        public IEnumerable<Vacancy> AllVacancies => _vacancies;
        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            return _vacancies.Where(v => v.CompanyId == id);
        }

        public Vacancy FirstVacancy()
        {
            throw new NotImplementedException();
        }

		public Vacancy LastVacancy()
		{
			throw new NotImplementedException();
		}

		public Vacancy NextVacancy(int currentVacancyId)
        {
            throw new NotImplementedException();
        }

		public Vacancy PrevVacancy(int currentVacancyId)
		{
			throw new NotImplementedException();
		}

		public Vacancy VacancyById(int id)
        {
            return _vacancies.First(v => v.Id == id);
        }
        public Vacancy VacancyByName(string name) 
        {
            return _vacancies.First(v => v.Name == name);
        }
    }
}
