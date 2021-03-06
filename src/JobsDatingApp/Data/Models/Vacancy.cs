using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsDatingApp.Data.Models
{
    public class Vacancy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public double Salary { get; set; }
        public string? ShortDesc { get; set; }
        public string? FullDesc { get; set; }
		public string? PhotoPath { get; set; }
		public string? Address { get; set; }
        public HashSet<User>? LikedUsers { get; set; }
    }
}