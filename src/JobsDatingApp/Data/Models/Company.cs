namespace JobsDatingApp.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public List<Vacancy>? Vacancies{ get; set; }
        public string? ShortDesc { get; set; }
        public string? FullDesc { get; set; }
        public double? Rating { get; set; }
    }
}
