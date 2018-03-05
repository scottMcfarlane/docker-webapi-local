using Microsoft.AspNetCore.Mvc;

namespace webApi.RouteProcessors
{
    public interface IRouteProcessor
    {
        ActionResult Process(string route);
    }
}
