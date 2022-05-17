using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace JobsDatingApp.Data.Models
{
    public class User
    {
        [BindNever]
        public Guid Id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(40, MinimumLength = 1)]
        [Required(ErrorMessage = "Данная строка не должна быть пустой")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пользователь с таким Логином уже существует")]
        public string Login { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Некорректно введен Email")]
        public string Email { get; set; }
        [StringLength(40, MinimumLength = 6,ErrorMessage = "Пароль должен быть длиннее 6 символов")]
        [Required(ErrorMessage ="Пароль должен быть длиннее 6 символов")]
        public string Password { get; set; }
        [BindNever]
        public int? LastViewedVacancyId { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public Vacancy? LastViewedVacancy { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public HashSet<Vacancy>? LikedVacancies { get; set; }
    }
}
