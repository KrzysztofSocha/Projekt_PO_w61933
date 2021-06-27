using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt_PO_w61933
{
    /// <summary>
    /// Interaction logic for choicePackage.xaml
    /// </summary>
    public partial class choicePackage : Window
    {
        public choicePackage()
        {
            InitializeComponent();
        }
        public int id;
        //procedura odpowiedzialna za sprawdzenie czy stan konta jest wystarczający do zakupu danego pakietu
        private void checkBalance(Package package, string balance)
        {
            if (package.addPackage(balance))
            {
                MessageBox.Show("Poprawnie dodano pakiet");
                this.DialogResult = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.showUserInterface(id);
                mainWindow.Close();
            }
            else
            {
                MessageBox.Show("Za mało środków na koncie");
            }
        }
        private void bConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (rbInternet2GB.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.internet2GB;
                checkBalance(package, balance);

            }
            else if (rbInternet5GB.IsChecked==true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.internet5GB;
                checkBalance(package, balance);
                
            }
            else if(rbMinutes100.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.minutes100;
                checkBalance(package, balance);
            }
            else if (rbMinutes300.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.minutes300;
                checkBalance(package, balance);
            }
            else if (rbSoloS.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.soloS;
                checkBalance(package, balance);
            }
            else if (rbSoloM.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.soloM;
                checkBalance(package, balance);
            }
            else if (rbInternet1GBEU.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.internet1GBEU;
                checkBalance(package, balance);

            }
            else if (rbInternet5GBEU.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.internet5GBEU;
                checkBalance(package, balance);

            }

        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MainWindow mainWindow = new MainWindow();
            
            mainWindow.showUserInterface(id);
            mainWindow.Close();
        }

        private void rbSoloM_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nielimitowane minuty do wszyskich, 10GB internetu w Polsce i 3GB w UE");
        }

        private void rbSoloS_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nielimitowane minuty do wszyskich, 3GB internetu w Polsce");
        }
    }
}
