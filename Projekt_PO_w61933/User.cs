using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    class User
    {
        protected string userName;
        protected string password;
        public string returnUserName()
        {
            return userName;
        }
        public void changePassword(string newPassword, int  id)
        {          
            
            string login = File.ReadLines("Login.txt").Skip(id - 1).Take(1).First();            
            string oldPassword = this.password;
            this.password = newPassword;            
            string oldLoginText = login;
            login = login.Replace(this.userName+" " + oldPassword, this.userName + " " + newPassword);
            string logintxt = File.ReadAllText("Login.txt");
            logintxt = logintxt.Replace(oldLoginText, login);
            File.WriteAllText("Login.txt", logintxt);//błąd


        }
        public User()
        {

        }
        public User(string fullLogin)
        {
            string[] login = fullLogin.Split(' ');
            this.userName = login[0];
            this.password = login[1];
        }
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            StreamWriter sw;
            sw = new StreamWriter("Login.txt", true);
            
            sw.WriteLine(this.userName + " " + this.password);
            sw.Close();
        }
    }
    
}
