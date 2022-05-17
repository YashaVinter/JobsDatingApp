using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Filters
{
    public class AuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        private List<Guid> users = new List<Guid>();
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // if user not authorized
            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                var newUser = new Guid(Guid.NewGuid().ToString());
                var claims = new Claim[] 
                {
                    new(ClaimTypes.Name, newUser.ToString()),
                    new(CookiesLiterals.LastViewedVacancyId, "")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await context.HttpContext.SignInAsync(claimsPrincipal);
                users.Add(newUser);
            }
            // if user exist in user database
            if (false)
            {

            }
        }
    }
}
