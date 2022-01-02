using MyWebServer.Server;
using System.Threading.Tasks;

namespace WebServer
{
    internal class StartUp
    {
        public static async Task Main()
        {
            var server = new Server("127.0.0.1", 2020);
            await server.Start();
        }
    }
}
