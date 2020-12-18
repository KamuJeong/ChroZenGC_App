using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService.Common.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextBoxEx : ContentView
	{
        public static readonly BindableProperty TapGestureCommandProperty = BindableProperty.Create("TapGestureCommand", typeof(RelayCommand), typeof(UC_MainPageButton),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: onTapGestureCommandChanged);

        private static void onTapGestureCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                (bindable as UC_MainPageButton).TapGestureCommand = (newValue as RelayCommand);
        }

        public RelayCommand TapGestureCommand
        {
            set
            {
                SetValue(TapGestureCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(TapGestureCommandProperty);

            }
        }

        public TextBoxEx ()
		{
			InitializeComponent ();
		}
	}
}