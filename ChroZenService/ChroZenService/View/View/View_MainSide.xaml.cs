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
	public partial class View_MainSide : ContentView
	{
        BindableProperty SelectedIndex = BindableProperty.Create("SelectedIndex", typeof(int), typeof(View_MainSide), null,
            propertyChanged: OnSelectedIndexChanged);

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            
        }

        public View_MainSide ()
		{
			InitializeComponent ();
		}
	}
}