using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICL.Components
{
    public partial class ZakazProduct
    {
        public Visibility VisabilityTbCode
        {
            get
            {
                int zId = (int)ZakazId;
                Zakaz zakaz = App.DB.Zakaz.FirstOrDefault(x => x.Id == zId);
                if (zakaz.Data < DateTime.Now )
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
                int zId = (int)ZakazId;
                Zakaz zakaz = App.DB.Zakaz.FirstOrDefault(x => x.Id == zId);
                if ( zakaz.Data > DateTime.Now)
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
