using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class ProfileCategory
    {
        int id { get; set; }
        string category { get; set; }

        public ProfileCategory() { }

        public ProfileCategory(int id, string category)
        {
            this.id = id;
            this.category = category;
        }
    }
}
