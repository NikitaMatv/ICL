using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICL.Components
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
    }
}
