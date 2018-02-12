using Microsoft.AspNetCore.Mvc;
using WebApiLocal.ActionFilters;
using WebApiLocal.RouteProcessors;

namespace WebApiLocal.Controllers
{
    [Route("{*url}")]
    [InterceptActionFilter]
    public class RouteController : Controller
    {
        private IRouteProcessor _routeProcessor;

        public RouteController(IRouteProcessor routeProcessor)
        {
            _routeProcessor = routeProcessor;
        }

        public IActionResult Process(string route, object headers, object body)
        {
            return _routeProcessor.Process(route);
        }
    }
}
