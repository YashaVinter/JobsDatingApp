using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data.Repository
{
    public class VacanciesRepository : IVacanciesRepository
    {
        private readonly AppDBContext _context;
        public VacanciesRepository(AppDBContext context)
        {
            this._context = context;
        }
        public IEnumerable<Vacancy> AllVacancies => _context.Vacancies.Include(v => v.Company);

        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            return (from v in _context.Vacancies
                    where v.CompanyId == id
                    select v)
                   .ToArray();
        }
        public Vacancy VacancyById(int id)
        {
            return _context.Vacancies.Where(v => v.Id == id).Include(v => v.Company).First();
        }
        public Vacancy FirstVacancy() 
        {
            int vacancyId = _context.Vacancies.Min(v => v.Id);
            return _context.Vacancies.Where(v => v.Id == vacancyId).Include(v => v.Company).First();
        }
        public Vacancy LastVacancy()
        {
            int vacancyId = _context.Vacancies.Max(v => v.Id);
            return _context.Vacancies.Where(v => v.Id == vacancyId).Include(v => v.Company).First();
        }
        public Vacancy NextVacancy(int currentVacancyId)
        {
			if (_context.Vacancies.Count() == currentVacancyId)
			{
                return FirstVacancy();
			}
            return _context.Vacancies.Skip(currentVacancyId).Include(v => v.Company).First();
        }
        public Vacancy PrevVacancy(int currentVacancyId)
        {
            if (currentVacancyId == 1)
            {
                return LastVacancy();
            }
            return _context.Vacancies.Skip(currentVacancyId-2).Include(v => v.Company).First();
        }
        public Vacancy VacancyByName(string name)
        {
            return _context.Vacancies.First(v => v.Name == name);
        }
    }
}
