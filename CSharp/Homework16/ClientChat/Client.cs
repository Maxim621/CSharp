using System;
using System.IO;
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
    }
}
