using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ChroZenService
{
    public class EnumPicker : Picker
    {
        private Type enumType;
        private Dictionary<string, object> dictionaryEnum;

        public static readonly BindableProperty GapProperty = BindableProperty.Create("Gap", typeof(bool), typeof(EnumPicker), false, propertyChanged: GapChanged);

        private static void GapChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EnumPicker picker && picker.enumType != null && picker.dictionaryEnum != null)
            {
                picker.enumType = null;
                ValueChanged(bindable, null, picker.Value);
            }
        }

        public bool Gap
        {
            get => (bool)GetValue(GapProperty);
            set => SetValue(GapProperty, value);
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(Enum), typeof(EnumPicker), defaultBindingMode: BindingMode.TwoWay, propertyChanged: ValueChanged);

        private static void ValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EnumPicker picker && newValue.GetType().IsEnum)
            {
                if (newValue.GetType() != picker.enumType)
                {
                    picker.ClearValue(InputTransparentProperty);

                    picker.enumType = newValue.GetType();
                    picker.dictionaryEnum = new Dictionary<string, object>();
                    foreach (var e in Enum.GetValues(picker.enumType))
                    {
                        if (picker.Filter != null && !picker.Filter((Enum)Convert.ChangeType(e, picker.enumType)))
                            continue;

                        picker.dictionaryEnum.Add(picker.Gap ?
                                Regex.Replace($"{e}", @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0") : $"{e}", (object)e);
                    }
                    picker.ItemsSource = picker.dictionaryEnum.Keys.ToList();
                }
                int select = -1;
                for (int i = 0; i < picker.dictionaryEnum.Values.Count; ++i)
                {
                    if (picker.dictionaryEnum.Values.ElementAt(i).Equals(Convert.ChangeType(newValue, picker.enumType)))
                    {
                        select = i;
                        break;
                    }
                }
                picker.SelectedIndex = select;
            }
        }

        public Enum Value
        {
            get => (Enum)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty FilterProperty = BindableProperty.Create("Filter", typeof(Predicate<Enum>), typeof(EnumPicker), propertyChanged: FilterChanged);

        private static void FilterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EnumPicker picker && picker.enumType != null)
            {
                var enumType = picker.enumType;
                picker.enumType = null;
                ValueChanged(bindable, null, Convert.ChangeType(picker.Value, enumType));
            }
        }

        public Predicate<Enum> Filter
        {
            get => (Predicate<Enum>)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }


        public EnumPicker()
        {
            BackgroundColor = Color.Transparent;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            HorizontalTextAlignment = TextAlignment.Center;
            TextColor = Color.White;
            FontSize = (double)Application.Current.Resources["DefaultFontSizeKey"];
            ScaleY = 1.2;

            SelectedIndexChanged += OnSelectionChanged;
        }

        bool lockable = true;
        public bool Lockable 
        {
            get => lockable;
            set
            {
                lockable = value;
                if (!lockable)
                    ClearValue(InputTransparentProperty);
                else
                    OnPropertyChanged("Lockable");
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (!IsSet(InputTransparentProperty))
            {
                Element element = this;
                while (element != null)
                {
                    if (element.BindingContext != null)
                    {
                        var prop = element.BindingContext.GetType().GetProperty("IsEditable");
                        if (prop != null && prop.GetValue(element.BindingContext) is bool)
                        {
                            SetBinding(InputTransparentProperty,
                                new Binding("IsEditable",
                                            source: element.BindingContext,
                                            converter: new AreEqualConverter(),
                                            converterParameter: "False"));
                            break;
                        }
                    }
                    element = element.Parent;
                }
            }
        }

        [SuppressPropertyChangedWarnings]
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (SelectedIndex >= 0 && SelectedIndex < dictionaryEnum.Count)
            {
                Value = (Enum)Convert.ChangeType(dictionaryEnum.Values.ElementAt(SelectedIndex), enumType);
            }
        }
    }
}
