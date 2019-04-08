using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        //Watki wykonuja sie synchronicznie mimo ze nie powinny
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ServerSimulator);
            ThreadPool.QueueUserWorkItem(ClientSending, new object[] { "twoja stara", 31, 9 });
            ThreadPool.QueueUserWorkItem(ClientSending, new object[] { "klient1", 50, 3 });
            ThreadPool.QueueUserWorkItem(ClientSending, new object[] { "klient2", 70, 5 });
            ThreadPool.QueueUserWorkItem(ClientSending, new object[] { "klient3", 17, 6 });

            /*while (true) ;*/
            /*TcpClient cli1 = new TcpClient("127.0.0.1", 2048);
            TcpClient cli2 = new TcpClient("127.0.0.1", 2048);
            TcpClient cli3 = new TcpClient("127.0.0.1", 2048);
            TcpClient cli4 = new TcpClient("127.0.0.1", 2048);
            TcpClient cli5 = new TcpClient("127.0.0.1", 2048);

            byte[] b1 = Encoding.ASCII.GetBytes("Jestem 1");
            byte[] b2 = Encoding.ASCII.GetBytes("Jestem 2");
            byte[] b3 = Encoding.ASCII.GetBytes("Jestem 3");
            byte[] b4 = Encoding.ASCII.GetBytes("Jestem 4");
            byte[] b5 = Encoding.ASCII.GetBytes("Jestem 5");

            cli1.GetStream().Write(b1, 0, b1.Length);
            Thread.Sleep(5);
            cli2.GetStream().Write(b2, 0, b2.Length);
            Thread.Sleep(15);
            cli3.GetStream().Write(b3, 0, b3.Length);
            Thread.Sleep(8);
            cli4.GetStream().Write(b4, 0, b4.Length);
            Thread.Sleep(50);
            cli5.GetStream().Write(b5, 0, b5.Length);

            Thread.Sleep(10000);*/
        }
        static void ServerSimulator(object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Klient polaczony");
                ThreadPool.QueueUserWorkItem(ClientHandler, client);
            }
        }
        static void WriteConsoleMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void ClientHandler(Object client)
        {
            //var param = client as object;
            TcpClient cli = (TcpClient)client;
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int l = cli.GetStream().Read(buffer, 0, 1024);

                    WriteConsoleMessage("Serwer otrzymal: " + new ASCIIEncoding().GetString(buffer).Substring(0, l), ConsoleColor.Green);
                    cli.GetStream().Write(buffer, 0, l);
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
            catch (Exception e)
            {
                cli.Close();
                Console.WriteLine("Zamknieto klienta");
            }
        }
        static void ClientSending(object stateInfo)
        {
            object[] args = stateInfo as object[];
            string message = args[0] as string;
            int time = (int)args[1];
            int n = (int)args[2];
            TcpClient cli = new TcpClient("127.0.0.1", 2048);
            byte[] buffer = new byte[1024];
            byte[] rec = new byte[1024];
            buffer = System.Text.Encoding.ASCII.GetBytes(message);
            for (int i = n; i > 0; i--)
            {
                cli.GetStream().Write(buffer, 0, buffer.Length);
                int l = cli.GetStream().Read(rec, 0, 1024);
                WriteConsoleMessage("Klient otrzymal: " + new ASCIIEncoding().GetString(rec).Substring(0, l), ConsoleColor.Red);
                Thread.Sleep(time);
            }
        }
    }
}
