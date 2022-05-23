using JobsDatingApp.Data.interfaces;
using JobsDatingApp.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Test
{
    public class HHVacanciesRepository : IVacanciesRepository
    {
        private IEnumerable<Vacancy> _vacancies;

        public HHVacanciesRepository()
        {
            //StartUp();
            _vacancies = null!;
            string fileName = @"C:\Users\User\source\repos\JobsDatingApp\Test\obj.json";
            var v = JObjectFromFile(fileName);
        }

        private void StartUp()
        {
            string requestUri = "https://api.hh.ru/vacancies?text=developer&area=113";
            var respondBody = GetRespondFromHH(requestUri);
            ParseJson(respondBody);
        }
        private string GetRespondFromHH(string requestUri)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "application/json");
            var respondBodyTask = client.GetStringAsync(requestUri); // await client.GetAsync(requestUri);
            respondBodyTask.Wait();
            return respondBodyTask.Result;
        }
        private void ParseJson(string vacanciesJson)
        {
            JObject JObject = JObject.Parse(vacanciesJson);
            JObject obj = (JObject) JObject["items"][0];

            var hhSerializer = new HHJsonSerializer(vacanciesJson);
            var companies = hhSerializer.GetCompanies();
        }
        public JObject JObjectFromFile(string filePath) 
        {
            string jsonString = File.ReadAllText(filePath);
            ParseJson(jsonString);
            throw new();
        }
        private Vacancy[] GetVacanies(JArray jVacancies)
        {
            Vacancy[] vacancies = new Vacancy[jVacancies.Count];
            var v = vacancies.GetEnumerator();
            //vacancies.
            foreach (var jVacancy in jVacancies)
            {
            }
            throw new();
        }
        private Vacancy GetVacancy(JToken jVacancy) 
        {
            Company company = GetCompany(jVacancy["employer"]);
            Vacancy vacancy = new Vacancy()
            {
                Id = (int)jVacancy["id"],
                Name = (string)jVacancy["name"],
                Salary = GetSalary(jVacancy["salary"]),
                ShortDesc = (string)jVacancy["snippet"]["requirement"],
                FullDesc = (string)jVacancy["snippet"]["requirement"],
                PhotoPath = company.PhotoPath,
                Company = company
            };
            return vacancy;
        }
        private double GetSalary(JToken jsalary) 
        {
            double dollarExchangeRate = 60d;
            double euroExchangeRate = 65d;
            double salary = (double)jsalary["from"];
            string currency = (string)jsalary["currency"];
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
            return 0;
        }
        private Company GetCompany(JToken? jToken)
        {
            return new Company
            {
                Id = (int) jToken["id"],
                Name = (string) jToken["name"],
                PhotoPath = (string)jToken["logo_urls"]["original"],
            };
        }
        private Company GetCompany1(JToken? jToken)
        {
            JsonSerializer serializer = new JsonSerializer();
            //JsonConverter converter = new JsonConverter();
            //serializer.Converters.Add();
            Company company = jToken.ToObject<Company>();
            return company;
        }

        public IEnumerable<Vacancy> AllVacancies => throw new NotImplementedException();

        public IEnumerable<Vacancy> AllVacanciesByCompanyId(int id)
        {
            throw new NotImplementedException();
        }

        public Vacancy FirstVacancy()
        {
            throw new NotImplementedException();
        }

        public Vacancy LastVacancy()
        {
            throw new NotImplementedException();
        }

        public Vacancy NextVacancy(int currentVacancyId)
        {
            throw new NotImplementedException();
        }

        public Vacancy PrevVacancy(int currentVacancyId)
        {
            throw new NotImplementedException();
        }

        public Vacancy VacancyById(int id)
        {
            throw new NotImplementedException();
        }

        public Vacancy VacancyByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
