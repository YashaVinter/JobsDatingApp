namespace JobsDatingApp.Models.Storage
{
    public class VacancyMemoryStorage : IStorage<Vacancy>
    {
        ISet<Vacancy> vacancies;
        public Vacancy? Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Vacancy? Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Vacancy? Post(Vacancy t)
        {
            throw new NotImplementedException();
        }

        public Vacancy? Put(Vacancy t)
        {
            throw new NotImplementedException();
        }
    }
}
