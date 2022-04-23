namespace JobsDatingApp.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Company Company { get; set; }
        public double Salary { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
    }
}
