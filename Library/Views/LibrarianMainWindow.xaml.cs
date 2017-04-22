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

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for LibrarianMainWindow.xaml
    /// </summary>
    public partial class LibrarianMainWindow : Window
    {
        public LibrarianMainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            search.IsEnabled = true;
            search.Background = Brushes.White;
            issuance.IsEnabled = true;
            issuance.Background = Brushes.White;
            returning.IsEnabled = true;
            returning.Background = Brushes.White;

            MenuItem selected = (MenuItem)sender;
            selected.IsEnabled = false;
            selected.Background = Brushes.LightGray;
            switch (selected.Name)
            {
                case "returning":
                    frame.NavigationService.Navigate(new Uri("Views/LibrarianPages/BookReturnink.xaml", UriKind.Relative));
                    break;
                case "issuance":
                    frame.NavigationService.Navigate(new Uri("Views/LibrarianPages/ReaderLoginization.xaml", UriKind.Relative));
                    break;
            }
        }
    }
}
