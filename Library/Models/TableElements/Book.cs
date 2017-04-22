using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.TableElements
{
    public class Book:BaseTableElement
    {
        string name { get; set; }
        string author { get; set; }
        string description { get; set; }
        string position { get; set; }
        DateTime issueDate { get; set; }
        int issueTerm { get; set; }
        Profile recipient { get; set; }
        BookStatus status { get; set; }

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
