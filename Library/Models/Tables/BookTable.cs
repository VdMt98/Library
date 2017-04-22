﻿using System;
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
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(getSql_SelectById(id), c);
            return GetBookFromReader(command.ExecuteReader());
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
            List<Book> result = new List<Book>();
            string sql = String.Format("SELECT id FROM book WHERE Recipient={0};", recipientId.ToString());
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            List<int> booksids = new List<int>();
            while (reader.Read()) {
                int bookId = reader.GetInt32(0);
                booksids.Add(bookId);
            }
            foreach (int bookid in booksids) {
                result.Add(GetElement(bookid));
            }
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
    }
}