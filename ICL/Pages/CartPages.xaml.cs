using ICL.Components;
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

namespace ICL.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPages.xaml
    /// </summary>
    public partial class CartPages : Page
    {
        public CartPages()
        {
            InitializeComponent();
            LbCart.ItemsSource = App.DB.ZakazProduct.Where(x => x.EmployeId == App.LoggedEmployee.Id &&  x.ZakazId == null).ToList();
            int pri = 0; 
            IEnumerable<ZakazProduct> products = App.DB.ZakazProduct.Where(x => x.ZakazId == null && x.EmployeId == App.LoggedEmployee.Id).ToList();
            foreach (var items in products)
            {
                pri += (int)items.Product.Price * (int)items.Count;
            }
            TbPrice.Text = pri.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as ZakazProduct;
            if (selectedclient.Count > 1)
            {
                selectedclient.Count = selectedclient.Count - 1;
            }
            else
            {
                App.DB.ZakazProduct.Remove(selectedclient);
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new CartPages());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as ZakazProduct;          
            App.DB.ZakazProduct.Remove(selectedclient);
            App.DB.SaveChanges();
            NavigationService.Navigate(new CartPages());
        }

      

   

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as ZakazProduct;
            if (selectedclient.Count < 20)
            {
                selectedclient.Count = selectedclient.Count + 1;
            }
            else
            {
                MessageBox.Show("Можно заказать тока 20 шт");
                return;
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new CartPages());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Zakaz zakaz = new Zakaz();
            zakaz.Prise = TbPrice.Text;
            App.DB.Zakaz.Add(zakaz);
            App.DB.SaveChanges();
            IEnumerable<ZakazProduct> products = App.DB.ZakazProduct.Where(x => x.ZakazId == null && x.EmployeId == App.LoggedEmployee.Id).ToList();
            foreach (var items in products)
            {
                items.ZakazId = zakaz.Id;
            }
            App.DB.SaveChanges();
            MessageBox.Show($"Заказ № {zakaz.Id} оформлен.\n Закакз будет готов к {DateTime.Now.AddDays(17).ToString("D")}. \n Забрать можно по адрезу  ул. Сибирский тракт, д. 34, к.1. \n Контактный телефон: +7 (843) 279-58-23 ");
            NavigationService.Navigate(new CartPages());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }
    }
}
