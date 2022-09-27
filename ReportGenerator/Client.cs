using System.Net;
using System.Net.Sockets;
using System.Text;
using WatsonWebsocket;

namespace ReportGenerator
{
    public class Client
    {
        public Client(string serverIP, int port)
        {
            WatsonWsClient client = new WatsonWsClient(serverIP, port, true);
            client.ServerConnected += ServerConnected;
            client.ServerDisconnected += ServerDisconnected;
            client.MessageReceived += MessageReceived;
            client.Start();
        }

        private static void ServerConnected(object sender, EventArgs args)
        {
            Console.WriteLine("Server connected!");
        }

        private static void ServerDisconnected(object sender, EventArgs args)
        {
            Console.WriteLine("Server disconnected!");
        }

        private static void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Console.WriteLine("Message from server:" + Encoding.UTF8.GetString(args.Data));
        }
    }
}