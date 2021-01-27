using System.Windows;

namespace Project_Store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string login = "")
        {
            InitializeComponent();
            log.Text = login;
            TakePost check = new TakePost();
            var post = check.RevertPost(log.Text);
            if (post == "")
            {
                MessageBox.Show("Вийди отсюда розбійник");
                Close();
            }
            else if (post == "Manager")
            {
                MessageBox.Show("Вітаємо менеджера!");
            }
            else if (post == "Admin")
            {
                MessageBox.Show("Адмін, звільняйся");
            }
            else
            {
                BtnEmployee.Visibility = Visibility.Collapsed;
                Журнал.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnLogout(object sender, RoutedEventArgs e)
        {
            Entrance form = new Entrance();
            form.Show();
            FillJournal jr = new FillJournal();
            jr.FillProcess(log.Text, "Logout");
            Close();
        }

        private void BtnMainTovar(object sender, RoutedEventArgs e)
        {
            MainTovar form = new MainTovar(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainOrder(object sender, RoutedEventArgs e)
        {
            MainOrder form = new MainOrder(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainClient(object sender, RoutedEventArgs e)
        {
            MainClient form = new MainClient(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainJournal(object sender, RoutedEventArgs e)
        {
            MainJournal form = new MainJournal(log.Text);
            form.Show();
            Close();
        }

        private void BtnMainEmployee(object sender, RoutedEventArgs e)
        {
            MainEmployee form = new MainEmployee(log.Text);
            form.Show();
            Close();
        }
        private void BtnExit(object sender, RoutedEventArgs e)
        {
            FillJournal jr = new FillJournal();
            jr.FillProcess(log.Text, "Exit");
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FillJournal jr = new FillJournal();
            jr.FillProcess(log.Text, "Exit");
        }
    }
}
