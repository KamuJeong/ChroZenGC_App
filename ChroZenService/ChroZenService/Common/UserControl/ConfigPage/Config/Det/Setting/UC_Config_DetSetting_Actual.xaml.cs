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
	public partial class UC_Config_DetSetting_Actual : ContentView
    {
        #region BindableProperty

        #region IsValueVisible

        public static readonly BindableProperty IsValueVisibleProperty = BindableProperty.Create("IsValueVisible", typeof(bool), typeof(UC_Config_DetSetting_Actual));

        public bool IsValueVisible
        {
            get { return (bool)GetValue(IsValueVisibleProperty); }
            set { SetValue(IsValueVisibleProperty, value); }
        }

        #endregion IsValueVisible

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_Config_DetSetting_Actual));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion Text

        #region UnitText

        public static readonly BindableProperty UnitTextProperty = BindableProperty.Create("UnitText", typeof(string), typeof(UC_Config_DetSetting_Actual));

        public string UnitText
        {
            get { return (string)GetValue(UnitTextProperty); }
            set { SetValue(UnitTextProperty, value); }
        }

        #endregion UnitText

        #region TextColor

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(UC_Config_DetSetting_Actual));

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion TextColor

        #endregion BindableProperty

        public UC_Config_DetSetting_Actual()
		{
			InitializeComponent ();
		}
	}
}