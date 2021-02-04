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
	public partial class UC_Config_Aux_Flow_Picker : Picker
	{
        #region UCSelectedIndexChangedCommand

        public static readonly BindableProperty UCSelectedIndexChangedCommandProperty = BindableProperty.Create("UCSelectedIndexChangedCommand", typeof(RelayCommand), typeof(UC_Config_Aux_Flow_Picker)
            );


        public RelayCommand UCSelectedIndexChangedCommand
        {
            get { return (RelayCommand)GetValue(UCSelectedIndexChangedCommandProperty); }
            set { SetValue(UCSelectedIndexChangedCommandProperty, value); }
        }

        private static void onUCSelectedIndexChangedCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).UCSelectedIndexChangedCommand = (RelayCommand)newValue;
            //}
        }

        #endregion UCSelectedIndexChangedCommand

        #region UCSelectedIndexChangedCommandParameter

        public static readonly BindableProperty UCSelectedIndexChangedCommandParameterProperty = BindableProperty.Create("UCSelectedIndexChangedCommandParameter", typeof(object), typeof(UC_Config_Aux_Flow_Picker)
            );

        public object UCSelectedIndexChangedCommandParameter
        {
            get { return (object)GetValue(UCSelectedIndexChangedCommandParameterProperty); }
            set { SetValue(UCSelectedIndexChangedCommandParameterProperty, value); }
        }

        private static void onUCSelectedIndexChangedCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).UCSelectedIndexChangedCommandParameter = newValue;
            //}
        }

        #endregion UCSelectedIndexChangedCommandParameter

        public UC_Config_Aux_Flow_Picker()
		{
			InitializeComponent ();
		}
	}
}