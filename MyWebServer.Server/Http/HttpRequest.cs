using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";
        public HttpMethod HttpMethod { get; private set; }

        public string Path { get; private set; }
        public Dictionary<string, string> Query { get; set; }
        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; set; }

        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines.First().Split(new char[] { ' ' });
            var requestMethod = ParseHttpMethod(startLine[0]);
            string url = startLine[1];
            var (path, query) = ParseUrl(url);
            var headerLines = lines.Skip(1);
            var headers = ParseHttpHeaderCollection(headerLines);

            var body = string.Join(NewLine, headers);

            return new HttpRequest()
            {
                HttpMethod = requestMethod,
                Path = path,
                Body = body,
                Headers = headers,
                Query = query
            };
        }

        private static string[] GetStartLine(string request)
        {

            throw new NotImplementedException();
        }

        private static HttpMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethod.GET,
                "POST" => HttpMethod.POST,
                "DELETE" => HttpMethod.DELETE,
                "PUT" => HttpMethod.PUT,
                _ => throw new ArgumentException($"Method '{method}' is not supported!"),
            };
        }

        private static (string path, Dictionary<string, string> query) ParseUrl(string url)
        {
            var urlParts = url.Split(new char[] { '?' });
            var path = urlParts[0].ToLower();
            var query = urlParts.Length > 1 ? ParseQuery(urlParts[1]) : new Dictionary<string, string>();

            return (path, query);
        }

        private static Dictionary<string, string> ParseQuery(string queryString)
            => queryString.Split('&')
                    .Select(part => part.Split('='))
                    .Where(part => part.Length == 2)
                    .ToDictionary(part => part[0], part => part[1]);

        private static HttpHeaderCollection ParseHttpHeaderCollection(IEnumerable<string> headerLines)
        {
            var headers = new HttpHeaderCollection();
            foreach (string header in headerLines)
            {
                if (header == string.Empty)
                {
                    break;
                }

                var headerParts = header.Split(": ").ToArray();
                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1];
                headers.Add(headerName, headerValue);
            }

            return headers;
        }
    }
}