using System.Web;
using JobsDatingApp.Models;

namespace JobsDatingApp.ViewModels
{
    public class TestViewModel
    {
        public Vacancy Vacancy { get; set; }
        public TestViewModel(Vacancy vacancy)
        {
            this.Vacancy = vacancy;
           
        }
    }
}
