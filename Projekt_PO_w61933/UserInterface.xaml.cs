using System;
using System.Collections;
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
    /// Interaction logic for UserInterface.xaml
    /// </summary>
    public partial class UserInterface : Window
    {
        public int id;
        public UserInterface()
        {
            InitializeComponent();
        }

        private void bTopUpAccount_Click(object sender, RoutedEventArgs e)
        {
            //otwarcie okna odpowiedzialnego za doładowania
            this.DialogResult = true;
            var dialog = new PayWindow();
            dialog.id = this.id;
            dialog.ShowDialog();
        }

        private void bBuyPackage_Click(object sender, RoutedEventArgs e)
        {
            //otwarcie okna odpowiedzialnego za zakup pakietów
            this.DialogResult = true;
            var dialog = new choicePackage();
            dialog.id = this.id;
            dialog.ShowDialog();
        }

        private void bLogout_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            
            Application.Current.MainWindow.Show();
            

        }

        private void bShowPackages_Click(object sender, RoutedEventArgs e)
        {
            string clientPackages = File.ReadLines("Packages.txt").Skip(id - 1).Take(1).First();
            string[] wordsClientPackages = clientPackages.Split(';');
            wordsClientPackages[0] = null;
            
            this.DialogResult = true;
            var dialog = new ShowPackage();
            
            dialog.lbAllPackage.ItemsSource = wordsClientPackages;
            
            dialog.id = this.id;
            dialog.ShowDialog();
        }

        private void bOperations_Click(object sender, RoutedEventArgs e)
        {
            string clientOperations = File.ReadLines("Operations.txt").Skip(id - 1).Take(1).First();
            string[] wordsClientOperations = clientOperations.Split(';');
           

            this.DialogResult = true;
            var dialog = new OperationsWindow();
            Stack clientOperationsStack = new Stack();
            for (int i=1; i<wordsClientOperations.Length; i++)
            {
                clientOperationsStack.Push(wordsClientOperations[i]);
            }
            dialog.lbOperations.ItemsSource = clientOperationsStack;

            dialog.id = this.id;
            dialog.ShowDialog();
        }
    }
}
