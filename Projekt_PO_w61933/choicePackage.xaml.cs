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
        private void checkBalance(Package package, string balance)
        {
            if (package.addPackage(balance))
            {
                MessageBox.Show("Poprawnie dodano pakiet");
                this.DialogResult = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.showUserInterface(id);
            }
            else
            {
                MessageBox.Show("Za mało środków na koncie");
            }
        }
        private void bConfrim_Click(object sender, RoutedEventArgs e)
        {
            if (rbInterenet5GB.IsChecked==true)
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
            else if (rbSoloM.IsChecked == true)
            {
                string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                Package package = Package.soloM;
                checkBalance(package, balance);
            }

        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.showUserInterface(id);
        }

        private void rbSoloM_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nielimitowane minuty do wszyskich, 10GB internetu w Polsce i 3GB w UE");
        }
    }
}
