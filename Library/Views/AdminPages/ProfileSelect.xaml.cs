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
using Library.Controllers;
using Library.Models.TableElements;
using System.Collections.ObjectModel;
using Library.Exceptions;

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
            int idProfile = int.Parse(tbSearch.Text);
            var pc = new ProfileSelectController();
            ObservableCollection<Profile> list = pc.getSearchedProfiles(idProfile);
            dataGrid1.ItemsSource = list;
            
        }

        private void btnAddNewProfile_Click(object sender, RoutedEventArgs e)
        {
            var ep = new EditingProfile(true, -1, this);
            ep.Show();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Profile pr = (Profile)dataGrid1.SelectedItem;
                if (pr.profileCategory.id == 3)
                    throw new EditingAdminException();
                
                var ep = new EditingProfile(false, pr.id, this);
                ep.Show();
            }
            catch (EditingAdminException)
            {
                MessageBox.Show("Неможливо редагувати дані адміністратора");
            }catch (System.NullReferenceException)
            {
                MessageBox.Show("Не вибрано профіль для редагування");
            }
        }
        public void UpdateTable()
        {
            int idProfile = int.Parse(tbSearch.Text);
            var pc = new ProfileSelectController();
            ObservableCollection<Profile> list = pc.getSearchedProfiles(idProfile);
            dataGrid1.ItemsSource = list;
        }
    }
}
