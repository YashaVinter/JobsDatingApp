using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace JobsDatingApp.Data.Models
{
    public class User
    {
        [Key]
        [BindNever]
        public Guid Id { get; set; }
        //[Display(Name = "Введите имя")]
        [StringLength(40, MinimumLength = 1)]
        [Required(ErrorMessage = "Данная строка не должна быть пустой")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Данная строка не должна быть пустой")]
        public string Login { get; set; }
        [EmailAddress(ErrorMessage = "Некорректно введен Email")]
        [Required(ErrorMessage = "Некорректно введен Email")]
        public string Email { get; set; }
        [StringLength(40, MinimumLength = 6,ErrorMessage = "Пароль должен быть длиннее 6 символов")]
        [Required(ErrorMessage ="Пароль должен быть длиннее 6 символов")]
        public string Password { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public LastViewedVacancy? LastViewedVacancy { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public HashSet<Vacancy>? LikedVacancies { get; set; }
    }
}
