using Library.Controllers;
using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.Views.LibrarianPages
{
    /// <summary>
    /// Interaction logic for ReaderLoginization.xaml
    /// </summary>
    public partial class ReaderLoginization : Page
    {
        
        public ReaderLoginization()
        {
            InitializeComponent();
            tbLogin.Text = "123456";
            pbPassword.Password = "user";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int login = int.Parse(tbLogin.Text);
                String password = pbPassword.Password;
                ReaderLoginizationController rc = new ReaderLoginizationController();
                rc.LogIn(login, password);
                NavigationService.Navigate(new Search());
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
