using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
        }
        private void restartRegisterWindow()
        {

            pbNewPassword.Password = "";
            pbCheckNewPassword.Password = "";
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader srPhone = File.OpenText("Client.txt");

            string phoneLine;
            bool checkPhoneResult = false;
            while ((phoneLine = srPhone.ReadLine()) != null)
            {

                string[] wordsClient = phoneLine.Split(' ');
                if (wordsClient[7] == tbPhone.Text)
                {
                    checkPhoneResult = true;
                    break;
                }

            }
            srPhone.Close();
            if (tbUserName.Text == "" || pbNewPassword.Password == "" || pbCheckNewPassword.Password == "")
            {
                MessageBox.Show("Uzupełnij dane");
                restartRegisterWindow();
                
            }
            else
            {
                StreamReader sr = File.OpenText("login.txt");
                string line;
                int count = 0;

                while ((line = sr.ReadLine()) != null)// przeszukiwanie czy nie ma już takiej nazwy użytkownika
                {
                    count++;
                    if (line.Substring(0, line.IndexOf(" ")) == tbUserName.Text)
                    {
                        MessageBox.Show("Istnieje taka nazwa użytkownika");

                        restartRegisterWindow();


                    }
                    
                }
                sr.Close();
                if (pbNewPassword.Password.Contains(" ") == true || tbUserName.Text.Contains(" ") == true)
                {
                    MessageBox.Show("Nazwa użytkownika i hasło nie może zawierać spacji");
                    restartRegisterWindow();
                }
                else
                {
                    if (pbNewPassword.Password != pbCheckNewPassword.Password)
                    {
                        MessageBox.Show("Hasła nie są takie same");
                        restartRegisterWindow();
                    }
                    else
                    {
                        if (!Regex.IsMatch(tbEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                            || !Regex.IsMatch(tbName.Text, @"^\p{Lu}\p{Ll}*$")
                            || !Regex.IsMatch(tbSurname.Text, @"^\p{Lu}\p{Ll}*$")
                            || tbPhone.Text.Length != 9 || !double.TryParse(tbPhone.Text, out double result))
                        {
                            MessageBox.Show("podano błędne dane");
                            restartRegisterWindow();
                        }
                       
                        else if (checkPhoneResult==true)
                        {
                            MessageBox.Show("Ten numer jest juz zarejstrowany");
                            restartRegisterWindow();
                        }
                        else
                        {
                            MessageBox.Show("Rejestracja przebiegła pomyślnie");
                            string id = Convert.ToString(count + 1);
                            Client client= new Client(tbUserName.Text, pbNewPassword.Password,id, tbName.Text,tbSurname.Text,tbPhone.Text,tbEmail.Text);
                            StreamWriter sw;
                            sw = new StreamWriter("Packages.txt", true);
                            sw.WriteLine("ID: " + (count+1)+";");
                            sw.Close();
                            sw = new StreamWriter("Operations.txt", true);
                            sw.WriteLine("ID: " + (count + 1) + ";");
                            sw.Close();
                            AccountBalance accountBalance = new AccountBalance(count+1);
                            this.DialogResult = true;
                            var dialog = new RegisterAnswear();
                            dialog.ShowDialog();
                        }
                    }
                }
                

            }
        }
    }
}
