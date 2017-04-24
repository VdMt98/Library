using Library.Models.TableElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class ProfileSelectController
    {
        public ObservableCollection<Profile> getSearchedProfiles(int idProfile)
        {
            ObservableCollection<Profile> res = new ObservableCollection<Profile>(DAO.GetProfileTable().GetProfileByIdProfile(idProfile));
            return res;
        }
    }
}
