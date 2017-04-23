using Library.Controllers;
using Library.Models;
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
using System.Windows.Shapes;

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for ReaderMainWindow.xaml
    /// </summary>
    public partial class ReaderMainWindow : Window
    {
        public ReaderMainWindow()
        {
            InitializeComponent();
            ReaderMainWindowController rm = new ReaderMainWindowController();
            ObservableCollection<BookRow> col = rm.createTable();
            dataGrid.ItemsSource = col;
        }
    }
}
