using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers.TableElements
{
    class BookStatus : BaseTableElement
    {
        
        string status { get; set; }

        public BookStatus(int id, string status):base(id)
        {
            this.status = status;
        }
    }
}
