using MyWebServer.Server;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace WebServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Index()
        {
            return Text("Hello from Viktor");
        }

        public HttpResponse ToYoutube() => Redirect("https://www.youtube.com/");
    }
}
