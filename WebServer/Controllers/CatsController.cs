using MyWebServer.Server;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace WebServer.Controllers
{
    public class CatsController : Controller
    {
        public CatsController(HttpRequest request) : base(request)
        {

        }

        public HttpResponse Index()
        {
            const string nameKey = "Name";
            var query = Request.Query;
            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

            var result = $"<h1> Hello from {catName}!</h1>";

            return Html(result);
        }
    }
}
