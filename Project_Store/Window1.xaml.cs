using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Shapes;


namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string pass = PasswordTextBox.Password;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;database=compstore;");
            conn.Open();

            string SQLlogin = "select login from prazivnuku where login = '" + login + "' and password = '" + pass + "';";
            MySqlCommand command = new MySqlCommand(SQLlogin, conn);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            conn.Close();
                  
            if (table.Rows.Count > 0)       
            {
                MainWindow mform = new MainWindow(login);
                    mform.Show();
                    Close();
            }
            else { MessageBox.Show("Неправильний логін або пароль"); }
            
        }
    }
}
