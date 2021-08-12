using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    public class MaxValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return double.IsPositiveInfinity((double)value) ? "" : $"{value:g} ≥"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MinValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return double.IsNegativeInfinity((double)value) ? "" : $"{value:g} ≤";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeyPad : ContentPage
    {
        ValueEditor instance;

        public KeyPad(ValueEditor inst)
        {
            double buttonHeight = (int)((double)Application.Current.Resources["ButtonFontSizeKey"] * 3);
            Resources.Add("ButtonHeightKey", buttonHeight);

            InitializeComponent();

            instance = inst;
            MinValue = inst.Min;
            MaxValue = inst.Max;

            CurrentValue = instance.Value;
            int pt = CurrentValue.IndexOf('.');
            decimals = pt < 0 ? 0 : CurrentValue.Length - 1 - pt;

            OnCurrentValueChanged(this, CurrentValue, CurrentValue);
            IsModified = false;

            BindingContext = this;
        }


        public string Name => instance.Caption;

        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create("CurrentValue", typeof(string), typeof(KeyPad), propertyChanged: OnCurrentValueChanged);

        private static void OnCurrentValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var pad = (KeyPad)bindable;

                double value = 0.0;
                string dv = newValue as string;
                if (dv == null || !string.Equals(dv, "-"))
                {
                    value = double.Parse(dv);
                }
                pad.IsValid = value >= pad.MinValue && value <= pad.MaxValue;

                if (!object.Equals(oldValue, newValue))
                    pad.IsModified = true;
            }
            catch
            {
                
            }
        }

        public string CurrentValue
        {
            get
            {
                var value = (string)GetValue(CurrentValueProperty);
                return string.IsNullOrEmpty(value) ? "0" : value;
            }
            set { SetValue(CurrentValueProperty, value); }
        }

        public double MinValue { get; set; } = double.NegativeInfinity;

        public bool MinusKeyEnabled => MinValue < 0.0;

        public double MaxValue { get; set; } = double.PositiveInfinity;

        private int decimals = 0;

        public bool OnKeyEnabled => instance.IsSet(ValueEditor.SwitchProperty) && instance.Switch == false;
        public bool OffKeyEnabled => instance.IsSet(ValueEditor.SwitchProperty) && instance.Switch == true;

        public static readonly BindableProperty IsModifiedProperty = BindableProperty.Create("IsModified", typeof(bool), typeof(KeyPad));

        public bool IsModified
        {
            get => (bool)GetValue(IsModifiedProperty);
            private set => SetValue(IsModifiedProperty, value);
        }

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(KeyPad));
        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            private set => SetValue(IsValidProperty, value);
        }

        public ICommand KeyCommand => new Command<string>(execute: OnKeyClick, canExecute: OnCanKeyClick);

        private bool OnCanKeyClick(string key)
        {
            switch (key)
            {
                case "±":
                    return MinusKeyEnabled;

                case "ON":
                    return OnKeyEnabled;
                case "OFF":
                    return OffKeyEnabled;

                case ".":
                    return decimals > 0;
            }

            return true;
        }

        public void OnKeyClick(string key)
        {
            string value = CurrentValue;

            switch (key)
            {
                case "✖":
                    Navigation.PopModalAsync();
                    return;

                case "DEL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        CurrentValue = value.Substring(0, value.Length - 1);
                    }
                    return;

                case "ON":
                    if (!IsValid) break;
                    instance.Value = string.Format($"{{0:F{decimals}}}", double.Parse(CurrentValue));  
                    instance.Switch = true;
                    Navigation.PopModalAsync();
                    instance.Command?.Execute(instance.CommandParameter);
                    return;

                case "OFF":
                    instance.Switch = false;
                    Navigation.PopModalAsync();
                    instance.Command?.Execute(instance.CommandParameter);
                    return;

                case "OK":
                    if (!IsValid) break;
                    instance.Value = string.Format($"{{0:F{decimals}}}", double.Parse(CurrentValue));
                    Navigation.PopModalAsync();
                    instance.Command?.Execute(instance.CommandParameter);
                    return;

                default:
                    if (!IsModified)
                        value = string.Empty;

                    if (value.Length > 10)
                        return;

                    if (key == "±")
                    {
                        if (value.Length > 0 && value[0] == '-')
                        {
                            value = value.TrimStart('-');
                        }
                        else
                        {
                            value = "-" + value;
                        }
                    }

                    if (value.Any(c => c == '.'))
                    {
                        if (key == ".")
                            return;
                    }
                    else if (key != "." && value.Length > 0)
                    {
                        if (value[0] == '-')
                        {
                            value = "-" + value.TrimStart('-', '0');
                        }
                        else
                        {
                            value = value.TrimStart('0');
                        }
                    }

                    if (key != "±")
                        CurrentValue = value + key;
                    else
                        CurrentValue = value;

                    break;
            }
        }

        public KeyPad()
        {
            //double buttonHeight = (int)((double)Application.Current.Resources["ButtonFontSizeKey"] * 3);
            //Resources.Add("ButtonHeightKey", buttonHeight);

            InitializeComponent();

        }

        public double ButtonHeight => (double) Application.Current.Resources["ButtonFontSizeKey"] * 3;

        #region Property

        public enum E_KEYPAD_TYPE
        {
            POSITIVE_INT,
            INT,
            DOUBLE
        }

        #region CurrentValue : double



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

        //public static readonly BindableProperty MaxValueProperty =
        //BindableProperty.Create("MaxValue", typeof(double), typeof(KeyPad),
        //    defaultValue: 0d
        //    , defaultBindingMode: BindingMode.TwoWay);


        //public double MaxValue
        //{
        //    get { return (double)GetValue(MaxValueProperty); }
        //    set { SetValue(MaxValueProperty, value); }
        //}

        //#endregion MaxValue : double

        //#region MinValue : double

        //public static readonly BindableProperty MinValueProperty =
        //BindableProperty.Create("MinValue", typeof(double), typeof(KeyPad),
        //    defaultValue: 0d
        //    , defaultBindingMode: BindingMode.TwoWay);


        //public double MinValue
        //{
        //    get { return (double)GetValue(MinValueProperty); }
        //    set { SetValue(MinValueProperty, value); }
        //}

        #endregion MinValue : double

        #endregion Property


    }

}
