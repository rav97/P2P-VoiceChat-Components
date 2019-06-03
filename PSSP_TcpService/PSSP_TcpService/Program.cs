using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            PSSP pssp_send = new PSSP();
            PSSP pssp_recv = new PSSP();

            Console.Write("Serwer IP: ");
            string ip = Console.ReadLine();
            int port = 16000;

            ThreadPool.QueueUserWorkItem(Listener.ServerSimulator);
            TcpClient cli = new TcpClient(ip, port);
            byte[] rec = new byte[1024];
            byte[] buff = new byte[1024];
            pssp_send = new PSSP(PSSP.Type.CALL, GetLocalIPAddress(), 55555);
            buff = pssp_send.ToBytes();
            cli.GetStream().Write(buff, 0, buff.Length);
            Console.WriteLine("Klient wysłał: {0}", pssp_send.ToString());
            int l = cli.GetStream().Read(rec, 0, 1024);
            Console.WriteLine("Klient otrzymal: " + new ASCIIEncoding().GetString(rec).Substring(0, l));

            /*while (true)
            {
                //string message = Console.ReadLine();
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(message);
                byte[] rec = new byte[1024];
                cli.GetStream().Write(buffer, 0, buffer.Length);

                int l = cli.GetStream().Read(rec, 0, 1024);
                Console.WriteLine("Klient otrzymal: " + new ASCIIEncoding().GetString(rec).Substring(0, l));
            }*/
            while (true) ;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
