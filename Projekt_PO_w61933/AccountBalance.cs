using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    class AccountBalance
    {
        private int internet;
        private double balance;
        private int internetEU;
        private int minutes;
        private int id;
        
        public AccountBalance(int id)
        {
            this.balance = 0.0;
            this.internet = 0;
            this.internetEU = 0;
            this.minutes = 0;
            this.id = id;
            StreamWriter sw;
            sw = new StreamWriter("AccountBalance.txt", true);
            sw.WriteLine("ID: " + this.id +" Balance: " + this.balance+ " Internet: " +this.internet +" InternetEU: " +this.internetEU + " Minutes: " + this.minutes );
            sw.Close();

        }
    }
}
