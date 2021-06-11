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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (tbUserName.Text == "" || pbNewPassword.Password == "" || pbCheckNewPassword.Password == "")
            {
                MessageBox.Show("Uzupełnij dane");
                this.DialogResult = true;
                var dialog = new Rejestracja();
                dialog.ShowDialog();
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

                        this.DialogResult = true;
                        var dialog = new Rejestracja();
                        dialog.ShowDialog();


                    }

                }
                if (pbNewPassword.Password.Contains(" ") == true || tbUserName.Text.Contains(" ") == true)
                {
                    MessageBox.Show("Nazwa użytkownika i hasło nie może zawierać spacji");
                    this.DialogResult = true;
                    var dialog = new Rejestracja();
                    dialog.ShowDialog();
                }
                else
                {
                    if (pbNewPassword.Password != pbCheckNewPassword.Password)
                    {
                        MessageBox.Show("Hasła nie są takie same");
                        this.DialogResult = true;
                        var dialog = new Rejestracja();
                        dialog.ShowDialog();
                    }
                    else
                    {
                        if (!Regex.IsMatch(tbEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                            || !Regex.IsMatch(tbName.Text, @"^[A-Z][a-zA-Z]*$")
                            || !Regex.IsMatch(tbSurname.Text, @"^[A-Z][a-zA-Z]*$")
                            )
                        {
                            MessageBox.Show("podano błędne dane");
                        }
                    }
                }
                this.DialogResult = true;

            }
        }
    }
}
