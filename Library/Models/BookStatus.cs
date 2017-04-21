using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class BookStatus
    {
        int id { get; set; }
        string status { get; set; }

        public BookStatus() { }

        public BookStatus(int id, string status)
        {
            this.id = id;
            this.status = status;
        }
    }
}
