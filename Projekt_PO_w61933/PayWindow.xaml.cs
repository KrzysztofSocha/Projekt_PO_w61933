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
    /// Interaction logic for PayWindow.xaml
    /// </summary>
    public partial class PayWindow : Window
    {
        public PayWindow()
        {
            InitializeComponent();
        }
        public int id;
        bool bankCheck = false;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(tbAmount.Text==""|| Convert.ToDouble(tbAmount.Text) <= 0 || !double.TryParse(tbAmount.Text, out double result))
            {
                MessageBox.Show("Wprowadź poprawną kwotę doładowania");

            }
            else
            {
                if(rbBlik.IsChecked == true && tbBlik.Text.Length == 6 && double.TryParse(tbBlik.Text, out double result1))
                {
                    MessageBox.Show("Poprawnie doładowano konto");
                    string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                    AccountBalance accountBalance = new AccountBalance(balance);
                    accountBalance.changeBalance(Convert.ToDouble(tbAmount.Text));
                    this.DialogResult = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.showUserInterface(id);
                }
                else if(rbBlik.IsChecked == true && (tbBlik.Text.Length != 6 || !double.TryParse(tbBlik.Text, out double result2)))
                {
                    MessageBox.Show("Niepoprawny kod Blik");
                }
                else if (rbTransfer.IsChecked == true && bankCheck == true )
                {
                    
                    MessageBox.Show("Poprawnie doładowano konto");
                    string balance = File.ReadLines("AccountBalance.txt").Skip(id - 1).Take(1).First();
                    AccountBalance accountBalance = new AccountBalance(balance);
                    accountBalance.changeBalance(Convert.ToDouble(tbAmount.Text));
                    
                    
                    this.DialogResult = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.showUserInterface(id);
                }
                else
                {
                    MessageBox.Show("Uzupełnij dane do transakcji");
                }
            }
        }

        private void rbBlik_Checked(object sender, RoutedEventArgs e)
        {
            lBlik.Visibility = Visibility.Visible;
            tbBlik.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Hidden;
            spBanks.Visibility = Visibility.Hidden;
        }

        private void rbTransfer_Checked(object sender, RoutedEventArgs e)
        {
            lBlik.Visibility = Visibility.Hidden;
            tbBlik.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            spBanks.Visibility = Visibility.Visible;
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;
        }

        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;
        }

        private void radioButton5_Checked(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;
        }

        private void radioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            bankCheck = true;

        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
           
            this.DialogResult = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.showUserInterface(id);
        }
    }
}
