using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers.TableElements
{
    class ProfileCategory:BaseTableElement
    {
        string category { get; set; }


        public ProfileCategory(int id, string category):base(id)
        {
            this.category = category;
        }
    }
}
