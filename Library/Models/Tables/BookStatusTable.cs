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
    public class BookStatusTable : BaseTable<BookStatus>
    {
        protected override string getSql_SelectById(int id)
        {
            return String.Format("SELECT * FROM bookstatus WHERE id={0}", id.ToString());
        }
        

        protected override BookStatus LoadElementFromDB(int id)
        {
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(getSql_SelectById(id), c);
            BookStatus bookStatus = GetBookStatusFromReader(command.ExecuteReader());
            return bookStatus;
        }

        private BookStatus GetBookStatusFromReader(MySqlDataReader reader)
        {
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            string Status = reader["Status"].ToString();
            return new BookStatus(id, Status);
        }
    }
}
