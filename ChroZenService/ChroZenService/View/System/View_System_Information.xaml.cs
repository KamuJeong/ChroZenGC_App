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
	public partial class View_System_Information : ContentView
	{
		public View_System_Information ()
		{
			InitializeComponent ();
		}

        private async void OnSetTapped(object sender, EventArgs e)
        {
			setButton.Scale = 1.1;
			await setButton.ScaleTo(1.0, 500, Easing.SpringIn);
			settable.IsToggled = false;
        }

        private async void OnSyncTapped(object sender, EventArgs e)
        {
			syncButton.Scale = 1.1;
			await syncButton.ScaleTo(1.0, 500, Easing.SpringIn);
		}
    }
}