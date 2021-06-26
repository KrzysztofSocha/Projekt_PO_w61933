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
    /// Interaction logic for ShowPackage.xaml
    /// </summary>
    public partial class ShowPackage : Window
    {
        public int id;
        
        public ShowPackage()
        {
            InitializeComponent();
            
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.showUserInterface(id);
            mainWindow.Close();
        }

        private void bDeletePackage_Click(object sender, RoutedEventArgs e)
        {
            if (lbAllPackage.SelectedIndex > -1)
            {
                if (lbAllPackage.SelectedItem.ToString() != "")
                {
                    MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz wyłączyć ten pakiet?", "",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question);
                    if (lbAllPackage.SelectedIndex > 0 && result == MessageBoxResult.Yes)
                    {

                        string selectedPackage = lbAllPackage.SelectedItem.ToString();
                        string packageState = File.ReadLines("Packages.txt").Skip(id - 1).Take(1).First();
                        string oldPackageState = packageState;
                        packageState = packageState.Replace(selectedPackage + ';', "");
                        string packagestxt = File.ReadAllText("Packages.txt");

                        packagestxt = packagestxt.Replace(oldPackageState, packageState);

                        File.WriteAllText("Packages.txt", packagestxt);
                        MessageBox.Show("Wyłączyłeś pakiet: " + selectedPackage);
                        OperationsUser operationsUser = new OperationsUser("Wyłączenie pakietu:", selectedPackage, id);
                        this.DialogResult = true;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.showUserInterface(id);
                        mainWindow.Close();
                    }
                    
                }
            }
            else if (lbAllPackage.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrałeś pakietu");
            }

        }
    }
}
