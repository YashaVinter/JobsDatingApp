namespace JobsDatingApp.Models
{
	public class User
	{
        public Guid Id{ get; set; }
        public Vacancy? LastViewedVacancy { get; }
    }
}
