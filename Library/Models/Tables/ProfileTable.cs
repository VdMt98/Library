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
            int id = int.Parse(reader ["id"].ToString());
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


            result = new Profile(id, idProfile, Password, Name, Surname, Telephone, Address, profileStatus, profileCategory);
            
            return result;
        }

        public List<Profile> GetProfilesByNameAndSurname(string name, string surname) {
            List<Profile> result;
            string sql = String.Format("SELECT id FROM profile WHERE Name LIKE \"%{0}%\" AND Surname LIKE \"%{1}%\";", name, surname);
            var reader = GetDataReader(sql);
            var ids = GetIDsFromDataReader(reader);
            result = GetElements(ids.ToArray());
            return result;
        }

        public int GetMaxIdProfile() {
            string sql = "SELECT MAX(idProfile) FROM profile;";
            var reader = GetDataReader(sql);
            if (reader.Read())
                return reader.GetInt32(0);
            return -1;
        }

        public override void InsertElementToDB(Profile element) {
            string sql = String.Format("INSERT INTO " +
                "profile (`idProfile`, `Password`, `Name`, `Surname`, `Telephone`, `Address`, `ProfileStatus`, `ProfileCategory`) " +
                "VALUES " +
                "({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');",
                element.idProfile, element.password, element.name, element.surname, element.telephone, element.address, element.profileStatus.id, element.profileCategory.id);
            ExecuteCommand(sql);
        }

        //UPDATE `mydb`.`profile` SET `id`='12', `idProfile`='123467', `Password`='user1', `Name`='NewUser1', `Surname`='1', `Telephone`='13232312323', `Address`='adress', `ProfileStatus`='2', `ProfileCategory`='1' WHERE `id`='11' and`idProfile`='123464';
        public override void UpdateElementInDB(Profile element)
        {
            string sql = "UPDATE `mydb`.`profile` SET  `idProfile`='{0}', `Password`='{1}', " +
                "`Name`='{2}', `Surname`='{3}', `Telephone`='{4}', `Address`='{5}', " +
                "`ProfileStatus`='{6}', `ProfileCategory`='{7}';";
            sql = String.Format(sql, element.idProfile, element.password, element.name, element.surname, element.telephone, 
                element.address, element.profileStatus.id, element.profileCategory.id);
            ExecuteCommand(sql);
        }
    }
}
