using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Project_Store
{
    public partial class AddOrder : Window
    {
        private readonly MainOrder mform;
        string login = "";
        public AddOrder(string login, MainOrder form)
        {
            InitializeComponent();
            FillComboBoxID_C();
            FillComboBoxID_T();
            this.login = login;
            Updating();
            mform = form;
        }
        
        private void BtnAddTovar(object sender, RoutedEventArgs e)
        {
            if (PayBox.Text == "" || BoxID_C.Text == "" || BoxID_T.Text == "" || NumberBox.Text == "")
            {
                MessageBox.Show("Ви забули ввести якусь інформацію!");
            }
            else if (NumberBox.Text == "0")
            {
                MessageBox.Show("Кількість не може дорівнювати нулю!");
            }
            else
            {
                StoreDatabase DB = new StoreDatabase();
                int boxklk = Convert.ToInt16(NumberBox.Text);
                if (boxklk > CheckNumber())
                {
                    MessageBox.Show("Товару стільки немає.\n Наявна кількість: "+CheckNumber()+ "");
                    log.Text = "Кількість на складі : " + CheckNumber() + " ";
                }
                else
                {
                        int teper = CheckNumber() - boxklk;
                        MySqlCommand updatenumber = new MySqlCommand("UPDATE tovar set Number = '"+teper+"' where ID = '"+BoxID_T.Text+"'", DB.GetConnection());
                        MySqlCommand adding = new MySqlCommand("INSERT INTO orders (ID_C, ID_T, ID_P, Number, Pay, Discount, Date) VALUES ('" + BoxID_C.Text + "', '" + BoxID_T.Text + "', '" + ID_PBox.Text + "', '" + NumberBox.Text + "', '" + PayBox.Text + "', '" + DiscountBox.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');", DB.GetConnection());
                        DB.OpenConnection();
                        if (adding.ExecuteNonQuery() > 0 && updatenumber.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Замовлення успішно додано!", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        else
                        {
                            MessageBox.Show("Хм, замовлення не було додано...", "Створення позиції...", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        FillJournal jr = new FillJournal(); 
                        jr.FillProcess(login, "AddOrder");
                        DB.CloseConnection();
                    mform.Info();
                    this.Close();
                }
            }
        }
        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void FillComboBoxID_C()
        {
            StoreDatabase DB = new StoreDatabase();
            if (BoxID_C.Text == "")
            {
                MySqlDataReader myReader;
                DB.OpenConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID,') ', P, ' ', I, ' ', B) as 'ID_C' from client group by ID", DB.GetConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_C.Items.Add(myReader.GetString("ID_C"));
                }
                DB.CloseConnection();
            }
            else
            {
                MySqlDataReader myReader;
                DB.OpenConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID,') ', P,' ', I, ' ', B) as 'ID_C' from client where concat(ID, ') ', P, ' ', I, ' ', B) like '%" + BoxID_C.Text + "%' group by ID_C", DB.GetConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_C.Items.Add(myReader.GetString("ID_C"));
                }
                DB.CloseConnection();
            }
        }
        void FillComboBoxID_T()
        {
            StoreDatabase DB = new StoreDatabase();
            if (BoxID_T.Text == "")
            {
                MySqlDataReader myReader;
                DB.OpenConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID, ') ', Name) as 'ID_T' from tovar group by ID", DB.GetConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_T.Items.Add(myReader.GetString("ID_T"));
                }
                DB.CloseConnection();
            }
            else
            {
                MySqlDataReader myReader;
                DB.OpenConnection();
                MySqlCommand comm = new MySqlCommand("select concat(ID, ') ', Name) as 'ID_T' from tovar where ID like '%"+BoxID_T.Text+"%' group by ID_T" , DB.GetConnection());
                myReader = comm.ExecuteReader();
                while (myReader.Read())
                {
                    BoxID_T.Items.Add(myReader.GetString("ID_T"));
                }
                DB.CloseConnection();
            }
        }

        private void BoxID_CTextChanged(object sender, RoutedEventArgs e)
        {
            BoxID_C.Items.Clear();
            FillComboBoxID_C();
            BoxID_C.IsDropDownOpen = true;
        }
        private void BoxID_TTextChanged(object sender, RoutedEventArgs e)
        {
            BoxID_T.Items.Clear();
            FillComboBoxID_T();
            BoxID_T.IsDropDownOpen = true;
            UpdateAddOrder();
            CheckNumber();
        }
        private void UpdateAddOrder()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlCommand checkNumber = new MySqlCommand("select SellingPrice from tovar where id = '" + BoxID_T.Text + "'", DB.GetConnection());
            MySqlDataReader myReader;
            DB.OpenConnection();
            myReader = checkNumber.ExecuteReader();
            int klk = 0;
            int dscnt = 0;
            if (NumberBox.Text != "")
            {
                klk = Convert.ToInt32(NumberBox.Text);
            }
            if (DiscountBox.Text != "" && DiscountBox.Text != "0")
            {
                dscnt = Convert.ToByte(DiscountBox.Text);
            }
            long tsina = 0;
            if (myReader.Read())
            {
                tsina = Convert.ToInt32(myReader.GetValue(0));
            }
            if (NumberBox.Text != "")
            {
                tsina *= klk;
            }
            if (DiscountBox.Text != "" && DiscountBox.Text != "0")
            {
                tsina = (tsina / 100 * (100 - dscnt));
            }
            PayBox.Text = Convert.ToString(tsina);
            DB.CloseConnection();
        }

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddOrder();
        }

        private void DiscountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddOrder();
        }

        private void ID_PBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Updating();
        }
        private void Updating()
        {
            dP.SelectedDate = DateTime.Now;
            TakeLogin take = new TakeLogin();
            ID_PBox.Text = take.RevertToTheID(login);
        }
        private int CheckNumber()
        {
            StoreDatabase DB = new StoreDatabase();
            MySqlCommand checkNumber = new MySqlCommand("select Number from tovar where id = '" + BoxID_T.Text + "'", DB.GetConnection());
            MySqlDataReader myReader;
            DB.OpenConnection();
            myReader = checkNumber.ExecuteReader();
            int klk = 0;
            if (myReader.Read())
            {
                klk = Convert.ToInt16(myReader.GetValue(0));
            }
            TextLog.Visibility = Visibility.Visible;
            log.Text = Convert.ToString(klk);
            DB.CloseConnection();
            return klk;
        }

        private void PayBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddOrder();
        }
    }
}
