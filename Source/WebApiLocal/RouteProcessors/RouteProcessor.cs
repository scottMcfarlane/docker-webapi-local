using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLocal.RouteProcessors
{
    public class RouteProcessor : IRouteProcessor
    {
        private static Dictionary<string, StatusCodeResult> RouteTable => new Dictionary<string, StatusCodeResult>()
        {
            {"/Get/This/Route", new UnauthorizedResult() }
        };

        public ActionResult Process(string route)
        {
            if (RouteTable.TryGetValue(route, out var result))
                return result;

            return new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Content = "Your custom route was not found"
            };
        }
    }
}
