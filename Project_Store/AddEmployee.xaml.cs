using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Project_Store
{
    public partial class AddEmployee : Window
    {
        readonly long id = 0;
        private readonly MainEmployee mform;
        string login = "";
        public AddEmployee(string login, MainEmployee form, long id = -1)
        {
            InitializeComponent();
            mform = form;
            this.login = login;
            this.id = id;
            if (id > -1)
            {
                КнопкаДодатиТовар.Content = "Змінити";
                Label.Content = "Змінити вибраний товар";
                StoreDatabase DB = new StoreDatabase();
                MySqlCommand command = new MySqlCommand("select * from prazivnuku where id = '" + id + "';", DB.GetConnection());
                DB.OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BoxPost.Text = (string)reader.GetValue(1);
                        BoxP.Text = (string)reader.GetValue(2);
                        BoxI.Text = (string)reader.GetValue(3);
                        BoxB.Text = (string)reader.GetValue(4);
                        BoxLogin.Text = (string)reader.GetValue(5);
                        BoxPassword.Text = (string)reader.GetValue(6);
                    }
                }
                DB.CloseConnection();
            }
        }

        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (BoxP.Text == "" || BoxI.Text == "" || BoxB.Text == "" || BoxLogin.Text == "" || BoxPassword.Text == "")
            {
                MessageBox.Show("Щось тут не так");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                if (id == -1)
                {
                    MySqlCommand adding = new MySqlCommand("INSERT INTO prazivnuku (Post, P, I, B, login, password, status) VALUES ('"+BoxPost.Text+"', @P, @I, @B, '" + BoxLogin.Text + "', '" + BoxPassword.Text + "', 1);", DB.GetConnection());
                    adding.Parameters.AddWithValue("@P", BoxP.Text);
                    adding.Parameters.AddWithValue("@I", BoxI.Text);
                    adding.Parameters.AddWithValue("@B", BoxB.Text);
                    DB.OpenConnection();
                    if (adding.ExecuteNonQuery() > 0)
                    {
                        FillJournal jr = new FillJournal();
                        jr.FillProcess(login, "AddPrazivnuk");
                        MessageBox.Show("Працівника успішно додано! ВІТАЄМО!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Хм, працівника не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                else
                {
                    MySqlCommand editing = new MySqlCommand("UPDATE prazivnuku SET `Post` = '"+BoxPost.Text+"', `P` = @P, `I` = @I, `B` = @B,`login` = '" + BoxLogin.Text+"', `password` = '"+BoxPassword.Text+"' where ID = '"+id+"';", DB.GetConnection());
                    editing.Parameters.AddWithValue("@P", BoxP.Text);
                    editing.Parameters.AddWithValue("@I", BoxI.Text);
                    editing.Parameters.AddWithValue("@B", BoxB.Text);
                    DB.OpenConnection();
                    if (editing.ExecuteNonQuery() > 0)
                    {
                        FillJournal jr = new FillJournal();
                        jr.FillProcess(login, "EditPrazivnuk");
                        MessageBox.Show("Інформація про працівника \nбула успішно змінена!", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        MessageBox.Show("Інформація про працівника \nне була успішно змінена.", "Змінюємо...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    DB.CloseConnection();
                }
                mform.Info();
                this.Close();
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BoxPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BoxPost_TextChanged(object sender, RoutedEventArgs e)
        {
            BoxPost.Items.Clear();
            FillBoxPost();
            BoxPost.IsDropDownOpen = true;
        }
        private void FillBoxPost()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlDataReader myReader;
            if (BoxPost.Text == "")
            {
                MySqlCommand comm = new MySqlCommand("select Post from prazivnuku group by Post", DB.GetConnection());
                DB.OpenConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxPost.Items.Add(myReader.GetString("Post"));
                }
                DB.CloseConnection();
            }
            else
            {
                MySqlCommand comm = new MySqlCommand("select Post from prazivnuku where Post like '%" + BoxPost.Text + "%' group by Post", DB.GetConnection());
                DB.OpenConnection();
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxPost.Items.Add(myReader.GetString("Post"));
                }
                DB.CloseConnection();
            }
        }
    }
}
