using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    internal class HttpResponse
    {
        public HttpResponse()
        {
            Headers = new HttpHeaderCollection();
        }

        public HttpStatusCode StatusCode { get; private set; }

        public HttpHeaderCollection Headers { get; }

        public string Body { get; private set; }
    }
}
