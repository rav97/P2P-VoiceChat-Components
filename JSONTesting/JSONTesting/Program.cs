using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONTesting
{
    class Program
    {
        public static Contact ME = new Contact("TestUser", GetLocalIPAddress());
        static void Main(string[] args)
        {
            ContactsTest();
            HistoryTest();
        }
        public static void ContactsTest()
        {
            Contacts contacts = new Contacts();
            contacts.AddContact(new Contact("User1", "192.168.0.2"));
            contacts.AddContact(new Contact("User2", "192.168.0.11"));
            contacts.AddContact(new Contact("User3", "192.168.0.15"));
            contacts.AddContact(new Contact("User4", "192.168.0.21"));
            contacts.AddContact(new Contact("User5", "192.168.0.25"));
            contacts.AddContact(new Contact("User6", "192.168.0.29"));
            contacts.AddContact(new Contact("User7", "192.168.0.101"));
            contacts.AddContact(new Contact("User8", "192.168.0.111"));
            contacts.AddContact(new Contact("User9", "192.168.0.212"));

            string json = JsonConvert.SerializeObject(contacts);
            Console.WriteLine(json);
            Console.WriteLine("Zapis do pliku...");
            using (StreamWriter writer = new StreamWriter("contacts.con"))
            {
                writer.Write(json);
            }
            string jsonread;
            Console.WriteLine("Odczyt z pliku...");
            using (StreamReader reader = new StreamReader("contacts.con"))
            {
                jsonread = reader.ReadToEnd();
            }
            Contacts cont = JsonHelp.DeserializeContacts(jsonread);
            cont.PrintAllContacts();
        }
        public static void HistoryTest()
        {
            Contact c1 = new Contact("User1", "192.168.0.2");
            Contact c2 = new Contact("User2", "192.168.0.11");
            Contact c3 = new Contact("User3", "192.168.0.15");
            Contact c4 = new Contact("User1", "192.168.0.2");
            History history = new History();
            history.AddRecord(new HistoryRecord(ME.contactName + "(" + ME.IPAddress + ")", "->", c1.contactName+"("+c1.IPAddress+")", DateTime.Now, "05:01.43", "Odebrany"));
            history.AddRecord(new HistoryRecord(ME.contactName + "(" + ME.IPAddress + ")", "<-", c2.contactName + "(" + c2.IPAddress + ")", DateTime.Now, "01:32.09", "Odebrany"));
            history.AddRecord(new HistoryRecord(ME.contactName + "(" + ME.IPAddress + ")", "<-", c3.contactName + "(" + c3.IPAddress + ")", DateTime.Now, "00:00.00", "Niedebrany"));
            history.AddRecord(new HistoryRecord(ME.contactName + "(" + ME.IPAddress + ")", "->", c3.contactName + "(" + c3.IPAddress + ")", DateTime.Now, "00:00.00", "Nieodebrany"));

            string json = JsonConvert.SerializeObject(history);
            Console.WriteLine(json);
            Console.WriteLine("Zapis do pliku...");
            using (StreamWriter writer = new StreamWriter("history.his"))
            {
                writer.Write(json);
            }
            string jsonread;
            Console.WriteLine("Odczyt z pliku...");
            using (StreamReader reader = new StreamReader("history.his"))
            {
                jsonread = reader.ReadToEnd();
            }
            Console.WriteLine("Parsowanie...");

            History hist = JsonHelp.DeserializeHistory(jsonread);

            hist.PrintAllContacts();
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