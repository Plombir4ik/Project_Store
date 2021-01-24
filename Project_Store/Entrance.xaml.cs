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
    public partial class Entrance : Window
    {
        public Entrance()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void ButtonEntrance(object sender, RoutedEventArgs e)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;database=compstore;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("select login from prazivnuku where login = '" + LoginTextBox.Text + "' and password = '" + PasswordTextBox.Password + "';", conn);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();    
            if (table.Rows.Count > 0)       
            {
                MainWindow mform = new MainWindow(LoginTextBox.Text);
                    mform.Show();
                    Close();
            }
            else { Error.Visibility = Visibility.Visible; }
        }
    }
}
