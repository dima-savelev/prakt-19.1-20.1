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
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        public Request()
        {
            InitializeComponent();
        }
        ToyShopEntities db = ToyShopEntities.GetContext();
        private void Average_Click(object sender, RoutedEventArgs e)
        {
            double avarage = db.Toys.Average(p => p.Count);
            countText.Text = Math.Round(avarage, 4).ToString();
        }

        private void MaxPrice(object sender, RoutedEventArgs e)
        {
            decimal max = db.Toys.Max(p => p.Price);
            priceText.Text = max.ToString();
        }

        private void MinToy(object sender, RoutedEventArgs e)
        {
            int min = db.Toys.Min(p => p.Count);
            countMin.Text = min.ToString();
        }
    }
}
