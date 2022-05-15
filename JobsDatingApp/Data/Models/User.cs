namespace JobsDatingApp.Models
{
	public class User
	{
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int LastViewedVacancyId { get; }
        public Vacancy? LastViewedVacancy { get; }
        public List<Vacancy> LikedVacancies { get; set; }
    }
}
