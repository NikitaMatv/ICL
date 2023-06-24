using ICLADMIN.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditPages.xaml
    /// </summary>
    public partial class AddEditPages : Page
    {
        Product contetxtproduct;
        public AddEditPages(Product product)
        {
            InitializeComponent();
            contetxtproduct = product;
            DataContext = contetxtproduct;
            IsActiveCb.IsChecked = contetxtproduct.IsActive;
            CbCotegories.ItemsSource = App.DB.Cotegories.ToList();
            if( contetxtproduct.Id != 0)
            CbCotegories.SelectedItem = contetxtproduct.Cotegories;
           
        }

        private void MainClientBt_Click(object sender, RoutedEventArgs e)
        {
            if(contetxtproduct.Name != string.Empty && contetxtproduct.Description != string.Empty && contetxtproduct.Price > 0 && CbCotegories.SelectedIndex >= 0)
            {
                contetxtproduct.CategoryId = CbCotegories.SelectedIndex + 1;
                if (IsActiveCb.IsChecked == false)
                    contetxtproduct.IsActive = false;
                else             
                    contetxtproduct.IsActive = true;
              if(contetxtproduct.Id == 0)
                App.DB.Product.Add(contetxtproduct);
                App.DB.SaveChanges();
                NavigationService.Navigate(new MainPages());
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
           
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }

        private void PasswordTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[А-яA-z0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
