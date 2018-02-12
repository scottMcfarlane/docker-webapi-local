using Microsoft.AspNetCore.Mvc.Filters;
using WebApiLocal.Controllers;

namespace WebApiLocal.ActionFilters
{
    public class InterceptActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var myController = (RouteController)context.Controller;
            context.Result = myController.Process(context.HttpContext.Request.Path, null, null);
        }
    }
}
