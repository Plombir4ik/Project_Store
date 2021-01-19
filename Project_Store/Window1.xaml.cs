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
            private void enter_Click(object sender, RoutedEventArgs e)
            {
                if (textBox_login.Text.Length > 0)    
                {
                    if (password.Password.Length > 0)         
                    {        
                        DataTable dt_user = Window1.Select("SELECT * FROM [compstore] WHERE [login] = '" + LoginTextBox.Text + "' AND [password] = '" + PasswordTextBox.Password + "'");
                        if (dt_user.Rows.Count > 0)     
                        {
                            MessageBox.Show("Ви авторизовані!");
                            MainWindow mform = new MainWindow();
                            mform.Show();
                            Hide();       
                        }
                        else MessageBox.Show("Такого користувача не знайдено");  
                    }
                    else MessageBox.Show("Введіть пароль");  
                }
                else MessageBox.Show("Введіть логін");
            }
        }
    }
}
