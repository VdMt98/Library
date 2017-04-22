using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Main
    {
        private static Main _instance;
        public static Main Instance {
            get
            {
                if (_instance == null)
                    _instance = new Main();
                return _instance;
            }
        }

        
    }
}
