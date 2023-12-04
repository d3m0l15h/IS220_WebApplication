using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IS220_WebApplication.Areas.Admin.Models.Authentication
{
    [Area("admin")]
    public class Authentication : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context,  ActionExecutionDelegate next)
        {
            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<Aspnetuser>>();
            var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<Aspnetuser>>();
            var user = await userManager.GetUserAsync(context.HttpContext.User);
            if (context.HttpContext.User.Identity is { IsAuthenticated: true } && user is { Role: 1 })
            {
                await next();
                return;
            }
            
            await signInManager.SignOutAsync();
            var originalUrl = context.HttpContext.Request.Path.ToString();
            context.HttpContext.Response.Cookies.Append("OriginalUrl", originalUrl);

            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"Area", "admin"},
                    {"Controller", "login"},
                    {"Action", "index"},
                });
        }
    }
}