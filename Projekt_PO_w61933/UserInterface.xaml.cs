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
            this.DialogResult = true;
            var dialog = new PayWindow();
            dialog.id = this.id;
            dialog.ShowDialog();
        }

        private void bBuyPackage_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            var dialog = new choicePackage();
            dialog.id = this.id;
            dialog.ShowDialog();
        }
    }
}
