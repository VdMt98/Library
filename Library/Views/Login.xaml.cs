﻿using System;
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
using Library.Controllers;
using Library.Models.Tables;
using Library.Models.TableElements;
using MySql.Data.MySqlClient;

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //int login = int.Parse(tbLogin.Text);
            //String password = pbPassword.Password;

            try
            {
                //int login = int.Parse(tbLogin.Text);
                //String password = pbPassword.Password;
                LoginController lg = new LoginController();
                //lg.LogIn(login, password, this);
                lg.LogIn(123460, "bibl", this);
            }
            catch(FormatException)
            {
                MessageBox.Show("Некоректно введені дані");
            }
            catch (MySqlException)
            {
                MessageBox.Show("Неправильно введені id або пароль");
            }

        }
    }
}
