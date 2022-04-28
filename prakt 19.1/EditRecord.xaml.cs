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

namespace prakt_19._1
{
    /// <summary>
    /// Логика взаимодействия для EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
        {
            InitializeComponent();
        }
        ToyShopEntities db = ToyShopEntities.GetContext();
        Toy toy;

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (nameText.Text == string.Empty)
            {
                errors.AppendLine("Заполните название игрушки");
            }
            if (!decimal.TryParse(priceText.Text, out decimal price) || price <= 0)
            {
                errors.AppendLine("Данные цены введены неверно");
            }
            if (!int.TryParse(countText.Text, out int count) || count < 0)
            {
                errors.AppendLine("Количество игрушек введено неверно");
            }
            if (!byte.TryParse(ageText.Text, out byte age) || age < 0)
            {
                errors.AppendLine("Возрастная категория введена неверно");
            }
            if (factoryText.Text == string.Empty)
            {
                errors.AppendLine("Заполните название фабрики");
            }
            if (cityText.Text == string.Empty)
            {
                errors.AppendLine("Заполните название города");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            toy.Name = nameText.Text;
            toy.Price = price;
            toy.Count = count;
            toy.Age = age;
            toy.Factory = factoryText.Text;
            toy.City = cityText.Text;
            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            toy = db.Toys.Find(Transfer.Id);
            nameText.Text = toy.Name;
            priceText.Text = Convert.ToString(toy.Price);
            countText.Text = Convert.ToString(toy.Count);
            ageText.Text = Convert.ToString(toy.Age);
            factoryText.Text = toy.Factory;
            cityText.Text = toy.City;
        }
    }
}
