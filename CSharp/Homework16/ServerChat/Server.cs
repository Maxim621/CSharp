using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSharp.Homework16.ServerChat
{
    class Server
    {
        private static ConcurrentDictionary<string, StreamWriter> clients = new ConcurrentDictionary<string, StreamWriter>();

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            Console.WriteLine("Server started.");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };

                Thread clientThread = new Thread(() => HandleClient(client, writer));
                clientThread.Start();
            }
        }

        static void HandleClient(TcpClient client, StreamWriter writer)
        {
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            string name = reader.ReadLine();
            clients.TryAdd(name, writer);

            while (true)
            {
                try
                {
                    string message = reader.ReadLine();
                    Console.WriteLine("Received: " + message);

                    if (message.StartsWith("@"))
                    {
                        string[] parts = message.Split(' ', 2);
                        if (parts.Length >= 2 && clients.TryGetValue(parts[0].Substring(1), out var privateWriter))
                        {
                            privateWriter.WriteLine($"[Private from {name}]: {parts[1]}");
                        }
                        else
                        {
                            writer.WriteLine("User not found or invalid format.");
                        }
                    }
                    else
                    {
                        foreach (var clientWriter in clients.Values)
                        {
                            if (clientWriter != writer)
                            {
                                clientWriter.WriteLine($"[{name}]: {message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Client disconnected.");
                    clients.TryRemove(name, out _);
                    break;
                }
            }

            client.Close();
        }
    }
}
