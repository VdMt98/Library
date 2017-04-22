using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.TableElements
{
    public class Profile:BaseTableElement
    {
        public int idProfile { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public ProfileStatus profileStatus { get; set; }
        public ProfileCategory profileCategory { get; set; }


        public Profile(int id, int idProfile, string password, string name, string surname, 
            string telephone, string address, ProfileStatus profileStatus, ProfileCategory profileCategory):base(id)
        {
            
            this.idProfile = idProfile;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.telephone = telephone;
            this.address = address;
            this.profileStatus = profileStatus;
            this.profileCategory = profileCategory;
        }

        public override string ToString()
        {
            return String.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}; {7};", idProfile.ToString(), password, name, surname, telephone, address, profileStatus.ToString(), profileCategory.ToString() );
        }

    }
}
