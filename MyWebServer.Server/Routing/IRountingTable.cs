using MyWebServer.Server.Http;

namespace MyWebServer.Server.Routing
{
    public interface IRountingTable
    {
        IRountingTable Map(string url, HttpResponse response);
        IRountingTable Map(string ulr, HttpMethod method, HttpResponse response);
        IRountingTable MapGet(string url, HttpResponse response);
    }
}
