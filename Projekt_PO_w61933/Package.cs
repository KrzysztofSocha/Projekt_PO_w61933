using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    class Package: AccountBalance
    {
        protected double price = 0;
        protected string namePackage;
        //utworzenie obiektów statycznych z możliwością tylko odczytu,
        // każdy pakiet musi być ręcznie dodany przez administratora
        public static readonly Package internet5GB = new Package(15.0, "internet 5GB", "0", 5, 0);
        public static readonly Package internet2GB = new Package(6.0, "internet 2GB", "0", 2, 0);
        public static readonly Package minutes100 = new Package(20.0, "100 Minut", "100", 0, 0);
        public static readonly Package minutes300 = new Package(35.0, "300 Minut", "300", 0, 0);
        public static readonly Package soloM = new Package(25.0, "Formuła Solo M", "nielimitowane", 10, 3);
        public static readonly Package soloS = new Package(20.0, "Formuła Solo S", "nielimitowane", 3, 0);
        public static readonly Package internet1GBEU = new Package(15.0, "internet 1GB EU", "0", 0, 1);
        public static readonly Package internet5GBEU = new Package(40.0, "internet 5GB EU", "0", 0, 5);
        
        private void addPackageToFile(int id)
        {
            string packageState = File.ReadLines("Packages.txt").Skip(id - 1).Take(1).First();
            string oldPackageState = packageState;
            packageState += this.namePackage+";" ;
            string packagestxt = File.ReadAllText("Packages.txt");
            //wymiana rekordu starego na nowy
            packagestxt = packagestxt.Replace(oldPackageState, packageState);
            //zapisanie całego pliku na nowo
            File.WriteAllText("Packages.txt", packagestxt);
        }
        //funkcja boolowska opwiedzialna za zmiane stanu konta po dodaniu nowego pakietu
        //zwraca true kiedy środki na koncie pozwalają na dodanie pakietu, w przeciwnym razie zwraca false
        public bool addPackage(string balance)
        {
            
            AccountBalance accountBalance = new AccountBalance(balance);
            if (accountBalance.balance >= this.price)
            {


                accountBalance.changeBalance(this.price * -1);


                if(this.minutes.Length > 3)
                {
                    accountBalance.topUpMinutes(this.minutes);
                    
                }
                else
                {
                    if (this.minutes !="0")
                    {
                        accountBalance.topUpMinutes(this.minutes);
                    }
                }
                
                if (this.internet != 0)
                {

                    accountBalance.topUpInternet(this.internet);
                }
                if (this.internetEU != 0)
                {
                    accountBalance.topUpInternetEU(this.internetEU);
                }
                addPackageToFile(accountBalance.id);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //dodanie usuwania pakietów
        
        
        //konstruktor klasy Package z prywatnym dostępem
        private Package(double price, string namePackage, string transferMinutes, int transferInternet, int transferInternetEU  )
        {
            this.price = price;
            this.namePackage = namePackage;
            this.minutes = transferMinutes;
            this.internet = transferInternet;
            this.internetEU = transferInternetEU;
        }
        

    }
}
