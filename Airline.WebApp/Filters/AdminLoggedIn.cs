using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Filters
{
    public class AdminLoggedIn: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("id") == null)
            {
                
                context.HttpContext.Response.Redirect("/admin/index");
                return;
            }
        }
    }
}
