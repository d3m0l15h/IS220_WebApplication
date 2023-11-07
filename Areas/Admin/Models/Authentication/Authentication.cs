using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IS220_WebApplication.Areas.Admin.Models.Authentication
{
    [Area("admin")]
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("email") != null) return;
            
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