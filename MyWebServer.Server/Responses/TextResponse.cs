using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System.Text;

namespace MyWebServer.Server.Responses
{
    public class TextResponse : HttpResponse
    {
        public TextResponse(string text)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text, nameof(text));

            int contentLength = Encoding.UTF8.GetByteCount(text);

            Headers.Add("Content-Length", $"{contentLength}");
            Headers.Add("Content-Type", $"text/plain;charset=UTF-8");

            Content = text;
        }
    }
}
