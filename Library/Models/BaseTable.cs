using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    abstract class BaseTable
    {
        int id { get; set; }

        public BaseTable(int id)
        {
            this.id = id;
        }
    }
}
