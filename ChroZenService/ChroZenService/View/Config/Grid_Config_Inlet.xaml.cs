using ChroZenGC.Core.Wrappers;
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
    public partial class Grid_Config_Inlet : ContentView
    {
        public Grid_Config_Inlet()
        {
            InitializeComponent();
        }

        public int Port { get; set; }

        public InletSetupWrapper Inlet
        {
            get
            {
                if(BindingContext is ViewModel_Config model)
                {
                    return model.Inlets[Port];
                }
                return null;
            }

        }
    }
}