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
    public partial class View_Main : ContentView
    {
        public View_Main(ViewModel_Main viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}