using System.Web;
using JobsDatingApp.Models;

namespace JobsDatingApp.ViewModels
{
    public class TestViewModel
    {
        public Company Company { get; set; }
        public TestViewModel(Company company)
        {
            this.Company = company;
            
        }
    }
}
