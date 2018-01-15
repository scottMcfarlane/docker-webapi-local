using Microsoft.AspNetCore.Mvc;

namespace WebApiLocal.Controllers
{
    [Route("/")]
    public class RouteController : Controller
    {
        [HttpGet]
        public IActionResult Get(string route)
        {
            return Ok(route);
        }

        [HttpPost]
        public IActionResult Post(string route)
        {
            return Ok(route);
        }

        [HttpPut]
        public IActionResult Put(string route)
        {
            return Ok(route);
        }

        [HttpDelete]
        public IActionResult Delete(string route)
        {
            return Ok(route);
        }
    }
}
