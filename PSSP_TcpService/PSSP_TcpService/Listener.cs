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
    static class Listener
    {
        public static void ServerSimulator(object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 16000);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Klient polaczony");
                ThreadPool.QueueUserWorkItem(ClientHandler, client);
            }
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

                    Console.WriteLine("Serwer otrzymal: " + new ASCIIEncoding().GetString(buffer).Substring(0, l));
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
    }
}
