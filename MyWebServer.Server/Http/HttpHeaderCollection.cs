using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> _headers;

        public HttpHeaderCollection()
        {
            _headers = new Dictionary<string, HttpHeader>();
        }

        public int Count => _headers.Count;

        internal void Add(HttpHeader httpHeader)
        {
            if (!_headers.ContainsKey(httpHeader.Name))
            {
                _headers.Add(httpHeader.Name, httpHeader);
            }
        }
    }
}
