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
    /// Логика взаимодействия для MainPages.xaml
    /// </summary>
    public partial class MainPages : Page
    {
        public MainPages()
        {
            InitializeComponent();
            CbCategory.ItemsSource = App.DB.Cotegories.ToList();
            LBProduct.ItemsSource = App.DB.Product.ToList();
            if (App.LoggedEmployee.Id != 1)
            {
                BtAdd.Visibility = Visibility.Collapsed;
                BtEdit.Visibility = Visibility.Collapsed;
             
            }
            else
            {
                BtCart.Visibility = Visibility.Collapsed;
                BtHistory.Visibility = Visibility.Collapsed;
            }
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Product;
            if (selectedclient == null)
            {
                MessageBox.Show("Выберете товар");
                return;
            }
            else
            {
                ZakazProduct zakaz = new ZakazProduct();
                zakaz.ProductId = selectedclient.Id;
                zakaz.Count = 1;
                zakaz.EmployeId = App.LoggedEmployee.Id;
                if (App.DB.ZakazProduct.FirstOrDefault(x => x.ZakazId == null && x.EmployeId == App.LoggedEmployee.Id && x.ProductId == selectedclient.Id) == null)
                {
                    App.DB.ZakazProduct.Add(zakaz);
                }
                else
                {
                   var zakazz = App.DB.ZakazProduct.FirstOrDefault(x => x.ZakazId == null && x.EmployeId == App.LoggedEmployee.Id && x.ProductId == selectedclient.Id) as ZakazProduct;
                    if(zakazz.Count < 20)
                    zakazz.Count = zakazz.Count + 1;
                    
                }
                
                App.DB.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> products = App.DB.Product.ToList();
            if (TbSearch.Text.Length > 0 && byText.IsChecked == true)
            {
                products = products.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower()) || x.Description.ToLower().Contains(TbSearch.Text.ToLower()));
            }
            if (CbCategory.SelectedIndex >= 0 && byCategory.IsChecked == true)
            {

                if (CbCategory.SelectedIndex == 0)
                    products = products.Where(x => x.CategoryId == 1).ToList();
                else if (CbCategory.SelectedIndex == 1)
                    products = products.Where(x => x.CategoryId == 2).ToList();
                else if (CbCategory.SelectedIndex == 2)
                    products = products.Where(x => x.CategoryId == 3).ToList();
            }
            LBProduct.ItemsSource = products;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPages());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPages(new Product()));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var select = LBProduct.SelectedItem as Product;
            if (select != null)
                NavigationService.Navigate(new AddEditPages(select));
            else
                MessageBox.Show("Выберете товар");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            App.LoggedEmployee = null;
            NavigationService.Navigate(new AutorizatePages());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryPages());
        }
    }
}
