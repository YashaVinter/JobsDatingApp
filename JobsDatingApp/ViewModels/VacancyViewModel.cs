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
        public Vacancy Vacancy1 { get; private set; }

        public VacancyViewModel(MockDataBase dataBase)
        {
            this.dataBase = dataBase;
            vacancyEnumerator = dataBase.Vacancies.GetEnumerator();
			if (!vacancyEnumerator.MoveNext()){
                throw new();
			}
        }
        public VacancyViewModel(MockDataBase dataBase, System.Security.Claims.ClaimsPrincipal user)
        {
            this.dataBase = dataBase;
            //var userId = user.Identity!.Name;
            int vacancyId = int.Parse(user.FindFirst(CookiesLiterals.LastViewedVacancyId)!.Value);
            //var userVcancy = (from u in dataBase.Users
            //                  where u.Id.ToString() == userId
            //                  select u.LastViewedVacancy)
            //                 .FirstOrDefault();
            var userVcancy = (from v in dataBase.Vacancies
                              where v.Id == vacancyId
                              select v)
                             .FirstOrDefault();

            this.Vacancy1 = userVcancy ?? dataBase.Vacancies.First();
        }
        public VacancyViewModel(MockDataBase dataBase, int? vacancyId)
        {
            this.dataBase = dataBase;
            var userVacancy = (from v in dataBase.Vacancies
                              where v.Id == vacancyId
                              select v)
                             .FirstOrDefault();
            this.Vacancy1 = userVacancy ?? dataBase.Vacancies.First();
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
        public void PreviousVacancy() 
        {
            throw new NotImplementedException();
        }
        public void NextVacancy() 
        {
            var v = Vacancy;
			if (!vacancyEnumerator.MoveNext()){
                throw new();
            }
        }
        public bool NextVacancy1()
        {
            var nextVacancy = dataBase.Vacancies.FirstOrDefault(v => v.Id == Vacancy1.Id+1);
            if (nextVacancy is null){
                return false;
            }
            Vacancy1 = nextVacancy!;
            return true;
        }
    }
}
