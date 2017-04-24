using Library.Controllers;
using Library.Exceptions;
using Library.Models.TableElements;
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

namespace Library.Views.AdminPages
{
    /// <summary>
    /// Interaction logic for EditingProfile.xaml
    /// </summary>
    public partial class EditingProfile : Window
    {
        EditingProfileController ec;
        ProfileSelect ps;
        bool isNew;
        public EditingProfile(bool isNew, int id, ProfileSelect ps)
        {
            InitializeComponent();
            ec = new EditingProfileController();
            this.ps = ps;
            this.isNew = isNew;
            if (isNew == true)
            {
                tbId.Text = ec.getIdProfile().ToString();
                comboBox.SelectedIndex = 0;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                Profile pr = DAO.GetProfileTable().GetElement(id);
                tbId.Text = pr.idProfile.ToString();
                tbId.IsEnabled = false;
                tbName.Text = pr.name;
                tbSurname.Text = pr.surname;
                tbTelephone.Text = pr.telephone;
                tbAddress.Text = pr.address;
                pbPassword.Password = pr.password;
                pbCheckPassword.Password = pr.password;
                if (pr.profileCategory.id == 1)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
                if(pr.profileStatus.id == 1)
                {
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    comboBox.SelectedIndex = 1;
                }
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int profileId = int.Parse(tbId.Text);
                string password = pbPassword.Password;
                string name = tbName.Text;
                string surname = tbSurname.Text;
                string telephone = tbTelephone.Text;
                string address = tbAddress.Text;
                int categoryId = -1;
                int statusId = -1;
                if (pbPassword.Password != pbCheckPassword.Password)
                    throw new PasswordException();
                switch (((ComboBoxItem)comboBox1.SelectedItem).Name)
                {
                    case "categoryReader":
                        categoryId = 1;
                        break;
                    case "categoryLibririan":
                        categoryId = 2;
                        break;
                }
                switch (((ComboBoxItem)comboBox.SelectedItem).Name)
                {
                    case "statusNormal":
                        statusId = 1;
                        break;
                    case "statusBlocked":
                        statusId = 2;
                        break;
                }
                EditingProfileController ec1 = new EditingProfileController();
                ec1.GetChanges(profileId, password, name, surname, telephone, address, categoryId, statusId);
                if (isNew == true)
                {
                    ec1.AddNewProfile();
                }
                else
                {
                    ec1.EditProfile();
                }
                if (ps.tbSearch.Text != "")
                ps.UpdateTable();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректно введені дані");
            }
            catch (PasswordException)
            {
                MessageBox.Show("Паролі не збігаються");
            }
        }
    }
}
