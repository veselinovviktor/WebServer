using MyWebServer.Server.Http;
using MyWebServer.Server.Routing;
using System;

namespace MyWebServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> contollerFunction)
              where TController : Controller
       => routingTable.MapGet(path, request => contollerFunction(CreateController<TController>(request)));
        private static TController CreateController<TController>(HttpRequest httpRequest)
         => (TController)Activator.CreateInstance(typeof(TController), new object[] { httpRequest });
    }
}
