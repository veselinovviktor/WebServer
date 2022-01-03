using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Server.Http;
using MyWebServer.Server.Routing;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress _ipAddres;
        private readonly int _port;
        private readonly TcpListener _tcpListener;
        private readonly IRountingTable _routingTable;

        public HttpServer(Action<IRountingTable> routingTable)
            : this(2020, routingTable)
        {
        }

        public HttpServer(int port, Action<IRountingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(string ipAddres, int port, Action<IRountingTable> routingTableConfiguration)
        {
            _ipAddres = IPAddress.Parse(ipAddres);
            _port = port;
            _tcpListener = new TcpListener(_ipAddres, port);
            routingTableConfiguration(_routingTable = new RoutingTable());
        }

        public async Task Start()
        {
            _tcpListener.Start();
            System.Console.WriteLine($"Server started on port {_port}...");
            System.Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await _tcpListener.AcceptTcpClientAsync();
                var networkStream = connection.GetStream();

                string requestText = await ReadRequest(networkStream);
                var request = HttpRequest.Parse(requestText);

                var response = _routingTable.ExecuteRequest(request);
                await WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();
            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return requestBuilder.ToString();
        }

        private static async Task WriteResponse(
            NetworkStream networkStream,
            HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }
    }
}
