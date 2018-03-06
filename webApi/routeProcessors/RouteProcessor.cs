using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi.RouteProcessors
{
    public class RouteProcessor : IRouteProcessor
    {
        private readonly Dictionary<string, ContentResult> _routeTable;

        public RouteProcessor(Dictionary<string, ContentResult> routeTable)
        {
            _routeTable = routeTable;
        }

        public ActionResult Process(string route)
        {
            if (_routeTable.TryGetValue(route, out var result))
                return result;

            return new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Content = "Your custom route was not found"
            };
        }
    }
}
