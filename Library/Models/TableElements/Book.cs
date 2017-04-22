using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.TableElements
{
    public class Book:BaseTableElement
    {
        public string name { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string position { get; set; }
        public DateTime issueDate { get; set; }
        public int issueTerm { get; set; }
        public Profile recipient { get; set; }
        public BookStatus status { get; set; }

        public Book(int id, string name, string author, string description, string position, DateTime issueDate,
            int issueTerm, Profile recipient, BookStatus status) : base(id)
        {
            this.name = name;
            this.author = author;
            this.description = description;
            this.position = position;
            this.issueDate = issueDate;
            this.issueTerm = issueTerm;
            this.recipient = recipient;
            this.status = status;
        }

        public override string ToString()
        {
            return String.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}; {7}; {8}; ", id, name, author,
                description, position, issueDate.ToShortDateString(), issueTerm, recipient.id, status);
        }
    }
}
