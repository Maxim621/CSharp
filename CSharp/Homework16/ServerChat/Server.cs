using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSharp.Homework16.ServerChat
{
    class ClientHandler
    {
        private ConcurrentQueue<string> messageHistory = new ConcurrentQueue<string>();

        private TcpClient client;
        private string name;
        private StreamWriter writer;
        private ConcurrentDictionary<string, ClientHandler> clients;

        public ClientHandler(TcpClient client, string name, ConcurrentDictionary<string, ClientHandler> clients)
        {
            this.client = client;
            this.name = name;
            this.clients = clients;
            writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };
        }

        public void Start()
        {
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start();
        }

        private void HandleClient()
        {
            try
            {
                StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);

                while (true)
                {
                    string message = reader.ReadLine();
                    Console.WriteLine("Received: " + message);

                    // Збереження повідомлень у історії:
                    messageHistory.Enqueue($"[{name}]: {message}");
                    if (messageHistory.Count > 10)  // Зберігати останні 10 повідомлень
                    {
                        messageHistory.TryDequeue(out _);
                    }

                    if (message.StartsWith("@"))
                    {
                        string[] parts = message.Split(' ', 2);
                        if (parts.Length >= 2 && clients.TryGetValue(parts[0].Substring(1), out var privateClient))
                        {
                            privateClient.writer.WriteLine($"[Private from {name}]: {parts[1]}");
                        }
                        else
                        {
                            writer.WriteLine("User not found or invalid format.");
                        }
                    }
                    else
                    {
                        foreach (var client in clients.Values)
                        {
                            if (client != this)
                            {
                                client.writer.WriteLine($"[{name}]: {message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client disconnected.");
                clients.TryRemove(name, out _);
            }
            finally
            {
                client.Close();
            }
        }
    }

    class Server
    {
        private static ConcurrentDictionary<string, ClientHandler> clients = new ConcurrentDictionary<string, ClientHandler>();

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            Console.WriteLine("Server started.");

            // Запуск потоку UDP для пошуку серверів:
            Thread udpThread = new Thread(StartUdpDiscovery);
            udpThread.Start();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
                string name = reader.ReadLine();

                ClientHandler clientHandler = new ClientHandler(client, name, clients);
                clients.TryAdd(name, clientHandler);
                clientHandler.Start();
            }
        }

        // Метод для обробки UDP-запитів на пошук серверів
        static void StartUdpDiscovery()
        {
            UdpClient udpServer = new UdpClient(new IPEndPoint(IPAddress.Any, 54321));

            while (true)
            {
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udpServer.Receive(ref clientEndPoint);
                string message = Encoding.UTF8.GetString(data);

                if (message == "ServerDiscovery")
                {
                    byte[] response = Encoding.UTF8.GetBytes("ServerFound");
                    udpServer.Send(response, response.Length, clientEndPoint);
                }
            }
        }
    }
}
