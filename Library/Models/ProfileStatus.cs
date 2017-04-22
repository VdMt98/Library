﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class ProfileStatus:BaseTable
    {
        string status { get; set; }

        public ProfileStatus(int id, string status):base(id)
        {
            this.status = status;
        }
    }
}
