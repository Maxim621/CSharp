using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSharp.Homework16.ClientChat
{
    class Client
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 12345);
            Console.WriteLine("Connected to server.");

            StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            writer.WriteLine(name);

            // Додано: Потік для пошуку серверів
            Thread searchThread = new Thread(SearchForServers);
            searchThread.Start();

            Thread receiveThread = new Thread(() => ReceiveMessages(reader));
            receiveThread.Start();

            while (true)
            {
                string message = Console.ReadLine();
                writer.WriteLine(message);
            }
        }

        static void ReceiveMessages(StreamReader reader)
        {
            while (true)
            {
                string message = reader.ReadLine();
                Console.WriteLine(message);
            }
        }

        // Метод для пошуку серверів у мережі
        static void SearchForServers()
        {
            UdpClient udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;

            byte[] discoveryData = Encoding.UTF8.GetBytes("ServerDiscovery");
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Broadcast, 54321);

            udpClient.Send(discoveryData, discoveryData.Length, serverEndPoint);

            IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] response = udpClient.Receive(ref receiveEndPoint);
            string responseMessage = Encoding.UTF8.GetString(response);

            if (responseMessage == "ServerFound")
            {
                Console.WriteLine("Server found in the network.");
            }
            else
            {
                Console.WriteLine("No servers found in the network.");
            }

            udpClient.Close();
        }
    }
}
