using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONTesting
{
    class JsonHelp
    {
        public static History DeserializeHistory(string JSON)
        {
            JObject o = JObject.Parse(JSON);
            JArray a = (JArray)o["history"];
            IList<HistoryRecord> history = a.ToObject<IList<HistoryRecord>>();
            History hist = new History(history);

            return hist;
        }
        public static Contacts DeserializeContacts(string JSON)
        {
            JObject o = JObject.Parse(JSON);
            JArray a = (JArray)o["contacts"];
            IList<Contact> contacts2 = a.ToObject<IList<Contact>>();
            Contacts cont = new Contacts(contacts2);
            return cont;
        }
    }
}
