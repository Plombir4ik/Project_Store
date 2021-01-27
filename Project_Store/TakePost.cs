using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Store
{
    class TakePost
    {
        public string RevertPost(string login)
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlCommand revert = new MySqlCommand("select Post from prazivnuku where login = '"+login+"'", DB.GetConnection());
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
