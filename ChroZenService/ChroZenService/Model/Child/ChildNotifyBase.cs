using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ChildNotifyBase : BindableNotifyBase
    {
        public static readonly BindableProperty IsThisTabSelectedProperty =
            BindableProperty.Create("IsThisTabSelected", typeof(bool), typeof(ChildNotifyBase),
                propertyChanged: onIsThisTabSelectedPropertyChanged,
                defaultBindingMode: BindingMode.TwoWay);

        private static void onIsThisTabSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue!=null)
            {
                (bindable as ChildNotifyBase).IsThisTabSelected = (bool)newValue;
            }
        }

        public bool IsThisTabSelected
        {
            get { return (bool)GetValue(IsThisTabSelectedProperty); }
            set { SetValue(IsThisTabSelectedProperty, value); }
        }
    }
}
