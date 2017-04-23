using Library.Controllers;
using Library.Models;
using Library.Models.TableElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        SearchClientController sc;
        public Search()
        {
            
            InitializeComponent();
            lbId.Content = Main.Instance.client.id;
            lbName.Content = Main.Instance.client.name;
            lbSurname.Content = Main.Instance.client.surname;
            lbTepephone.Content = Main.Instance.client.telephone;
            lbAddress.Content = Main.Instance.client.address;
            sc = new SearchClientController();
            ObservableCollection<BookRow> list = sc.Startup();
            dataGrid.ItemsSource = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string quarry = tbSearch.Text;
            bool isForName;
            if ((((ComboBoxItem)cbType.SelectedItem).Name) == "ForName")
                isForName = true;
            else
                isForName = false;
            ObservableCollection<Book> list = sc.getSearchedList(quarry, isForName) ;
            dataGrid1.ItemsSource = list;
        }
    }
}
