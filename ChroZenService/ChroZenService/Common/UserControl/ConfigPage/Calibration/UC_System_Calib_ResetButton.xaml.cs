using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UC_System_Calib_ResetButton : UC_System_Calib_ButtonBase
    {   
        public UC_System_Calib_ResetButton()
        {
            InitializeComponent();
        }
    }
}