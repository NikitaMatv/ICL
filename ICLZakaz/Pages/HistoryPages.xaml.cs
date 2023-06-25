using ICLZakaz.Components;
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

namespace ICLZakaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPages.xaml
    /// </summary>
    public partial class HistoryPages : Page
    {
        public HistoryPages()
        {
            InitializeComponent();
            LbCart.ItemsSource = App.DB.ZakazProduct.Where( x=> x.ZakazId != null && x.Zakaz.IsClame != true).ToList();
           
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var senselected = LbCart.SelectedItem as ZakazProduct;
            var zakazzz = App.DB.Zakaz.FirstOrDefault(x=> x.Id == senselected.ZakazId);
            if (zakazzz == null)
            {
                return;
            }
            if (TbCode.Text == string.Empty)
            {
                return;
            }
            if(int.Parse(TbCode.Text) == zakazzz.Code)
            {
                zakazzz.IsClame = true;
                App.DB.SaveChanges();
                LbCart.ItemsSource = App.DB.ZakazProduct.Where(x => x.ZakazId != null && x.Zakaz.IsClame != true).ToList();
            }
            else
            {
                MessageBox.Show("Код заказ неверный");
                return;
            }
        }
    }
}
