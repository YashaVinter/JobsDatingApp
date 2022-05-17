using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data.Models
{
    public class LikedVacancy
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int VacancyId{ get; set; }
        public Vacancy? Vacancy{ get; set; }
    }
}
