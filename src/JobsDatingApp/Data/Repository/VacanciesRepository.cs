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
            _context = context;
        }
        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            return (from v in _context.Vacancies
                    where v.CompanyId == id
                    select v)
                   .ToArray();
        }
        public Vacancy VacancyById(int id)
        {
            return _context.Vacancies
                   .Where(v => v.Id == id)
                   .Include(v => v.Company)
                   .First();
        }
        public Vacancy VacancyByName(string name)
        {
            return _context.Vacancies.First(v => string.Equals(v.Name, name));
        }
        public Vacancy FirstVacancy() 
        {
            int vacancyId = _context.Vacancies.Min(v => v.Id);
            return _context.Vacancies
                   .Where(v => v.Id == vacancyId)
                   .Include(v => v.Company)
                   .First();
        }
        public Vacancy LastVacancy()
        {
            int vacancyId = _context.Vacancies.Max(v => v.Id);
            return _context.Vacancies
                   .Where(v => v.Id == vacancyId)
                   .Include(v => v.Company)
                   .First();
        }
        public Vacancy NextVacancy(int currentVacancyId)
        {
            var next = (from v in _context.Vacancies
                        where v.Id > currentVacancyId
                        orderby v.Id ascending
                        select v)
                       .Include(v => v.Company)
                       .FirstOrDefault();
            return next ?? FirstVacancy();
        }
        public Vacancy PrevVacancy(int currentVacancyId)
        {
            var prev = (from v in _context.Vacancies
                        where v.Id < currentVacancyId
                        orderby v.Id descending
                        select v)
                       .Include(v => v.Company)
                       .FirstOrDefault();
            return prev ?? LastVacancy();
        }

    }
}
