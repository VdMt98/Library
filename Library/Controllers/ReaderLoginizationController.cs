using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReaderLoginizationController
    {
        public void LogIn(int id, string password)
        {
            Main.Instance.client = Main.Instance.client = DAO.GetProfileTable().GetProfileByLoginAndPassword(id, password);
        }
    }
}
