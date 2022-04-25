using Microsoft.AspNetCore.Mvc.Filters;

namespace JobsDatingApp.Filters
{
    public class CompanyEvaluationFilter : IAsyncActionFilter
    {
        public CompanyEvaluationFilter()
        {

        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
