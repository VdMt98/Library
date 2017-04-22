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
            int IssueTerm = int.Parse(reader["IssueTerm"].ToString());
            int RecipientId = int.Parse(reader["Recipient"].ToString());
            int StatusId = int.Parse(reader["Status"].ToString());
            Profile recipient = DAO.GetProfileTable().GetElement(RecipientId);
            BookStatus bookStatus = DAO.GetBookStatusTable().GetElement(StatusId);
            string[] dateInfStr = IssueDate.Split('.');
            int[] dateInf = new int[dateInfStr.Length];
            for (int i = 0; i < dateInf.Length; i++) {
                dateInf[i] = int.Parse(dateInfStr[i]);
            }
            DateTime issueDate = new DateTime(dateInf[2], dateInf[1], dateInf[0]);
            Book book = new Book(id, Name, Author, Description, Position, issueDate, IssueTerm, recipient, bookStatus);
            return null;
        }
    }
}
