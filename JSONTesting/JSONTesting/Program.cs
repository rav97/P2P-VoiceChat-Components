using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONTesting
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("Parsowanie...");
            JObject o = JObject.Parse(jsonread);
            JArray a = (JArray)o["contacts"];

            IList<Contact> contacts2 = a.ToObject<IList<Contact>>();

            Contacts cont = new Contacts(contacts2);
            cont.PrintAllContacts();

        }
    }
}