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
    public class ProfileCategoryTable : BaseTable<ProfileCategory>
    {
        protected override string getSql_SelectById(int id)
        {
            return String.Format("SELECT * FROM profilecategory WHERE id={0}", id.ToString());
        }

        protected override ProfileCategory LoadElementFromDB(int id)
        {
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(getSql_SelectById(id), c);
            ProfileCategory profileCategory = GetProfileCategoryFromReader(command.ExecuteReader());
            return profileCategory;
        }

        private ProfileCategory GetProfileCategoryFromReader(MySqlDataReader reader) {
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            string Category = reader["Category"].ToString();
            //string categoryStr = "unknow category";
            //switch (Category) {
            //    case 1:
            //        categoryStr = "Reader";
            //        break;
            //    case 2:
            //        categoryStr = "Libririan";
            //        break;
            //    case 3:
            //        categoryStr = "Administrator";
            //        break;
            //}
            return new ProfileCategory(id, Category);
        }
    }
}
