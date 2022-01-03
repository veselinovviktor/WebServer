using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System.Threading.Tasks;

namespace WebServer
{
    internal class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes.MapGet("/Cats", new TextResponse("")));
            await server.Start();
        }
    }
}
