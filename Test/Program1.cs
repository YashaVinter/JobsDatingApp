using Newtonsoft.Json.Linq;

namespace Test
{
    public static class Program1
    {
        public static async Task Main(string[] args)
        {
            HHVacanciesRepository hHVacanciesRepository = new HHVacanciesRepository();
        }
        private static async void Test() 
        {
            //ekb area 3 cverdl obl 1261
            string request = "https://api.hh.ru/vacancies/55042238"; // 55162113
            string developersURL = "https://api.hh.ru/vacancies?text=developer&area=113";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "application/json");
            var res = await client.GetAsync(developersURL);
            var s = await res.Content.ReadAsStringAsync();
            var sLenght = s.Count();
            JObject jobject = JObject.Parse(s);
            //int id = jobject.GetValue(nameof(id))!.Value<int>();
            //string name = jobject.GetValue(nameof(name))!.Value<string>()!;
            Console.WriteLine(jobject.ToString());
            var count = jobject.Children().Count();
            foreach (var jtoken in jobject.Children())
            {
            }
        }
    }
}
