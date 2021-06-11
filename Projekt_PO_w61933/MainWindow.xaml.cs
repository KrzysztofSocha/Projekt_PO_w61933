﻿using System;
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

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbUserName.Text != "" && pbPassword.Password != "")
            {
                string fullLogin = tbUserName.Text + " " + pbPassword.Password;
                
                StreamReader  sr = File.OpenText("login.txt");
                string line;
                bool correctLogin = false;
                while((line = sr.ReadLine()) != null)
                {
                    if(line == fullLogin)
                    {
                        MessageBox.Show("Poprawnie zalogowano");
                        correctLogin = true;
                        sr.Close();
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
            var dialog = new Rejestracja();
            if (dialog.ShowDialog() == true)
            {
               
            }
        }
    }
}
