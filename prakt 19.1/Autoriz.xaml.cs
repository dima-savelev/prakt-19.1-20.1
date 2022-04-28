using System;
using System.Linq;
using System.Windows;

namespace prakt_19._1
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autoriz : Window
    {
        public Autoriz()
        {
            InitializeComponent();
        }
        ToyShopEntities db = ToyShopEntities.GetContext();
        private void Window_Activated(object sender, EventArgs e)
        {
            txtLogin.Focus();
            Data.Login = false;
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == string.Empty || txtPas.Password == string.Empty)
            {
                MessageBox.Show("Логин или пароль были не введены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var user = db.Authorizations.Where(p => p.Login.ToLower() == txtLogin.Text.ToLower()).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txtLogin.Focus();
                return;
            }
            if (user.Password != txtPas.Password)
            {
                MessageBox.Show("Пароль неверен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Data.Login = true;
            Data.FIO = user.Fio;
            Data.Name = user.Name;
            Data.Right = user.Right;
            Close();
        }

        private void Esc(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
