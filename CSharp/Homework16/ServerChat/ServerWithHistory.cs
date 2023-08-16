using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ClientHandler
{
    private TcpClient client;
    private string name;
    private StreamWriter writer;
    private ConcurrentDictionary<string, ClientHandler> clients;
    private List<string> messageHistory = new List<string>();

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

            // Send history to the new client
            SendHistory();

            while (true)
            {
                string message = reader.ReadLine();
                Console.WriteLine("Received: " + message);

                if (!string.IsNullOrEmpty(message))
                {
                    messageHistory.Add($"[{name}]: {message}");

                    if (messageHistory.Count > 100)
                    {
                        messageHistory.RemoveAt(0); // Keep a limited history
                    }

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

    public void SendHistory()
    {
        foreach (var message in messageHistory)
        {
            writer.WriteLine(message);
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
}