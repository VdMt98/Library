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
using System.Windows.Shapes;
using Library.Exceptions;

namespace Library.Views.LibrarianPages
{
    /// <summary>
    /// Interaction logic for ReadGivenBookIndex.xaml
    /// </summary>
    public partial class ReadGivenBookIndex : Window
    {
        public ReadGivenBookIndex()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var c = new ReadGivenBookIndexController();
                int bookid = int.Parse(tbIndex.Text);
                c.GiveBook(bookid, Main.Instance.client.id);
                this.Close();
            }catch (GivingGivenBookException)
            {
                MessageBox.Show("Книга уже видана");
            } 
        }
    }
}
