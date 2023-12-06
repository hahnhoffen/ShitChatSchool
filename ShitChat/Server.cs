using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShitChat
{
    public class Server
    {
        private TcpListener tcpListener;
        private Thread listenerThread;
        private List<ClientHandler> connectedClients = new List<ClientHandler>();

        public Server()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 5000);
            this.listenerThread = new Thread(new ThreadStart(ListenForClients));
            this.listenerThread.Start();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                ClientHandler clientHandler = new ClientHandler(client, this);
                connectedClients.Add(clientHandler);

                Thread clientThread = new Thread(new ThreadStart(clientHandler.HandleClientComm));
                clientThread.Start();
            }
        }

        public void BroadcastMessage(string message, ClientHandler sender)
        {
            foreach (ClientHandler client in connectedClients)
            {
                if (client != sender) // Skicka inte tillbaka meddelandet till avsändaren
                    client.SendMessage(message);
            }
        }

        public void RemoveClient(ClientHandler client)
        {
            connectedClients.Remove(client);
        }
    }
}
