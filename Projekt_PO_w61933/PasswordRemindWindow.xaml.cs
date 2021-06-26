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
    /// Interaction logic for PasswordRemindWindow.xaml
    /// </summary>
    public partial class PasswordRemindWindow : Window
    {
        public int id;
        public string answear;
        public PasswordRemindWindow()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Application.Current.MainWindow.Show();
        }

        private void bConfrim_Click(object sender, RoutedEventArgs e)
        {
            if(tbAnswear.Text == answear)
            {
                if (pbNewPassword.Password == "" || pbCheckNewPassword.Password == "")
                {
                    MessageBox.Show("Uzupełnij dane");
                }
                else
                {
                    if (pbCheckNewPassword.Password == pbNewPassword.Password)
                    {
                        string login = File.ReadLines("Login.txt").Skip(id - 1).Take(1).First();
                        
                        User user = new User(login);
                        user.changePassword(pbNewPassword.Password, id);
                        MessageBox.Show("Pomyślnie zmieniono hasło");
                        this.DialogResult = true;
                        Application.Current.MainWindow.Show();

                    }
                    else
                    {
                        MessageBox.Show("Hasła nie są takie same");
                    }
                }
            }
            else
            {
                MessageBox.Show("Niepoprawna odpowiedź");
            }
        }
    }
}
