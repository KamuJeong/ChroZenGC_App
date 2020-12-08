﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UC_MainPageDetDetailView : ContentView
	{
        #region Bindable Property

        #region IsSelected : bool

        public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create("IsSelected", typeof(bool), typeof(UC_MainPageDetDetailView),
            defaultValue: false,
            propertyChanged: onIsSelectedPropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_MainPageDetDetailView).IsSelected = (bool)newValue;
            }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        #endregion IsSelected : bool

        #endregion Bindable Property

        public UC_MainPageDetDetailView ()
		{
			InitializeComponent ();
		}
	}
}