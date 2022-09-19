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

namespace WpfApp1.Views
{
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private async void Authorize(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = await Utility.Authorization.AsyncSignIn(Login.Text, Password.Text);
                MessageBox.Show("Вы успешно авторизовались", "Поздравляем!", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void ToRegistration(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Registration());
    }
}
