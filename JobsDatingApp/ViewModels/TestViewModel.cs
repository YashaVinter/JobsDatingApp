using System.Web;
using JobsDatingApp.Models;
using JobsDatingApp.Models.Storage;

namespace JobsDatingApp.ViewModels
{
    public class TestViewModel
    {
        private MockDataBase dataBase;
        private List<Vacancy>.Enumerator vacancyEnumerator;

        public Vacancy Vacancy { get { return vacancyEnumerator.Current; } }

		public TestViewModel(MockDataBase dataBase)
        {
            this.dataBase = dataBase;
            vacancyEnumerator = dataBase.Vacancies.GetEnumerator();
			if (!vacancyEnumerator.MoveNext()){
                throw new();
			}
        }
        public void NextVacancy() 
        {
			if (!vacancyEnumerator.MoveNext()){
                throw new();
            }
        }
    }
}
