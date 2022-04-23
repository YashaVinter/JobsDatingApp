namespace JobsDatingApp.Models.Storage
{
    public class MockDataBase
    {
        List<Company> companies;
        public List<Company> Companies { get { return companies; } }
        List<Vacancy> vacancies;
        public List<Vacancy> Vacancies { get { return vacancies; } }
        public MockDataBase()
        {
            companies = new List<Company>() 
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
                    PhotoPath=null,
                }
            };
            vacancies = new List<Vacancy>()
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
                    CompanyId = 2,
                    Salary = 100000,
                    ShortDesc ="Middle position",
                    FullDesc ="Middle position in Vtb"
                }
            };
            BindTables(companies, vacancies);
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
