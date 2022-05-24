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

            var hhSerializer = new HHJsonConverter(vacanciesJson);
            //var v = hhSerializer.Deserialize<Company>()
            var companies = hhSerializer.GetCompanies().ToArray();
            var vacancies = hhSerializer.GetVacancies().ToArray();
            
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
