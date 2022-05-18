using JobsDatingApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsDatingApp.Data.Models
{
    public class LikeInfo
    {
        [Key]
        public Guid UserId { get; set; }
        //[ForeignKey(nameof(User))]
        public User? User { get; set; }
        [Key]
        public int VacancyId{ get; set; }
        //[ForeignKey(nameof(Vacancy))]
        public Vacancy? Vacancy{ get; set; }
        public DateTime? LikeTime{ get; set; }
    }
}
