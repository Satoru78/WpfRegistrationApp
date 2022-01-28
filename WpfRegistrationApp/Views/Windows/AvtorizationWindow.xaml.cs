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
using WpfRegistrationApp.Views.Pages.ClientPages;
using WpfRegistrationApp.Views.Windows.AdminWindows;
using WpfRegistrationApp.Views.Windows.ClientWindows;

namespace WpfRegistrationApp
{
    /// <summary>
    /// Логика взаимодействия для AvtorizationWindow.xaml
    /// </summary>
    public partial class AvtorizationWindow : Window
    {
        public AvtorizationWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AvtorizationWindow());
        }

        private void PSWBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TXB_Password.Text = PSWBox.Password;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXB_Password.Text == "" && txbLogin.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }
                else
                {
                    // Запрос на авторизацию
                    var currentUser = Data.re.User.FirstOrDefault(item => item.Username == txbLogin.Text && item.Password == PSWBox.Password);
                    if (currentUser != null)
                    {
                        switch (currentUser.IDRole)
                        {
                            case "a":
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.ShowDialog();
                                break;

                            case "c":

                                ClientWindow clientWindows  = new ClientWindow();
                                clientWindows.ShowDialog();
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Пользователь не найден!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
        Application.Current.Shutdown();
        }
    }
}
