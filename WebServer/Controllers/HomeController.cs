using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace WebServer.Controllers
{
    public class HomeController
    {
        public HttpResponse Index()
        {
            return new TextResponse("");
        }
    }
}
