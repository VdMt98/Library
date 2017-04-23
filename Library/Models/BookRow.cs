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
        public string issueDate { get; set; }
        public int issueTerm { get; set; }
        
        public BookRow(int id, string name, string author, DateTime issueDate, int issueTerm)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.issueDate = issueDate.ToShortDateString();
            this.issueTerm = issueTerm;
        }
    }
}
