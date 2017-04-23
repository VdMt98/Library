using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Views;
using Library.Models.TableElements;

namespace Library.Controllers
{
    class LoginController
    {
        public static Profile locworker { get; set; }

        public void LogIn(int ids, string password, Login log)
        {
            Main.Instance.worker = DAO.GetProfileTable().GetProfileByLoginAndPassword(ids, password);

            locworker = Main.Instance.worker;

            switch (locworker.profileCategory.id)
            {
                case 1:
                    ReaderMainWindow rm = new ReaderMainWindow();
                    rm.Show();
                    break;
                case 2:
                    LibrarianMainWindow lm = new LibrarianMainWindow();
                    lm.Show();
                    break;
                case 3:
                    AdminMainWindow ad = new AdminMainWindow();
                    ad.Show();
                    break;
            }
            log.Close();
        }
    }
}
