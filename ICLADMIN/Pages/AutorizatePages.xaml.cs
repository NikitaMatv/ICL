using ICLADMIN.Components;
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

namespace ICLADMIN.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizatePages.xaml
    /// </summary>
    public partial class AutorizatePages : Page
    {
        public AutorizatePages()
        {
            InitializeComponent();
        }
        private void AutorBt_Click(object sender, RoutedEventArgs e)
        {
            var employee = App.DB.Employe.FirstOrDefault(emp => emp.Login == LoginTb.Text);
            if (employee == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if(employee.Id != 1)
            {
                MessageBox.Show("Это приложение только для администратора");
                return;
            }
            if (employee.Password != PasswordTb.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            
            App.LoggedEmployee = employee;


            NavigationService.Navigate(new MainPages());



        }

        private void RegBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPages(new Employe()));
        }
    }
}

