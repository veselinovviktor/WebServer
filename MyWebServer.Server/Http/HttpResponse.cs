using System;
using System.Text;

namespace MyWebServer.Server.Http
{
    public abstract class HttpResponse
    {
        protected HttpResponse(HttpStatusCode statusCode)
        {
            Headers = new HttpHeaderCollection();
            Headers.Add("Server", "My Web Server");
            Headers.Add("Date:", $"{DateTime.UtcNow:r}");
            StatusCode = statusCode;
        }

        protected HttpStatusCode StatusCode { get; set; }
        protected HttpHeaderCollection Headers { get; set; }
        protected string Content { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP / 1.1 {(int)StatusCode} {StatusCode}");

            foreach (var header in Headers)
            {
                result.AppendLine(header.ToString());
            }

            result.AppendLine();

            result.AppendLine(Content);

            return result.ToString();
        }
    }
}
