using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PSSP
{
    class Program
    {
        static void Main(string[] args)
        {
            PSSP pssp = new PSSP(PSSP.Type.ACK, GetLocalIPAddress(), 64000);
            byte[] data = pssp.ToBytes();

            PSSP pssp2 = new PSSP(data);

            Console.WriteLine(pssp2.getOP());
            Console.WriteLine(pssp2.getDATA());
            Console.WriteLine(pssp2.getIP());
            Console.WriteLine(pssp2.getPORT());

            PSSP pssp3 = new PSSP(PSSP.Type.BUSY);

            Console.WriteLine(pssp3.ToString());
            Console.WriteLine(pssp3.getOP());
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
