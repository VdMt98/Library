using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library.Models.TableElements;
using Library.Models.Tables;
using Library.Controllers;
namespace Library.Controllers
{
    public static class DAO
    {

        private static ProfileTable profileTable;
        public static ProfileTable GetProfileTable() {
            if (profileTable == null)
                profileTable = new ProfileTable();
            return profileTable;
        }

        private static ProfileCategoryTable profileCategoryTable;
        public static ProfileCategoryTable GetProfileCategoryTable()
        {
            if (profileCategoryTable == null)
                profileCategoryTable = new ProfileCategoryTable();
            return profileCategoryTable;
        }

        private static ProfileStatusTable profileStatusTable;
        public static ProfileStatusTable GetProfileStatusTable()
        {
            if (profileStatusTable == null)
                profileStatusTable = new ProfileStatusTable();
            return profileStatusTable;
        }
    }
}
