﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.TableElements
{
    public class BookStatus : BaseTableElement
    {
        
        public string status { get; set; }

        public BookStatus(int id, string status) : base(id)
        {
            this.status = status;
        }

        public override string ToString()
        {
            return status;
        }
    }
}
