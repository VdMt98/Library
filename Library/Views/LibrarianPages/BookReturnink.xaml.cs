using Library.Controllers;
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
using Library.Exceptions;

namespace Library.Views.LibrarianPages
{
    /// <summary>
    /// Interaction logic for BookReturnink.xaml
    /// </summary>
    public partial class BookReturnink : Page
    {
        public BookReturnink()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var c = new BookReturninkController();
                int bookid = int.Parse(tbbookId.Text);
                c.ReturnBook(bookid);
                MessageBox.Show("Книгу повернено");
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректно введений код книги");
            }catch (TakingTakenBookExceptino)
            {
                MessageBox.Show("Книга уже повернена раніше");
            }
        }
    }
}
