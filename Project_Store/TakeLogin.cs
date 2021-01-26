using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Store
{
    class TakeLogin
    {
        public string RevertToTheID(string login)
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlCommand revert = new MySqlCommand("select ID from prazivnuku where login = '"+login+"'", DB.GetConnection());
            MySqlDataReader myReader;
            DB.OpenConnection();
            myReader = revert.ExecuteReader();
            string theend = "";
            if (myReader.Read())
            {
                theend = Convert.ToString(myReader.GetValue(0));
            }
            DB.CloseConnection();
            return theend;
        }
    }
}
