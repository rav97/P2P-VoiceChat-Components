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
        static bool busy = false;

        public static void ServerSimulator(object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 16000);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Klient polaczony");
                ThreadPool.QueueUserWorkItem(ClientHandler, new object[] { client, busy });
            }
        }
        static void ClientHandler(object client)
        {
            //var param = client as object;
            object[] args = client as object[]; 

            TcpClient cli = (TcpClient)args[0];
            bool busy = (bool)args[1];

            byte[] buffer = new byte[1024];

            PSSP pssp = new PSSP();

            try
            {
                while (true)
                {
                    if (!busy)
                    {
                        Listener.busy = true;
                        
                        int l = cli.GetStream().Read(buffer, 0, buffer.Length);
                        pssp = new PSSP(PSSP.Type.ACK, Program.GetLocalIPAddress(), 66666);
                        Console.WriteLine("Serwer otrzymal: " + new ASCIIEncoding().GetString(buffer).Substring(0, l));
                        buffer = pssp.ToBytes();
                        cli.GetStream().Write(buffer, 0, buffer.Length);
                        Console.WriteLine("Serwer wyslal: {0}", pssp.ToString());
                        Array.Clear(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        pssp = new PSSP(PSSP.Type.BUSY);
                        cli.GetStream().Write(pssp.ToBytes(), 0, 33);
                        cli.Close();
                    }
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
