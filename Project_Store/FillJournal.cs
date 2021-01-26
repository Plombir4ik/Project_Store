using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Store
{
    class FillJournal
    {
        public void FillProcess(string login, string operation)
        {
            TakeLogin go = new TakeLogin();
            StoreDatabase DB = new StoreDatabase();
            int ID = Convert.ToInt16(go.RevertToTheID(login));
            MySqlCommand fill = new MySqlCommand("insert into journal (Operation, ID_P, Date) values ('" + operation + "', '" + ID + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'); ", DB.GetConnection());
            DB.OpenConnection();
            fill.ExecuteNonQuery();
            DB.CloseConnection();
        }
    }
}
