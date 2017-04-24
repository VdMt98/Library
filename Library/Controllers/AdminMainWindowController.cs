using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    class AdminMainWindowController
    {
        public string[] setMainInformation()
        {
            string[] res = new string[2];

            res[0] = Main.Instance.worker.surname;
            res[1] = Main.Instance.worker.name;

            return res;
        }
    }
}
