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
using Library.Views.AdminPages;
using Library.Controllers;

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
            var ac = new AdminMainWindowController();
            string[] inf = ac.setMainInformation();
            lbSurname.Content = inf[0];
            lbName.Content = inf[1];
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        { 
            profileEditin.IsEnabled = true;
            profileEditin.Background = Brushes.White;
            BookEditing.IsEnabled = true;
            BookEditing.Background = Brushes.White;

            MenuItem selected = (MenuItem)sender;
            selected.IsEnabled = false;
            selected.Background = Brushes.LightGray;

            switch (selected.Name)
            {
                case "profileEditin":
                    frame.NavigationService.Navigate(new Uri("Views/AdminPages/ProfileSelect.xaml", UriKind.Relative));
                    break;
                
            }
        }
    }
}
