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
            _jsonSerializer.Converters.Add(new HHConverter());
        }
        public IEnumerable<Company> GetCompanies()
        {
            JEnumerable<JToken> jVacancies = JObject.Parse(_json)["items"]!.Children();
            List<Company> companies = new List<Company>();
            foreach (var jVacancy in jVacancies)
            {
                companies.Add(jVacancy["employer"]!.ToObject<Company>(_jsonSerializer)!);
            }
            return companies;
        }
        public IEnumerable<Vacancy> GetVacancies()
        {
            JEnumerable<JToken> jVacancies = JObject.Parse(_json)["items"]!.Children();
            List<Vacancy> vacancies = new List<Vacancy>();
            foreach (var jVacancy in jVacancies)
            {
                vacancies.Add(jVacancy!.ToObject<Vacancy>(_jsonSerializer)!);
            }
            return vacancies;
        }
        /// <summary>
        /// plug
        /// </summary>
        /// <returns></returns>
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
        private string GetRespondFromHH(string requestUri)
        {
            var client = new HttpClient();
            //required requirement HH WEB API
            client.DefaultRequestHeaders.Add("User-Agent", "application/json");
            var respondBodyTask = client.GetStringAsync(requestUri);
            respondBodyTask.Wait();
            return respondBodyTask.Result;
        }
    }
}
