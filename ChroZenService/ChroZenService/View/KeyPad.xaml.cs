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
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ConstraintsAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Description of target property</param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="decimals"></param>
        /// <param name="onoff">Corresponding property for switching on or off</param>
        /// <param name="predicate">Method name for constraint's validity </param>
        public ConstraintsAttribute(string name, double max = double.PositiveInfinity, double min = double.NegativeInfinity, int decimals = 0, string onoff = null, string predicate = null)
        {
            Name = name;
            MaxValue = max;
            MinValue = min;
            Decimals = decimals;
            OnOffProeprty = onoff;
            Predicate = predicate;
        }

        public string Name { get; }
        public double MaxValue { get; }
        public double MinValue { get; }
        public int Decimals { get; }
        public string OnOffProeprty { get; }
        public string Predicate { get; }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeyPad : ContentPage
    {
        private object instance;
        private PropertyInfo valuePropertyInfo;
        private PropertyInfo onoffPropertyInfo;

        public KeyPad(object propertyOwner, PropertyInfo valueProperty)
        {
            double buttonHeight = (int)((double)Application.Current.Resources["ButtonFontSizeKey"] * 3);
            Resources.Add("ButtonHeightKey", buttonHeight);

            InitializeComponent();

            instance = propertyOwner ?? throw new ArgumentNullException(nameof(propertyOwner));
            valuePropertyInfo = valueProperty ?? throw new ArgumentNullException(nameof(valueProperty));

            Name = valueProperty.Name;
            maxValue = double.PositiveInfinity;
            minValue = double.NegativeInfinity;
            decimals = 0;
            onoffPropertyInfo = null;

            ConstraintsAttribute attr = null;
            foreach (var at in valueProperty.GetCustomAttributes<ConstraintsAttribute>())
            {
                if(at.Predicate == null)
                {
                    attr = at;
                    break;
                }

                var m = instance.GetType().GetMethod(at.Predicate, BindingFlags.Public | BindingFlags.Instance);
                if(m != null && (bool)m.Invoke(instance, null))
                {
                    attr = at;
                }
            }

            if(attr != null)
            {
                Name = attr.Name;
                maxValue = attr.MaxValue;
                minValue = attr.MinValue;
                decimals = attr.Decimals;
                onoffPropertyInfo = attr.OnOffProeprty == null ? null : instance.GetType().GetProperty(attr.OnOffProeprty);

            }

            CurrentValue = string.Format($"{{0:F{decimals}}}", Convert.ChangeType(valueProperty.GetValue(propertyOwner), typeof(double)));
            OnCurrentValueChanged(this, CurrentValue, CurrentValue);
            IsModified = false;

            BindingContext = this;
        }

        public string Name { get; }

        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create("CurrentValue", typeof(string), typeof(KeyPad), propertyChanged: OnCurrentValueChanged);

        private static void OnCurrentValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var pad = (KeyPad)bindable;

                var value = double.Parse(newValue as string);
                pad.IsValid = value >= pad.minValue && value <= pad.maxValue;

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

        private double minValue = double.NegativeInfinity;

        public bool MinusKeyEnabled => minValue < 0.0;

        private double maxValue = double.PositiveInfinity;

        public string MaxValue => maxValue < double.PositiveInfinity ? string.Format($"{{0:F{decimals}}}", maxValue) : string.Empty;

        private int decimals = 0;

        public bool OnOffKeyEnabled => onoffPropertyInfo != null;

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
                case "-":
                    return MinusKeyEnabled;

                case "ON":
                case "OFF":
                    return OnOffKeyEnabled;

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
                case "∇":
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
                    valuePropertyInfo.SetValue(instance, Convert.ChangeType(CurrentValue, valuePropertyInfo.PropertyType));
                    onoffPropertyInfo.SetValue(instance, true);
                    Navigation.PopModalAsync();
                    return;

                case "OFF":
                    onoffPropertyInfo.SetValue(instance, false);
                    Navigation.PopModalAsync();
                    return;

                case "OK":
                    if (!IsValid) break;
                    valuePropertyInfo.SetValue(instance, Convert.ChangeType(CurrentValue, valuePropertyInfo.PropertyType));
                    Navigation.PopModalAsync();
                    return;

                default:
                    if (!IsModified)
                        value = string.Empty;

                    if (value.Length > 10)
                        return;

                    if (key == "-" && !string.IsNullOrEmpty(value))
                        return;

                    if (value.Any(c => c == '.'))
                    {
                        if (key == ".")
                            return;
                    }
                    else if (key != ".")
                    {
                        value = value.TrimStart('0');
                    }

                    CurrentValue = value + key;

                    break;
            }
        }

        public KeyPad()
        {
            double buttonHeight = (int)((double)Application.Current.Resources["ButtonFontSizeKey"] * 3);
            Resources.Add("ButtonHeightKey", buttonHeight);

            InitializeComponent();

        }

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

        #region Command



        #endregion Command

    }

}
