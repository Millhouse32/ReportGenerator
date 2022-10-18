using WatsonWebsocket;
using System;
using System.Text;

namespace Server
{
    public class Server
    {
        /// <summary>
        /// Private field that holds the socket server
        /// </summary>
        private WatsonWsServer _server;

        /// <summary>
        /// Event for the main thread to call the worker code
        /// </summary>
        public static event EventHandler<string> MessageReceived;

        /// <summary>
        /// Property to access _server
        /// </summary>
        public WatsonWsServer WsServer { get { return _server; } set { _server = value; } }


        /// <summary>
        /// Constructor that creates a server and start listening
        /// </summary>
        public Server()
        {
            WsServer = new WatsonWsServer("localhost", 60000, true|false);

            WsServer.ClientConnected += ClientConnected;

            WsServer.ClientDisconnected += ClientDisconnect;

            WsServer.MessageReceived += SocketMessageReceived;
        }

        /// <summary>
        /// Method invoked when a client is connected
        /// </summary>
        /// <param name="sender">client</param>
        /// <param name="args">information of client</param>
        private void ClientConnected(object sender, ClientConnectedEventArgs args)
        {
            Console.WriteLine("New client connected from :: " + args.IpPort);
        }

        /// <summary>
        /// Method invoked when a client is disconnected
        /// </summary>
        /// <param name="sender">client</param>
        /// <param name="args">information of client</param>
        private void ClientDisconnect(object sender, ClientDisconnectedEventArgs args)
        {
            Console.WriteLine("Client disconnected :: " + args.IpPort);
        }

        /// <summary>
        /// Method invoked when a message is received
        /// </summary>
        /// <param name="sender">client</param>
        /// <param name="args">client message and client data</param>
        private void SocketMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            string message = Encoding.UTF8.GetString(args.Data);

            Console.WriteLine("Message received... Sender :: " + args.IpPort + " Message :: " + message);
            MessageReceived?.Invoke(this, message);
        }
    }
}