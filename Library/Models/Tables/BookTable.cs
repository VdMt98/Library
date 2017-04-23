using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.TableElements;
using Library.Controllers;
using MySql.Data.MySqlClient;

namespace Library.Models.Tables
{
    public class BookTable : BaseTable<Book>
    {
        protected override string getSql_SelectById(int id)
        {
            return String.Format("SELECT * FROM book WHERE id={0};", id.ToString());
        }

        protected override Book LoadElementFromDB(int id)
        {
            MySqlDataReader reader = GetDataReader(getSql_SelectById(id));
            return GetBookFromReader(reader);
        }

        private Book GetBookFromReader(MySqlDataReader reader)
        {
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            string Name = reader["Name"].ToString();
            string Author = reader["Author"].ToString();
            string Description = reader["Description"].ToString();
            string Position = reader["Position"].ToString();
            string IssueDate = reader["IssueDate"].ToString();
            string IssueTerm = reader["IssueTerm"].ToString();
            string RecipientId = reader["Recipient"].ToString();
            int StatusId = int.Parse(reader["Status"].ToString());
            BookStatus bookStatus = DAO.GetBookStatusTable().GetElement(StatusId);
            DateTime issueDate = new DateTime();
            int issueTerm = 0;
            Profile recipient = null;
            if (bookStatus.status.Equals("Inuse")) {
                issueDate = DateTime.Parse(IssueDate);
                issueTerm = int.Parse(IssueTerm);
                recipient = DAO.GetProfileTable().GetElement(int.Parse(RecipientId));
            }
            Book book = new Book(id, Name, Author, Description, Position, issueDate, issueTerm, recipient, bookStatus);
            return book;
        }

        public List<Book> GetBooksInuseByRecipientId(int recipientId) {
            List<Book> result;
            string sql = String.Format("SELECT id FROM book WHERE Recipient={0};", recipientId.ToString());
            MySqlDataReader reader = GetDataReader(sql);
            List<int> booksids = GetIDsFromDataReader(reader);
            result = GetElements(booksids.ToArray());
            return result;
        }

        public List<BookRow> GetRowsOfBooksInuseByRecipient(int recipientId) {
            List<BookRow> result = new List<BookRow>();
            var books = GetBooksInuseByRecipientId(recipientId);
            foreach (var book in books) {
                result.Add(book.GetBookRow());
            }
            return result;
        }

        public List<Book> GetBooksByAuthor(string author) {
            List<Book> result;
            string sql = String.Format("SELECT id FROM book WHERE Author LIKE \"%{0}%\" AND Status=1;", author);
            MySqlDataReader reader = GetDataReader(sql);
            List<int> booksids = GetIDsFromDataReader(reader);
            result = GetElements(booksids.ToArray());
            return result;
        }

        public List<Book> GetBooksByName(string name)
        {
            List<Book> result;
            string sql = String.Format("SELECT id FROM book WHERE Name LIKE \"%{0}%\" AND Status=1;", name);
            MySqlDataReader reader = GetDataReader(sql);
            List<int> booksids = GetIDsFromDataReader(reader);
            result = GetElements(booksids.ToArray());
            return result;
        }

        
    }
}
