using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    class User
    {
        protected string userName;
        protected string password;
        public string UserName
        {
            get => userName;
        }
        public void changePassword(bool correctAnswer, string newPassword)
        {
            if(correctAnswer== true)
            {

            }
        }
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
