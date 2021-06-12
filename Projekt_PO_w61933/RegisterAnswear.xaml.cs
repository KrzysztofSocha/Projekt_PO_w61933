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
    /// Interaction logic for RegisterAnswear.xaml
    /// </summary>
    public partial class RegisterAnswear : Window
    {
        public RegisterAnswear()
        {
            InitializeComponent();
        }

        private void bConfrim_Click(object sender, RoutedEventArgs e)
        {
            if(tbQuestion.Text != "" && tbAnswear.Text != "")
            {
                StreamWriter sw;
                sw = new StreamWriter("Questions.txt", true);
                sw.WriteLine(tbQuestion.Text + " : " + tbAnswear.Text);
                sw.Close();
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Uzuełnij dane");
                this.DialogResult = true;
                var dialog = new RegisterAnswear();
                dialog.ShowDialog();
            }
        }
    }
}
