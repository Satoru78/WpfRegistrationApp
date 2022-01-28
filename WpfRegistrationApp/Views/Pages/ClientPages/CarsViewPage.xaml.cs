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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfRegistrationApp.Context;
using WpfRegistrationApp.Model;

namespace WpfRegistrationApp.Views.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для CarsViewPage.xaml
    /// </summary>
    public partial class CarsViewPage : Page
    {
        List<Cars> Cars { get; set; }
        public CarsViewPage()
        {
            InitializeComponent();
        }

        private void SearcTXB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListDataView.ItemsSource = Data.re.Cars.Where(item => item.Brand.ToString().Contains(SearchTXB.Text) || item.YearIssue.ToString().Contains(SearchTXB.Text) || item.Mileage.ToString().Contains(SearchTXB.Text) ||
           item.Price.ToString().Contains(SearchTXB.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Cars = Data.re.Cars.ToList();
            ListDataView.ItemsSource = Cars;
        }

    }
}

