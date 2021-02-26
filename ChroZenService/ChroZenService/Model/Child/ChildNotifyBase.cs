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
                defaultBindingMode: BindingMode.TwoWay);

        public bool IsThisTabSelected
        {
            get { return (bool)GetValue(IsThisTabSelectedProperty); }
            set { SetValue(IsThisTabSelectedProperty, value); }
        }
    }
}
