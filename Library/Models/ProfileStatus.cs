using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class ProfileStatus
    {
        int id { get; set; }
        string status { get; set; }

        public ProfileStatus() { }

        public ProfileStatus(int id, string status)
        {
            this.id = id;
            this.status = status;
        }
    }
}
