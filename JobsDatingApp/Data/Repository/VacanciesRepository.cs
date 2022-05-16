using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsDatingApp.Data.Repository
{
    public class VacanciesRepository : IVacanciesRepository
    {
        private readonly AppDBContext context;
        public VacanciesRepository(AppDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Vacancy> AllVacancies => context.Vacancies.Include(v => v.Company);

        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            return (from v in context.Vacancies
                    where v.CompanyId == id
                    select v)
                   .ToArray();
        }
        public Vacancy VacancyById(int id)
        {
            return context.Vacancies.First(v => v.Id == id);
        }
        public Vacancy VacancyByName(string name)
        {
            return context.Vacancies.First(v => v.Name == name);
        }
    }
}
