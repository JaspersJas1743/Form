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
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = await Utility.Authorization.AsyncRegistration(Login.Text, Password.Text, ConfirmePassword.Text);
                MessageBox.Show("Поздравляю! Вы стали смешариком!", "УРА!", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Некорректные данные", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }
    }
}
