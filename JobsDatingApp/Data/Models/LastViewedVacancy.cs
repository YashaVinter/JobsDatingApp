using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsDatingApp.Data.Models
{
    public class LastViewedVacancy
    {
        [Key]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        [Key]
        public int VacancyId { get; set; }
        public Vacancy? Vacancy { get; set; }
    }
}
