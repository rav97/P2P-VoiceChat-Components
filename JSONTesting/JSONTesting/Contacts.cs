using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONTesting
{
    class Contacts
    {
        public List<Contact> contacts;

        public Contacts()
        {
            this.contacts = new List<Contact>();
        }
        public Contacts(IList<Contact> cs)
        {
            this.contacts = cs.ToList<Contact>();
        }
        public void AddContact(Contact c)
        {
            this.contacts.Add(c);
        }
        public void DeleteContact(Contact c)
        {
            this.contacts.Remove(c);
        }
        public void PrintAllContacts()
        {
            foreach (Contact c in this.contacts)
            {
                Console.WriteLine("{0} : {1}",c.contactName, c.IPAddress);
            }
        }
    }
}
