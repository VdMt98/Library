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
using Library.Controllers;
using Library.Models.Tables;
using Library.Models.TableElements;

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
            int bookId = 1;
            List<Book> list = DAO.GetBookTable().GetBooksInuseByRecipientId(1);
            foreach (var book in list)
            {
                MessageBox.Show(book.ToString());
            }
            
        }
    }
}
