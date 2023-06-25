using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICLADMIN.Components
{
    public partial class Zakaz
    {
        public Visibility VisabilityTbCode
        {
            get
            {
                if (Data == DateTime.Now)
                {                 
                    return Visibility.Visible;

                }
                else
                {
                    return Visibility.Collapsed;
                }

            }
        }
        public Visibility VisabilityTbData
        {
            get
            {
                if (Data != DateTime.Now)
                {
                    return Visibility.Visible;

                }
                else
                {
                    return Visibility.Collapsed;
                }

            }
        }
        public Visibility VisabilityBt
        {
            get
            {
                if (App.LoggedEmployee.Id != 1)
                {
                    return Visibility.Visible;

                }
                else
                {
                    return Visibility.Collapsed;
                }

            }
        }
    }
}
