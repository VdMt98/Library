using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.TableElements
{
    public class ProfileCategory:BaseTableElement
    {
        public string category { get; set; }


        public ProfileCategory(int id, string category):base(id)
        {
            this.category = category;
        }

        public override string ToString()
        {
            return category;
        }
    }
}
