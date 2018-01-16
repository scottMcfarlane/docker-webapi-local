using Microsoft.AspNetCore.Mvc;

namespace WebApiLocal.Controllers
{
    [Route("{*url}")]
    [InterceptActionFilter]
    public class RouteController : Controller
    {
        public IActionResult Process(string route, object headers, object body)
        {
            return Ok(route);
        }
    }
}
