using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System.Threading.Tasks;

namespace WebServer
{
    internal class StartUp
    {
        public static async Task Main()
        {
            var server = new Server(routes => routes.Map("/", new TextResponse("")));
            await server.Start();
        }
    }
}
