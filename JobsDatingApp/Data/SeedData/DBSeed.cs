using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.SeedData
{
    public class DBSeed
    {
        public  List<Company> Companies { get; set; }
        public  List<Vacancy> Vacancies { get; set; }
        public  List<User> Users { get; set; }
        public DBSeed(IDBSeed iDBSeed)
        {
            Companies = iDBSeed.GetCompanies().ToList();
            Vacancies = iDBSeed.GetVacancies().ToList();
            Users = iDBSeed.GetUsers().ToList();
            BindCompaniesAndVacanies();
        }
        private void BindCompaniesAndVacanies()
        {
            foreach (var bindingVacancy in Vacancies)
            {
                var bindingCompany = Companies.First(c => c.Id == bindingVacancy.CompanyId);
                bindingVacancy.Company = bindingCompany;
                bindingCompany.Vacancies.Add(bindingVacancy);
            }
        }
        private void NullingEntities()
        {
            foreach (var c in Companies)
            {
                c.Vacancies = null;
            }
            foreach (var v in Vacancies)
            {
                v.Company = null;
            }
            foreach (var u in Users)
            {
                u.LastViewedVacancy = null;
                u.LikedVacancies = null;
            }
        }
    }
}
