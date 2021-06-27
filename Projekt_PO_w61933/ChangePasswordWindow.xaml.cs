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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public int id;
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.showUserInterface(id);
            mainWindow.Close();
        }

        private void bConfirm_Click(object sender, RoutedEventArgs e)
        {
            string login = File.ReadLines("Login.txt").Skip(id - 1).Take(1).First();

            User user = new User(login);
            if (user.checkPassword(pbPassword.Password))
            {


                if (pbNewPassword.Password == "" || pbCheckNewPassword.Password == "")
                {
                    MessageBox.Show("Uzupełnij dane do ponownego logowania");
                }
                else
                {
                    if (pbCheckNewPassword.Password == pbNewPassword.Password)
                    {

                        user.changePassword(pbNewPassword.Password, id);
                        MessageBox.Show("Pomyślnie zmieniono hasło");
                        this.DialogResult = true;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.showUserInterface(id);
                        mainWindow.Close();

                    }
                    else
                    {
                        MessageBox.Show("Hasła nie są takie same");
                    }
                }
            }
            else
            {
                MessageBox.Show("Niepoprawne hasło");
            }
        }
    }
}
