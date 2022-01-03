using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System.Text;

namespace MyWebServer.Server.Responses
{
    public abstract class ContentResponse : HttpResponse
    {
        public ContentResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text, nameof(text));

            int contentLength = Encoding.UTF8.GetByteCount(text);

            Headers.Add("Content-Length", $"{contentLength}");
            Headers.Add("Content-Type", $"{contentType}");

            Content = text;
        }
    }
}
