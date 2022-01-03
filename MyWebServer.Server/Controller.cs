using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server
{
    public abstract class Controller
    {
        protected HttpRequest Request { get; private set; }

        protected Controller(HttpRequest request)
        {
            Request = request;
        }

        protected HttpResponse Text(string text) => new TextResponse(text);

        protected HttpResponse Html(string html) => new HtmlResponse(html);

        protected HttpResponse Redirect(string location) => new RedirectResponse(location);
    }
}
