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
    /// Логика взаимодействия для HistoryPages.xaml
    /// </summary>
    public partial class HistoryPages : Page
    {
        public HistoryPages()
        {
            InitializeComponent();
            LbCart.ItemsSource = App.DB.ZakazProduct.Where(x => x.EmployeId == App.LoggedEmployee.Id && x.ZakazId != null).ToList();
           
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }
    }
}
