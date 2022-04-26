using System;
using JobsDatingApp.Models;

namespace JobsDatingApp.ViewModels
{
    public class VacancyViewModel
    {
        private MockDataBase dataBase;
        private List<Vacancy>.Enumerator vacancyEnumerator;

        public Vacancy Vacancy 
        {
            get
            {
                return vacancyEnumerator.Current; 
            } 
        }
		public VacancyViewModel(MockDataBase dataBase)
        {
            this.dataBase = dataBase;
            vacancyEnumerator = dataBase.Vacancies.GetEnumerator();
			if (!vacancyEnumerator.MoveNext()){
                throw new();
			}
        }
        public Vacancy LastShownVacancy(System.Security.Claims.ClaimsPrincipal user) 
        {
            var userId = user.Identity!.Name;
            var userVcancy = (from u in dataBase.Users
                              where u.Id.ToString() == userId
                              select u.LastViewedVacancy)
                             .FirstOrDefault();
            return userVcancy ?? dataBase.Vacancies.First();
        }
        public void NextVacancy() 
        {
            var v = Vacancy;
			if (!vacancyEnumerator.MoveNext()){
                throw new();
            }
        }
    }
}
