using JobsDatingApp.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JobsDatingApp.Data.SeedData.Implementation.HH_WEB_API
{

    public class HHDBSeed : IDBSeed
    {
        private readonly string _json;
        private readonly JsonSerializer _jsonSerializer;

        public HHDBSeed(string hhRequestUri)
        {
            _json = GetRespondFromHH(hhRequestUri);

            _jsonSerializer = new JsonSerializer();
            _jsonSerializer.Converters.Add(new HHConverter(new HashSet<Type>()
            {
                typeof(Company),
                typeof(Vacancy)
            }));
        }
        private string GetRespondFromHH(string requestUri)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "application/json");
            var respondBodyTask = client.GetStringAsync(requestUri); // await client.GetAsync(requestUri);
            respondBodyTask.Wait();
            return respondBodyTask.Result;
        }

        public IEnumerable<Company> GetCompanies()
        {
            JEnumerable<JToken> jVacancies = JObject.Parse(_json)["items"].Children();
            List<Company> companies = new List<Company>();
            foreach (var jVacanciy in jVacancies)
            {
                companies.Add(jVacanciy["employer"]!.ToObject<Company>(_jsonSerializer)!);
            }
            return companies;
        }
        public IEnumerable<Vacancy> GetVacancies()
        {
            JEnumerable<JToken> jVacancies = JObject.Parse(_json)["items"].Children();
            List<Vacancy> vacancies = new List<Vacancy>();
            foreach (var jVacanciy in jVacancies)
            {
                vacancies.Add(jVacanciy!.ToObject<Vacancy>(_jsonSerializer)!);
            }
            return vacancies;
        }
        public IEnumerable<User> GetUsers()
        {
            return new User[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name ="Bob",
                    Email="test@mail.com",
                    Login ="Bob123",
                    Password="123456"
                }
            };
        }
    }
}
