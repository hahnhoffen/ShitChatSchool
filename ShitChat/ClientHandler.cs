using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class ClientHandler
    {
        
            private TcpClient tcpClient;
            private NetworkStream clientStream;
            private Server server;

            public ClientHandler(TcpClient client, Server server)
            {
                this.tcpClient = client;
                this.server = server;
                this.clientStream = tcpClient.GetStream();
            }

            public void HandleClientComm()
            {
                byte[] messageBytes;
                int bytesRead;

                while (true)
                {
                    try
                    {
                        messageBytes = new byte[4096];
                        bytesRead = clientStream.Read(messageBytes, 0, 4096);

                        if (bytesRead == 0)
                            break; // Client disconnected

                        string message = Encoding.ASCII.GetString(messageBytes, 0, bytesRead);
                        Console.WriteLine($"Received: {message}");

                        // Skicka meddelandet till alla andra anslutna klienter
                        server.BroadcastMessage(message, this);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        break;
                    }
                }

                server.RemoveClient(this);
                tcpClient.Close();
            }

            public void SendMessage(string message)
            {
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                clientStream.Write(messageBytes, 0, messageBytes.Length);
                clientStream.Flush();
            }
        
    }
}
