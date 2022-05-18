namespace JobsDatingApp.Data.Models
{
    public class LastViewedVacancy
    {
        public int UserId{ get; set; }
        public Vacancy? Vacancy { get; set; }
    }
}
