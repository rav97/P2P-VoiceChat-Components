using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSSP_TcpService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Serwer IP: ");
            string ip = Console.ReadLine();
            int port = 16000;

            ThreadPool.QueueUserWorkItem(Listener.ServerSimulator);

            TcpClient cli = new TcpClient(ip, port);

            while(true)
            {
                string message = Console.ReadLine();
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(message);
                cli.GetStream().Write(buffer, 0, buffer.Length);
            }
        }
    }
}
