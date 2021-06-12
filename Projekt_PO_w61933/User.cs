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
        public void changePassword(bool correctAnswear, string newPassword)
        {
            if(correctAnswear== true)
            {

            }
        }
        public User()
        {

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
