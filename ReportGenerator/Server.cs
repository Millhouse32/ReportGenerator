using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;

namespace ReportGenerator
{
    public class Session : TcpSession
    {
        public Session(TcpServer server) : base(server) { }

        protected override void OnConnected()
        {
            Console.WriteLine($"TCP connection with ID {Id} established!");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"TCP connection with ID {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine("Incoming Payload: \n" + message);
        }
    }

    public class Server : TcpServer
    {
        public Server(IPAddress address, int port) : base (address, port) { }

        protected override TcpSession CreateSession()
        {
            return new Session(this);
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Error while establishing server with code {error}");
        }
    }
}