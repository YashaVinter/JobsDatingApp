namespace JobsDatingApp.Data.Models
{
    public class LastViewedVacancy
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public int VacancyId { get; set; }
        public Vacancy? Vacancy { get; set; }
    }
}
