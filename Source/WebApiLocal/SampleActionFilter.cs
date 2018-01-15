using Microsoft.AspNetCore.Mvc.Filters;
using WebApiLocal.Controllers;

namespace WebApiLocal
{
    public class SampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Console.WriteLine("Oh Hello There");
            var myController = (RouteController)context.Controller;
            //context.Result = myController.RedirectToAction(context.HttpContext.Request.Method, myController);
            context.Result = myController.Get(myController.RouteData.ToString());
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Do nothing
        }
    }
}