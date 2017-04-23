using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models.TableElements;
using MySql.Data.MySqlClient;
using Library.Controllers;

namespace Library.Models.Tables
{
    public abstract class BaseTable<T> where T : BaseTableElement
    {

        protected List<T> elements;

        protected BaseTable() {
            elements = new List<T>();
        }

        public T GetElement(int id) {

            foreach (T e in elements)
            {
                if (e.id == id)
                    return e;
            }
            //try
            //{
                T newElement = LoadElementFromDB(id);
                elements.Add(newElement);
                return newElement;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message.ToString());
            //    // TODO: handle exception
            //}
            throw new Exception("Can't load element");
        }

        protected MySqlDataReader GetDataReader(string sql)
        {
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(sql, c);
            return command.ExecuteReader();
        }

        protected int ExecuteCommand(string sql) {
            MySqlConnection c = Connector.Instance.GetConnection();
            MySqlCommand command = new MySqlCommand(sql, c);
            return command.ExecuteNonQuery();
        }

        protected List<int> GetIDsFromDataReader(MySqlDataReader reader)
        {
            List<int> ids = new List<int>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                ids.Add(id);
            }
            return ids;
        }

        protected List<T> GetElements(int[] ids) {
            var result = new List<T>();
            foreach (var id in ids) {
                result.Add(GetElement(id));
            }
            return result;
        }

        protected abstract string getSql_SelectById(int id);

        protected abstract T LoadElementFromDB(int id);

        public virtual void InsertElementToDB(T element) {
            throw new Exception("Insert " + typeof(T).ToString() + " to DataBase is not supported!");
        }

        public virtual void UpdateElementInDB(T element) {
            throw new Exception("Update " + typeof(T).ToString() + " to DataBase is not supported!");
        }
    }
}
