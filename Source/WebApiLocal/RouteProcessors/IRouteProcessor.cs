using Microsoft.AspNetCore.Mvc;

namespace WebApiLocal.RouteProcessors
{
    public interface IRouteProcessor
    {
        ActionResult Process(string route);
    }
}
