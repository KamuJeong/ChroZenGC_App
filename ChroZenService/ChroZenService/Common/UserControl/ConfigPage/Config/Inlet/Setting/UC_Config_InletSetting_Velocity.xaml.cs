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
	public partial class UC_Config_InletSetting_Velocity : ContentView
    {
        #region BindableProperty

        #region IsValueVisible

        public static readonly BindableProperty IsValueVisibleProperty = BindableProperty.Create("IsValueVisible", typeof(bool), typeof(UC_Config_InletSetting_Velocity));

        public bool IsValueVisible
        {
            get { return (bool)GetValue(IsValueVisibleProperty); }
            set { SetValue(IsValueVisibleProperty, value); }
        }

        private static void onIsValueVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).IsValueVisible = (bool)newValue;
            //}
        }

        #endregion IsValueVisible

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_Config_InletSetting_Velocity));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void onTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).Text = (string)newValue;
            //}
        }

        #endregion Text

        #region UnitText

        public static readonly BindableProperty UnitTextProperty = BindableProperty.Create("UnitText", typeof(string), typeof(UC_Config_InletSetting_Velocity));

        public string UnitText
        {
            get { return (string)GetValue(UnitTextProperty); }
            set { SetValue(UnitTextProperty, value); }
        }

        private static void onUnitTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).UnitText = (string)newValue;
            //}
        }

        #endregion UnitText

        #region TextColor

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(UC_Config_InletSetting_Velocity));

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        private static void onTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).TextColor = (string)newValue;
            //}
        }

        #endregion TextColor

        #endregion BindableProperty

        public UC_Config_InletSetting_Velocity()
		{
			InitializeComponent ();
		}
	}
}