using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    public class AccountBalance
    {
        protected int internet;
        public double balance;
        protected int internetEU;
        protected string minutes;
        public int id;
        public void changeBalance(double amount)
        {
            //przypisanie aktualnego stanu konta do zmiennej tymczasowej
            double oldBalance = this.balance;
            
            this.balance += amount;
            
            //pobranie rekordu z pliku klienta
            string client = File.ReadLines("AccountBalance.txt").Skip(this.id - 1).Take(1).First();
            //przypisanie rekordu do zmiennej tymczasowej
            string oldBalanceText = client;
            //zamienienie wartości starych na nowe w rekordzie
            client = client.Replace("Balance: " + oldBalance, "Balance: " + this.balance);
            //zapisanie do zmiennej całej zawartości pliku
            string balancetxt = File.ReadAllText("AccountBalance.txt");
            //wymiana rekordu starego na nowy
            balancetxt = balancetxt.Replace(oldBalanceText, client);
            //zapisanie całego pliku na nowo
            File.WriteAllText("AccountBalance.txt", balancetxt);
        }
        public void topUpInternet(int transferInternet)
        {
            int oldInternet = this.internet;
            this.internet += transferInternet;
            string client = File.ReadLines("AccountBalance.txt").Skip(this.id - 1).Take(1).First();
            string oldInternetText = client;
            client = client.Replace("Internet: " + oldInternet, "Internet: " + this.internet);
            string balancetxt = File.ReadAllText("AccountBalance.txt");
            balancetxt = balancetxt.Replace(oldInternetText, client);
            File.WriteAllText("AccountBalance.txt", balancetxt);
        }
        public void topUpInternetEU(int transferInternet)
        {
            int oldInternet = this.internetEU;
            this.internetEU += transferInternet;
            string client = File.ReadLines("AccountBalance.txt").Skip(this.id - 1).Take(1).First();
            string oldInternetText = client;
            client = client.Replace("InternetEU: " + oldInternet, "InternetEU: " + this.internetEU);
            string balancetxt = File.ReadAllText("AccountBalance.txt");
            balancetxt = balancetxt.Replace(oldInternetText, client);
            File.WriteAllText("AccountBalance.txt", balancetxt);
        }
        public void topUpMinutes(string transferMinutes)
        {
            //sprawdzenie czy liczbowe minuty czy nielimitowane 
            if(int.TryParse(transferMinutes, out int result)&& int.TryParse(this.minutes, out int result1))
            {
                string oldMinutes = this.minutes;
                int minutes = Convert.ToInt32(this.minutes);
                int tMinutes = Convert.ToInt32(transferMinutes);
                minutes += tMinutes;
                this.minutes = minutes.ToString();
                string client = File.ReadLines("AccountBalance.txt").Skip(this.id - 1).Take(1).First();
                string oldMinutesText = client;
                client = client.Replace("Minutes: " + oldMinutes, "Minutes: " + this.minutes);
                string minutestxt = File.ReadAllText("AccountBalance.txt");
                minutestxt = minutestxt.Replace(oldMinutesText, client);
                File.WriteAllText("AccountBalance.txt", minutestxt);
            }
            else if (!int.TryParse(transferMinutes, out int result2)|| !int.TryParse(this.minutes, out int result3))
            {
                string oldMinutes = this.minutes;

                this.minutes = transferMinutes;
                string client = File.ReadLines("AccountBalance.txt").Skip(this.id - 1).Take(1).First();
                string oldMinutesText = client;
                client = client.Replace("Minutes: " + oldMinutes, "Minutes: " + this.minutes);
                string minutestxt = File.ReadAllText("AccountBalance.txt");
                minutestxt = minutestxt.Replace(oldMinutesText, client);
                File.WriteAllText("AccountBalance.txt", minutestxt);
            }
            
        }

        public AccountBalance()
        {

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
