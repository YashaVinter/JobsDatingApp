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
            var vacancy = _context.Vacancies.First();
            vacancy = _context.Vacancies.Where(v => v.Id == vacancy.Id).Include(v => v.Company).First();
            return vacancy;
        }
        public Vacancy NextVacancy(int currentVacancyId) 
        {
            return _context.Vacancies.Skip(currentVacancyId).Include(v => v.Company).First();
        }
        public Vacancy VacancyByName(string name)
        {
            return _context.Vacancies.First(v => v.Name == name);
        }
    }
}
