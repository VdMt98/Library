using Library.Models.TableElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class EditingProfileController
    {
        Profile pr;
        public int getIdProfile()
        {
            int id = DAO.GetProfileTable().GetMaxIdProfile();
            id++;
            return id;
        }

        public void GetChanges(int idProfile, string password, string name, string surname, string telephone, 
            string address, int categoryId, int statusId)
        {
            pr = new Profile(-1, idProfile, password, name, surname, telephone, address, 
                new ProfileStatus(statusId, null), new ProfileCategory(categoryId, null));
        }

        public void AddNewProfile()
        {
            DAO.GetProfileTable().InsertElementToDB(pr);
        }
        public void EditProfile()
        {
            DAO.GetProfileTable().UpdateElementInDB(pr);
        }

      
    }
}
