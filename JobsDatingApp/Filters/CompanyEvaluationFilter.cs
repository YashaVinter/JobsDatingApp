using JobsDatingApp.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JobsDatingApp.Filters
{
    public class CompanyEvaluationFilter : IAsyncActionFilter
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
