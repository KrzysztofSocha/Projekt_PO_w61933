using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    class Client : User
    {
        public string name;
        public string surname;
        public string phone;
        public string email;
        public string id;
        public bool checkPhone()
        {
            StreamReader sr = File.OpenText("Client.txt");
            string line;

            bool checkResult = false;
            while ((line = sr.ReadLine()) != null)
            {

                string[] wordsClient = line.Split(' ');
                if (wordsClient[7] == this.phone)
                {
                    checkResult = true;
                }

            }
            sr.Close();
            return checkResult;
        }
        public Client(string phone)
        {
            this.phone = phone;
        }
        public Client(string userName, string password, string id, string name, string surname, string phone, string email)
            :base( userName, password)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
            StreamWriter sw;
            sw = new StreamWriter("Client.txt", true);
            sw.WriteLine("ID: "+this.id+" Name: "+this.name+" Surname: "+this.surname+" Phone: "+this.phone+" Email: "+this.email);
            sw.Close();
        }
    }
}
