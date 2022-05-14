using JobsDatingApp.Models;

namespace JobsDatingApp.Data.mocks
{
    public static class DBObjects
    {
        public static List<Company> Companies { get; set; }
        public static List<Vacancy> Vacancies { get; set; }
        static DBObjects()
        {
            Companies = new List<Company>()
            {
                new Company()
                {
                    Id=1,
                    Name="Sber",
                    ShortDesc="Sber company",
                    FullDesc="State company Sber",
                    PhotoPath="/Files/CompanyPhoto/Sber.jpg",
                    Vacancies = new()
                },
                new Company()
                {
                    Id=2,
                    Name="VTB",
                    ShortDesc="VTB company",
                    FullDesc="Private company VTB",
                    PhotoPath="/Files/CompanyPhoto/Vtb.jpg",
                    Vacancies = new()
                }
            };
            Vacancies = new List<Vacancy>()
            {
                new Vacancy()
                {
                    Id = 1,
                    Name = "Junior",
                    CompanyId = 1,
                    Salary = 50000,
                    ShortDesc ="Junior position",
                    FullDesc ="Junior position in Sber",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 2,
                    Name = "Middle",
                    CompanyId = 1,
                    Salary = 100000,
                    ShortDesc ="Middle position",
                    FullDesc ="Middle position in Sber",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 3,
                    Name = "Junior",
                    CompanyId = 2,
                    Salary = 45000,
                    ShortDesc ="Junior position",
                    FullDesc ="Junior position in Vtb",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 4,
                    Name = "Middle",
                    CompanyId = 2,
                    Salary = 110000,
                    ShortDesc ="Middle position",
                    FullDesc ="Middle position in Vtb",
                    Company = new()
                }
            };
            BindCompaniesAndVacanies();
        }
        private static void BindCompaniesAndVacanies()
        {
            foreach (var bindingVacancy in Vacancies)
            {
                var bindingCompany = Companies.First(c => c.Id == bindingVacancy.CompanyId);
                bindingVacancy.Company = bindingCompany;
                bindingCompany.Vacancies.Add(bindingVacancy);
            }
        }
    }
}
