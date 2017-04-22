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
    public class ProfileStatusTable : BaseTable<ProfileStatus>
    {
        protected override string getSql_SelectById(int id)
        {
            return String.Format("SELECT * FROM profilestatus WHERE id={0}", id.ToString());
        }

        protected override ProfileStatus LoadElementFromDB(int id)
        {
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(getSql_SelectById(id), c);
            ProfileStatus profileCategory = GetProfileStatusFromReader(command.ExecuteReader());
            return profileCategory;
        }

        private ProfileStatus GetProfileStatusFromReader(MySqlDataReader reader)
        {
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            string Status = reader["Status"].ToString();
            return new ProfileStatus(id, Status);
        }

    }
}
