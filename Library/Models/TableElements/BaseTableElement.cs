using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Library.Models.TableElements
{
    public abstract class BaseTableElement
    {
        public int id { get; private set; }

        public BaseTableElement(int id)
        {
            this.id = id;
        }


    }
}
