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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_PO_w61933
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void showUserInterface( int count)
        {
            //pobranie danych klienta
            string client = File.ReadLines("Client.txt").Skip(count - 1).Take(1).First();                       
            string[] wordsClient = client.Split(' ');
            //pobranie stanu konta 
            string balance = File.ReadLines("AccountBalance.txt").Skip(count - 1).Take(1).First();            
            string[] wordsBalance = balance.Split(' ');


            
            
            var dialog = new UserInterface();

            //przypisanie danych użytkownika oraz stanu konta do wyświetlenia
            dialog.id = count;
            dialog.lWelcome.Content = "Witaj " + wordsClient[3] + ",";
            dialog.lNumber.Content = "Twój numer " + wordsClient[7];
            dialog.lBalance.Content = wordsBalance[3] + " PLN";
            dialog.lInternet.Content = wordsBalance[5] + " GB";
            dialog.lInternetEU.Content = wordsBalance[7] + " GB";
            dialog.lMinutes.Content = wordsBalance[9];
            dialog.ShowDialog();
        }
        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbUserName.Text != "" && pbPassword.Password != "")
            {
                string fullLogin = tbUserName.Text + " " + pbPassword.Password;
                
                StreamReader  sr = File.OpenText("login.txt");
                string line;
                bool correctLogin = false;
                int count = 0;
                while((line = sr.ReadLine()) != null)
                {
                    count++;
                    //sprawdzenie czy istnieją takie dane do logowania 
                    if(line == fullLogin)
                    {
                        MessageBox.Show("Poprawnie zalogowano");
                                              
                        correctLogin = true;
                        sr.Close();
                        this.Hide();
                        this.tbUserName.Text = "";
                        this.pbPassword.Password = "";

                        //otwarcie interfejsu użytkownika
                        showUserInterface(count);
                                            
                                               
                        break;
                    }
                    
                }
                if(correctLogin == false)
                {
                    MessageBox.Show("Niepoprawne dane logowania");
                    sr.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Wprowadź dane do logowania");
            }
        }

        private void bRegister_Click(object sender, RoutedEventArgs e)
        {
            //otworzenie okna rejestracji
            var dialog = new Rejestracja();
            dialog.ShowDialog();
            
        }
    }
}
