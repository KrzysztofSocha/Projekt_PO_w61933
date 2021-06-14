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
        private string minutes;
        private int id;
        public void topUpAccount(double amount )
        {
            double oldBalance = this.balance;
            this.balance += amount;
            string balance = File.ReadLines("AccountBalance.txt").Skip(this.id - 1).Take(1).First();
            string oldBalanceText = balance;
            balance = balance.Replace("Balance: " + oldBalance, "Balance: " + this.balance);
            string balancetxt = File.ReadAllText("AccountBalance.txt");
            balancetxt = balancetxt.Replace(oldBalanceText, balance);
            File.WriteAllText("AccountBalance.txt", balancetxt);
        }
        
        public AccountBalance(int id)
        {
            this.balance = 0.0;
            this.internet = 0;
            this.internetEU = 0;
            this.minutes = "0";
            this.id = id;
            StreamWriter sw;
            sw = new StreamWriter("AccountBalance.txt", true);
            sw.WriteLine("ID: " + this.id +" Balance: " + this.balance+ " Internet: " +this.internet +" InternetEU: " +this.internetEU + " Minutes: " + this.minutes );
            sw.Close();

        }
        public AccountBalance(string balance)
        {
            
            
            string[] wordsBalance = balance.Split(' ');
            this.id = Convert.ToInt32(wordsBalance[1]);
            this.balance = Convert.ToDouble(wordsBalance[3]);
            this.internet = Convert.ToInt32(wordsBalance[5]);
            this.internetEU = Convert.ToInt32(wordsBalance[7]);
            this.minutes = wordsBalance[9];
        }
    }
}
