using MyWebServer.Server.Http;
using System;

namespace MyWebServer.Server.Routing
{
    public interface IRountingTable
    {
        IRountingTable Map(HttpMethod method, string path, HttpResponse response);
        IRountingTable MapGet(string path, HttpResponse response);
        IRountingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);
        HttpResponse ExecuteRequest(HttpRequest request);

    }
}
