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

        public KeyPad()
        {
            InitializeComponent();
        }

        #endregion 생성자 & 이벤트 헨들러

        #region Binding

        #region Property

        public enum E_KEYPAD_TYPE
        {
            POSITIVE_INT,
            INT,
            DOUBLE
        }

        #region CurrentValue : double

        public static readonly BindableProperty CurrentValueProperty =
        BindableProperty.Create("CurrentValue", typeof(string), typeof(KeyPad));


        public string CurrentValue
        {
            get { return (string)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        #endregion CurrentValue : double

        #region Title : string

        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(KeyPad),
            defaultValue: ""
            , defaultBindingMode: BindingMode.TwoWay);


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion Title : string

        #region KeyPadType : E_KEYPAD_TYPE

        public static readonly BindableProperty KeyPadTypeProperty =
        BindableProperty.Create("KeyPadType", typeof(E_KEYPAD_TYPE), typeof(KeyPad),
            defaultValue: E_KEYPAD_TYPE.INT
            , defaultBindingMode: BindingMode.TwoWay);

        public E_KEYPAD_TYPE KeyPadType
        {
            get { return (E_KEYPAD_TYPE)GetValue(KeyPadTypeProperty); }
            set { SetValue(KeyPadTypeProperty, value); }
        }

        #endregion KeyPadType : E_KEYPAD_TYPE

        #region MaxValue : double

        public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create("MaxValue", typeof(double), typeof(KeyPad),
            defaultValue: 0d
            , defaultBindingMode: BindingMode.TwoWay);


        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        #endregion MaxValue : double

        #region MinValue : double

        public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create("MinValue", typeof(double), typeof(KeyPad),
            defaultValue: 0d
            , defaultBindingMode: BindingMode.TwoWay);


        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        #endregion MinValue : double

        #endregion Property

        #region Command



        #endregion Command

        #endregion Binding
    }
}