using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ICLZakaz.Components;
namespace ICLZakaz
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ICLEntities1 DB = new ICLEntities1();
        public static Employe LoggedEmployee;
        public static bool IsAutorizate = false;
    }
}
