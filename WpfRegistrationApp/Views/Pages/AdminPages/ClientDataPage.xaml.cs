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
using WpfRegistrationApp.Model;

namespace WpfRegistrationApp.Views.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для UserDataPage.xaml
    /// </summary>
    public partial class ClientDataPage : Page
    {
        Client Client { get; set; }
        public ClientDataPage()
        {
            InitializeComponent();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView.ItemsSource = Data.re.Client.Where(item => item.FirstName.ToString().Contains(SearchTextBox.Text) || item.LastNakme.ToString().Contains(SearchTextBox.Text) || item.Mileage.ToString().Contains(SearchTextBox.Text) ||
          item.DateOfBirth.ToString().Contains(SearchTextBox.Text) || item.Phone.ToString().Contains(SearchTextBox.Text)).ToList();
        }


        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            Data.re.Client.Remove(selectedItem);
            Data.re.SaveChanges();
            MessageBox.Show("Данные удалены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationUserPage(new Model.Client()));
        }
    }
}
