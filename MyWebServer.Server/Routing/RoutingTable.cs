using MyWebServer.Server.Http;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRountingTable
    {
        public IRountingTable Map(string url, HttpResponse response)
        {
            throw new System.NotImplementedException();
        }

        public IRountingTable Map(string ulr, HttpMethod method, HttpResponse response)
        {
            throw new System.NotImplementedException();
        }

        public IRountingTable MapGet(string url, HttpResponse response)
        {
            throw new System.NotImplementedException();
        }
    }
}
