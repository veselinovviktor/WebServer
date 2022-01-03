using MyWebServer.Server;
using System.Threading.Tasks;
using WebServer.Controllers;
using MyWebServer.Server.Controllers;

namespace WebServer
{
    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
            .MapGet<HomeController>("/softuni", c => c.ToYoutube()));
            await server.Start();
        }
    }
}
