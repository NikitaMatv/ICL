using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICL.Components
{
    public partial class Product
    {
       public Visibility VisabilityBt
        {
            get
            {
                if (IsActive == true)
                {
                    if (App.LoggedEmployee.Id == 1)
                    {
                        return Visibility.Hidden;
                    }
                    return Visibility.Visible;
                    
                }
                else
                {
                    return Visibility.Hidden;
                }
                
            }
        }
    }
}
