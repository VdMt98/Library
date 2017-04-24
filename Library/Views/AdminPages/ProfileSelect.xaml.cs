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

namespace Library.Views.AdminPages
{
    /// <summary>
    /// Interaction logic for ProfileSelect.xaml
    /// </summary>
    public partial class ProfileSelect : Page
    {
        public ProfileSelect()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tbSearch.Text);

        }
    }
}
