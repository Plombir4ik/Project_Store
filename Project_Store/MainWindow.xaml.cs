using System.Windows;

namespace Project_Store
{
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
                MessageBox.Show("Неавтентифікований користувач. \n Залогіньтесь!");
                Close();
            }
            else if (post == "Manager" || post == "Admin")
            {
                
            }
            else
            {
                BtnEmployee.Visibility = Visibility.Collapsed;
                double a = 0.75;
                Журнал.Opacity = a;
                Журнал.Click -= new RoutedEventHandler(BtnMainJournal);
            }
        }

        private void BtnLogout(object sender, RoutedEventArgs e)
        {
            Entrance form = new Entrance();
            form.Show();
            FillJournal jr = new FillJournal();
            jr.FillProcess(log.Text, "Logout");
            Hide();
        }

        private void BtnMainTovar(object sender, RoutedEventArgs e)
        {
            MainTovar form = new MainTovar(log.Text);
            form.Show();
            Hide();
        }

        private void BtnMainOrder(object sender, RoutedEventArgs e)
        {
            MainOrder form = new MainOrder(log.Text);
            form.Show();
            Hide();
        }

        private void BtnMainClient(object sender, RoutedEventArgs e)
        {
            MainClient form = new MainClient(log.Text);
            form.Show();
            Hide();
        }

        private void BtnMainJournal(object sender, RoutedEventArgs e)
        {
            MainJournal form = new MainJournal(log.Text);
            form.Show();
            Hide();
        }

        private void BtnMainEmployee(object sender, RoutedEventArgs e)
        {
            MainEmployee form = new MainEmployee(log.Text);
            form.Show();
            Hide();
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
