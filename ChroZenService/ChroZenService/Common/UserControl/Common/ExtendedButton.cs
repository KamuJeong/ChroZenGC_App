using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ExtendedButton : Xamarin.Forms.Button
    {
        public static BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create("HorizontalTextAlignment", typeof(TextAlignment), typeof(ExtendedButton),defaultValue:TextAlignment.Center);
        public Xamarin.Forms.TextAlignment HorizontalTextAlignment
        {
            get
            {
                return (Xamarin.Forms.TextAlignment)GetValue(HorizontalTextAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalTextAlignmentProperty, value);
            }
        }
    }
}
