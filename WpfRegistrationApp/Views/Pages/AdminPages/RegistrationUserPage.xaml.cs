using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfRegistrationApp.Views.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationUserPage.xaml
    /// </summary>
    public partial class RegistrationUserPage : Page
    {
        public Client Client { get; set; }
        public RegistrationUserPage(Client client)
        {
            InitializeComponent();
        }
        // Выбор фото и сохранение
        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Client.ID == 0)
            {
                Data.re.Client.Add(Client);
            }
            File.Copy(file.FileName, $"avatars\\{System.IO.Path.GetFileName(file.FileName).Trim()}", true);
            Client.GetPhotos = "\\avatars\\" + System.IO.Path.GetFileName(file.FileName);
            Data.re.SaveChanges();

            MessageBox.Show("Данные успешно добавлены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }
        OpenFileDialog file = new OpenFileDialog();

        // Фильтр формата изображений
        private void SelectBTN_Click(object sender, RoutedEventArgs e)
        {
            file.Filter = "Image (*.jpg;*.jpeg;*.png;) |  *.jpg; *.jpeg; *.png";
            if (file.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(file.FileName));
                Img.Source = image;
            }
        }
    }
}


