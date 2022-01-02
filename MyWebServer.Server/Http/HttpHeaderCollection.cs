using MyWebServer.Server.Common;
using System.Collections;
using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    public class HttpHeaderCollection : IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> _headers;

        public HttpHeaderCollection()
        {
            _headers = new Dictionary<string, HttpHeader>();
        }

        public int Count => _headers.Count;

        public void Add(string name, string value)
        {
            Guard.AgainstNull(name, "name");
            Guard.AgainstNull(value, "value");

            if (!_headers.ContainsKey(name))
            {
                _headers.Add(name, new HttpHeader(name, value));
            }
        }

        public IEnumerator<HttpHeader> GetEnumerator() => _headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
