using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookRow
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        private DateTime _issueDate;
        public int issueTerm { get; set; }

        public BookRow(int id, string name, string author, DateTime issueDate, int issueTerm)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this._issueDate = issueDate;
            this.issueTerm = issueTerm;
        }

        public string issueDate { get{ return _issueDate.ToShortDateString(); } }

        public bool isProsro4eno
        {
            get
            {
                int result = 0;
                DateTime getBackDate = _issueDate.AddDays(issueTerm);
                result = DateTime.Now.CompareTo(getBackDate);
                return result >= 0;
            }
        }
    }
}
