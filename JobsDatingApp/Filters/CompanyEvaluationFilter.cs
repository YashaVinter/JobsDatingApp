using JobsDatingApp.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobsDatingApp.Filters
{
    public class CompanyEvaluationFilter : Attribute,IAsyncActionFilter
    {
        public CompanyEvaluationFilter(MockDataBase dataBase)
        {

        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
