using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webApi.RouteProcessors
{
    public class RouteInitializer
    {
        public static Dictionary<string, ContentResult> Init()
        {
            var routeFile = File.ReadAllText("route-data.json");
            var routeContent = JsonConvert.DeserializeObject<List<Route>>(routeFile);
            var routeDictionary = new Dictionary<string, ContentResult>();

            foreach (var route in routeContent)
            {
                routeDictionary.Add(route.RoutePath, new ContentResult
                {
                    StatusCode = route.HttpStatusCode,
                    Content = route.Content
                });
            }

            return routeDictionary;
        }

        private class Route
        {
            public string RoutePath { get; set; }
            public int HttpStatusCode { get; set; }
            public string Content { get; set; }
        }
    }
}
