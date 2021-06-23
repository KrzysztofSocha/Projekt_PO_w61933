using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    class Package: AccountBalance
    {
        protected double price = 0;
        protected string namePackage;
        public static readonly Package internet5GB = new Package(15.0, "internet5GB", "0", 5, 0);
        public static readonly Package internet2GB = new Package(6.0, "internet2GB", "0", 2, 0);
        public static readonly Package minutes100 = new Package(20.0, "100Minut", "100", 0, 0);
        public static readonly Package soloM = new Package(25.0, "FormułaSoloM", "nielimitowane", 10, 3);
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
                    if (Convert.ToInt32(this.minutes) != 0)
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
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //dodanie usuwania pakietów
        
        //obiekty statyczne 
        
        public Package(double price, string namePackage, string transferMinutes, int transferInternet, int transferInternetEU  )
        {
            this.price = price;
            this.namePackage = namePackage;
            this.minutes = transferMinutes;
            this.internet = transferInternet;
            this.internetEU = transferInternetEU;
        }
        

    }
}
