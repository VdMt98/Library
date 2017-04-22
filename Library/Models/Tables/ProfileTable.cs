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
    public class ProfileTable : BaseTable<Profile>
    {
        protected override string getSql_SelectById(int id)
        {
            return String.Format("SELECT * FROM profile WHERE id = {0};", id);
        }

        protected override Profile LoadElementFromDB(int id)
        {
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(getSql_SelectById(id), c);
            Profile profile = GetProfileFromReader(command.ExecuteReader());
            return profile;
        }

        public Profile GetProfileByLoginAndPassword(int idProfile, string password) {
            MySqlConnection c = Connector.Instance.GetConnection();
            string sql = String.Format("SELECT * FROM profile WHERE idProfile={0} and Password=\"{1}\";", idProfile.ToString(), password);
            MySqlCommand command = new MySqlCommand(sql, c);
            return GetProfileFromReader(command.ExecuteReader());
        }

        private Profile GetProfileFromReader(MySqlDataReader reader) {
            Profile result = null;
            reader.Read();
            int id = reader.FieldCount;//int.Parse(reader ["id"].ToString());
            int idProfile = int.Parse(reader["idProfile"].ToString());
            string Password = reader["Password"].ToString();
            string Name = reader["Name"].ToString();
            string Surname = reader["Surname"].ToString();
            string Telephone = reader["Telephone"].ToString();
            string Address = reader["Address"].ToString();
            int profileCategoryId = int.Parse(reader["ProfileCategory"].ToString());
            int profileStatusId = int.Parse(reader["ProfileStatus"].ToString());
            ProfileStatus profileStatus = DAO.GetProfileStatusTable().GetElement(profileStatusId);
            ProfileCategory profileCategory = DAO.GetProfileCategoryTable().GetElement(profileCategoryId);


            result = new Profile(1, idProfile, Password, Name, Surname, Telephone, Address, profileStatus, profileCategory);
            
            return result;
        }
    }
}
