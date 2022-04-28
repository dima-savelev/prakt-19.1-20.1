using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prakt_19._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ToyShopEntities db = ToyShopEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Autoriz autoriz = new Autoriz();
            autoriz.Owner = MainWindow1;
            autoriz.ShowDialog();
            if (Data.Login == false)
            {
                Close();
            }
            string right;
            if (Data.Right == "A")
            {
                right = "Администратор";
            }
            else
            {
                right = "Пользователь";
                buttonDel.IsEnabled = false;
                menuDel.IsEnabled = false;
            }
            MainWindow1.Title = MainWindow1.Title + " " + Data.FIO + " " + Data.Name + " (" + right + ")";
            db.Toys.Load();
            DataGrid.ItemsSource = db.Toys.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.ShowDialog();
            DataGrid.Focus();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Toy row = (Toy)DataGrid.Items[indexRow];
                Transfer.Id = row.Id;
                EditRecord editRecord = new EditRecord();
                editRecord.ShowDialog();
                DataGrid.Items.Refresh();
                DataGrid.Focus();
            }
            else
            {
                MessageBox.Show("Сначало выберете строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Toy row = (Toy)DataGrid.SelectedItems[0];
                    db.Toys.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №19\nРазработать интерфейс для доступа и управления однотабличной базой данных «Сведения об ассортименте игрушек в магазине». База данных должна содержать следующую информацию: название игрушки, ее цену, количество, возрастную категорию детей, для которых она предназначена, а также название фабрики и города, где изготовлена игрушка.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (nameToy.Text == string.Empty)
            {
                MessageBox.Show("Введите название игрушки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string toyName = nameToy.Text.ToLower();
            var toy = db.Toys.Where(p => p.Name.ToLower() == toyName).FirstOrDefault();
            if (toy == null)
            {
                MessageBox.Show("Данная игрушка отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!decimal.TryParse(finalPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Цена введена неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            toy.Price = price;
            db.SaveChanges();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
            nameToy.Clear();
            finalPrice.Clear();
        }

        private void Update_Count(object sender, RoutedEventArgs e)
        {
            if (nameToy1.Text == string.Empty)
            {
                MessageBox.Show("Введите название игрушки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string toyName = nameToy1.Text.ToLower();
            var toy = db.Toys.Where(p => p.Name.ToLower() == toyName).FirstOrDefault();
            if (toy == null)
            {
                MessageBox.Show("Данная игрушка отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(countText.Text, out int count) || count < 0)
            {
                MessageBox.Show("Количество ввдено неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            toy.Count = count;
            db.SaveChanges();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
            nameToy1.Clear();
            countText.Clear();
        }

        private void Delete_Name(object sender, RoutedEventArgs e)
        {
            if (nameDel.Text == string.Empty)
            {
                MessageBox.Show("Введите название игрушки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string toyName = nameDel.Text.ToLower();
            var toy = db.Toys.Where(p => p.Name.ToLower() == toyName).FirstOrDefault();
            if (toy == null)
            {
                MessageBox.Show("Данная игрушка отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Toys.Remove(toy);
            db.SaveChanges();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
            nameDel.Clear();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Request request = new Request();
            request.ShowDialog();
        }
    }
}
