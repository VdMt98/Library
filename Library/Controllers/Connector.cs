using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library.Controllers
{
    public class Connector
    {
        private static Connector _instance;
        public static Connector Instance {
        get {
                if (_instance == null)
                    _instance = new Connector();
                return _instance;
            }
        }

        private MySqlConnection _connection;
        public MySqlConnection GetConnection() {
            if (_connection == null) {
                string serverName = "Vadim-pc"; // Адрес сервера (для локальной базы пишите "localhost")
                string userName = "root"; // Имя пользователя
                string dbName = "mydb"; //Имя базы данных
                string port = "3306"; // Порт для подключения
                string password = "kekkek"; // Пароль для подключения
                string connStr = "server=" + serverName +
                    ";user=" + userName +
                    ";database=" + dbName +
                    ";port=" + port +
                    ";password=" + password + ";";
                _connection = new MySqlConnection(connStr);
                _connection.Open();
            }
            return _connection;
        }

    }
}
