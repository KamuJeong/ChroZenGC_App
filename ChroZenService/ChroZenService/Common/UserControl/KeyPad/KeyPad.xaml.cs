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
	public partial class KeyPad : ContentView
	{
        #region 생성자 & 이벤트 헨들러

        public KeyPad ()
		{
			InitializeComponent ();
		}

        #endregion 생성자 & 이벤트 헨들러

        #region Property

        public enum E_KEYPAD_TYPE
        {
            POSITIVE_INT,
            INT,
            DOUBLE
        }

        #region CurrentValue : double

        public static readonly BindableProperty CurrentValueProperty =
        BindableProperty.Create("CurrentValue", typeof(double), typeof(KeyPad),
            defaultValue: 0d,
            propertyChanged: onCurrentValuePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onCurrentValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as KeyPad).CurrentValue = (double)newValue;
            }
        }

        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        #endregion CurrentValue : double

        #region Title : string

        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(KeyPad),
            defaultValue: "",
            propertyChanged: onTitlePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as KeyPad).Title = (string)newValue;
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion Title : string

        #region KeyPadType : E_KEYPAD_TYPE

        public static readonly BindableProperty KeyPadTypeProperty =
        BindableProperty.Create("KeyPadType", typeof(E_KEYPAD_TYPE), typeof(KeyPad),
            defaultValue: E_KEYPAD_TYPE.INT,
            propertyChanged: onKeyPadTypePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onKeyPadTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as KeyPad).KeyPadType = (E_KEYPAD_TYPE)newValue;
            }
        }

        public E_KEYPAD_TYPE KeyPadType
        {
            get { return (E_KEYPAD_TYPE)GetValue(KeyPadTypeProperty); }
            set { SetValue(KeyPadTypeProperty, value); }
        }

        #endregion KeyPadType : E_KEYPAD_TYPE

        #region MaxValue : double

        public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create("MaxValue", typeof(double), typeof(KeyPad),
            defaultValue: 0d,
            propertyChanged: onMaxValuePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onMaxValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as KeyPad).MaxValue = (double)newValue;
            }
        }

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        #endregion MaxValue : double

        #region MinValue : double

        public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create("MinValue", typeof(double), typeof(KeyPad),
            defaultValue: 0d,
            propertyChanged: onMinValuePropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onMinValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as KeyPad).MinValue = (double)newValue;
            }
        }

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        #endregion MinValue : double

        #endregion Property
    }
}