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
    public partial class Grid_Config_Oven : ContentView, IAsyncInitialize
    {
        public Grid_Config_Oven()
        {
            InitializeComponent();
        }

        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }
    }

}