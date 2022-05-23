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
    internal class HHJsonSerializer : JsonSerializer
    {
        private readonly string _json;
        private JsonSerializer _jsonSerializer;

        public HHJsonSerializer(string json)
        {
            _json = json;
            _jsonSerializer = new JsonSerializer();
            _jsonSerializer.Converters.Add(new CompanyConverter());
        }
        public Company[] GetCompanies() 
        {
            JEnumerable<JToken> jVacancies = JObject.Parse(_json)["items"].Children();
            List<Company> companies = new List<Company>();
            foreach (var jVacanciy in jVacancies)
            {
                companies.Add(jVacanciy["employer"]!.ToObject<Company>(_jsonSerializer)!);
                
            }
            return companies.ToArray();
            
        }
    }
    public class CompanyConverter : JsonConverter<Company>
    {
        public override Company? ReadJson(JsonReader reader, Type objectType, Company? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jCompany = JToken.ReadFrom(reader);
            return new Company() 
            {
                Id = (int) jCompany[nameof(Company.Id).ToLower()],
                Name = (string) jCompany[nameof(Company.Name).ToLower()],
                PhotoPath = (string)jCompany["logo_urls"]["original"]
            };
        }
        public override void WriteJson(JsonWriter writer, Company? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
