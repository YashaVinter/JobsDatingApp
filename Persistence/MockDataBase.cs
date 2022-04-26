using JobsDatingApp.Models;

namespace Persistence
{
    public class MockDataBase //: IDataBase<List>>
    {
        public List<Company> Companies { get; }
        public List<Vacancy> Vacancies { get; }
        public List<User> Users { get; }
        public MockDataBase()
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
                },
                new Company()
                { 
                    Id=2,
                    Name="VTB",
                    ShortDesc="VTB company",
                    FullDesc="Private company VTB",
                    PhotoPath="/Files/CompanyPhoto/Vtb.jpg",
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
                    FullDesc ="Junior position in Sber"
                },
                new Vacancy()
                {
                    Id = 2,
                    Name = "Middle",
                    CompanyId = 1,
                    Salary = 100000,
                    ShortDesc ="Middle position",
                    FullDesc ="Middle position in Sber"
                },
                                new Vacancy()
                {
                    Id = 3,
                    Name = "Junior",
                    CompanyId = 2,
                    Salary = 45000,
                    ShortDesc ="Junior position",
                    FullDesc ="Junior position in Vtb"
                },
                new Vacancy()
                {
                    Id = 4,
                    Name = "Middle",
                    CompanyId = 2,
                    Salary = 110000,
                    ShortDesc ="Middle position",
                    FullDesc ="Middle position in Vtb"
                }
            };
            Users = new List<User>();
            BindTables(Companies, Vacancies);
        }
        private void BindTables(List<Company> companies, List<Vacancy> vacancies)
        {
            foreach (var company in companies)
            {
                company.Vacancies = vacancies.Where(v => v.CompanyId == company.Id).ToList();
            }
            foreach (var vacany in vacancies)
            {
                vacany.Company = companies.Where(c => vacany.CompanyId == c.Id).First();
            }
        }
    }
}
