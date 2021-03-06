using System;
using System.Collections.Generic;
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
    /// Interaction logic for OperationsWindow.xaml
    /// </summary>
    public partial class OperationsWindow : Window
    {
        public int id;
        public OperationsWindow()
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
    }
}
