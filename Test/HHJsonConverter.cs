using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsDatingApp.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test
{
    internal class HHJsonConverter
    {
        private readonly string _json;
        private readonly JsonSerializer _jsonSerializer;

        public HHJsonConverter(string json)
        {
            _json = json;
            _jsonSerializer = new JsonSerializer();
            _jsonSerializer.Converters.Add(new HHConverter(new HashSet<Type>() 
            { 
                typeof(Company),
                typeof(Vacancy)
            }));          
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
    }
    public class HHConverter : JsonConverter
    {
        private readonly ISet<Type> _types;
        public HHConverter(ISet<Type> types)
        {
            _types = types;
        }
        public override bool CanConvert(Type objectType)
        {
            if (_types.Contains(objectType))
            {
                return true;
            }
            return false;
        }
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(Company))
                return ConvertCompany(reader);
            if (objectType == typeof(Vacancy))
                return ConvertVacancy(reader);

            return null;
        }
        private Company ConvertCompany(JsonReader reader) 
        {
            JToken jCompany = JToken.ReadFrom(reader);
            var company = new Company() 
            {
                Id = (int)jCompany[nameof(Company.Id).ToLower()],
                Name = (string)jCompany[nameof(Company.Name).ToLower()],
            };
            if (jCompany["logo_urls"]!.HasValues)
            {
                company.PhotoPath = (string?)jCompany["logo_urls"]["original"];
            }
            return company;
        }
        private Vacancy ConvertVacancy(JsonReader reader)
        {
            JToken jVacancy = JToken.ReadFrom(reader);
            var vacancy = new Vacancy()
            {
                Id = (int)jVacancy[nameof(Vacancy.Id).ToLower()],
                Name = (string)jVacancy[nameof(Vacancy.Name).ToLower()],
                Salary = ConvertSalary(jVacancy[nameof(Vacancy.Salary).ToLower()]),
                ShortDesc = (string)jVacancy["snippet"]["requirement"],
                FullDesc = (string)jVacancy["snippet"]["requirement"],
                Address = (string)jVacancy["area"]["name"],
                CompanyId = (int)jVacancy["employer"]["id"]
            };
            return vacancy;
        }
        private double ConvertSalary(JToken jSalary)
        {
            double dollarExchangeRate = 60d;
            double euroExchangeRate = 65d;
            double? fromSalary = ((double?)jSalary["from"]);
            double? toSalary = ((double?)jSalary["to"]);
            double salary = double.NaN;
            if (fromSalary is not null && toSalary is not null)
            {
                salary = (fromSalary.Value + toSalary.Value) / 2;
            }
            else if (fromSalary is null)
            {
                salary = toSalary!.Value;
            }
            else if (toSalary is null)
            {
                salary = fromSalary!.Value;
            }
            string currency = (string)jSalary["currency"];
            if (currency == "USD")
            {
                return salary * dollarExchangeRate;
            }
            else if (currency == "EUR")
            {
                return salary * euroExchangeRate;
            }
            else if (currency == "RUR")
            {
                return salary;
            }
            return salary;
        }
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
