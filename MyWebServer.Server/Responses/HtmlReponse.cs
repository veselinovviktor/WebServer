namespace MyWebServer.Server.Responses
{
    public class HtmlReponse : ContentResponse
    {
        public HtmlReponse(string text)
            : base(text, "text/html; charset=UTF-8")
        {
        }
    }
}
