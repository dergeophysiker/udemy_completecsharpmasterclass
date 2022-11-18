using System;
using System.Collections;
using System.Collections.Generic;

namespace Coding.Exercise
{
    // TODO

    public static class Program
    {
        static public void Main(string[] args)
        {
            PhoneBook MyPhoneBook = new PhoneBook();

            /*
            Contact contact1 = new Contact("andy", "33423423");
            contact1.Call();
            MyPhoneBook.AddContact(contact1);
            */
            foreach (Contact contact in MyPhoneBook)
            {
                contact.Call();
            } 
        }
    }


    public class PhoneBook : IEnumerable<Contact>
    {
        //List<Contact> ContactList;
        List<Contact> Contacts;

        public PhoneBook()
        {
           // ContactList = new List<Contact>();//

            Contacts = new List<Contact>{
                new Contact("Andre", "435797087"),
                new Contact("Lisa", "435677087"),
                new Contact("Dine", "3457697087"),
                new Contact("Sofi", "4367697087")
            };

        }

        public void AddContact(Contact newContact)
        {
            Contacts.Add(newContact);
        }

        IEnumerator<Contact> IEnumerable<Contact>.GetEnumerator()
        {
            return Contacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public Contact(string name,string number)
        {
            Name = name;
            Number = number;
        }
        public void Call()
        {
            Console.WriteLine($"Calling to {Name}. Phone number is {Number}");
        }
    }


}