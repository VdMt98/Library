using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class Profile
    {
        int id { get; set; }
        int idProfile { get; set; }
        string password { get; set; }
        string name { get; set; }
        string surname { get; set; }
        string telephone { get; set; }
        string address { get; set; }
        ProfileStatus profileStatus { get; set; }
        ProfileCategory profileCategory { get; set; }

        public Profile() { }

        public Profile(int id, int idProfile, string password, string name, string surname, 
            string telephone, string address, ProfileStatus profileStatus, ProfileCategory profileCategory)
        {
            this.id = id;
            this.idProfile = idProfile;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.telephone = telephone;
            this.address = address;
            this.profileStatus = profileStatus;
            this.profileCategory = profileCategory;
        }

    }
}
