using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Server.Http;

namespace MyWebServer.Server
{
    public class Server
    {
        private readonly IPAddress _ipAddres;
        private readonly int _port;
        private readonly TcpListener _tcpListener;

        public Server(string ipAddres, int port)
        {
            _ipAddres = IPAddress.Parse(ipAddres);
            _port = port;
            _tcpListener = new TcpListener(_ipAddres, port);
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

                await WriteResponse(networkStream);

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

        private async Task WriteResponse(NetworkStream networkStream)
        {
            var content = "<h1>Здравей</h1>";
            var contentLength = Encoding.UTF8.GetByteCount(content);
            var response = $@"HTTP/1.1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow.ToString("r")}
Content-Length:{contentLength}
Content-Type: text/html; charset=UTF-8

{content}";
            var responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);
        }
    }
}
