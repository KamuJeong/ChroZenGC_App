using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_Header : ContentView
    {
        public View_Header()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new KeyPad(this, GetType().GetProperty(nameof(Price))));

            Debug.WriteLine($"Price {Price} : {Sold}");

            //if (BindingContext is ViewModel_Root vm)
            //{
            //    vm.MainView = new View_Main();
            //}


        }

        [Constraints("Price", min: 0.0, max: 10.0, onoff: nameof(Sold))]
        public int Price { get; set; } = 12;
        public bool Sold { get; set; }
    }
}