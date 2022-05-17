namespace JobsDatingApp.Data.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public double Salary { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public HashSet<User>? LikedUsers { get; set; }
    }
}
