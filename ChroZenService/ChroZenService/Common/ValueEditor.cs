using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public static class BindingObjectExtensions
    {
        private static MethodInfo _bindablePropertyGetContextMethodInfo = typeof(BindableObject).GetMethod("GetContext", BindingFlags.NonPublic | BindingFlags.Instance);
        private static FieldInfo _bindablePropertyContextBindingFieldInfo;

        public static Binding GetBinding(this BindableObject bindableObject, BindableProperty bindableProperty)
        {
            object bindablePropertyContext = _bindablePropertyGetContextMethodInfo.Invoke(bindableObject, new[] { bindableProperty });

            if (bindablePropertyContext != null)
            {
                FieldInfo propertyInfo = _bindablePropertyContextBindingFieldInfo =
                    _bindablePropertyContextBindingFieldInfo ??
                        bindablePropertyContext.GetType().GetField("Binding");

                return (Binding)propertyInfo.GetValue(bindablePropertyContext);
            }

            return null;
        }
    }


    public class ValueEditor : Grid
    {
        public static readonly BindableProperty UnitWidthProperty = BindableProperty.Create("UnitWidth", typeof(GridLength), typeof(ValueEditor), new GridLength(0));

        public GridLength UnitWidth
        {
            get => (GridLength)GetValue(UnitWidthProperty);
            set => SetValue(UnitWidthProperty, value);
        }

        public static readonly BindableProperty SwitchProperty = BindableProperty.Create("Switch", typeof(bool), typeof(ValueEditor), null, defaultBindingMode: BindingMode.TwoWay);
        public bool Switch
        {
            get => (bool)GetValue(SwitchProperty);
            set => SetValue(SwitchProperty, value);
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(object), typeof(ValueEditor), null, defaultBindingMode: BindingMode.TwoWay);
        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        public Label ValueLabel { get; set; }

        public Label UnitLabel { get; set; }

        public ValueEditor()
        {
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = new GridLength(0) }
            };

            var background = new Button
            {
                BorderColor = Color.Silver,
                BorderWidth = 0.5,
                CornerRadius = 5,
                Background = (Brush)Application.Current.Resources["ValueEditorBackgroundKey"],
                //HeightRequest = 10,
                //WidthRequest = 10,
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.FillAndExpand
            };
            Children.Add(background);
            SetColumnSpan(background, 2);
            background.Clicked += OnClicked;

            ValueLabel = new Label
            {
                TextColor = Color.Silver,
                FontSize = (double)Application.Current.Resources["DefaultFontSizeKey"],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                InputTransparent = true,
            };
            Children.Add(ValueLabel);

            UnitLabel = new Label
            {
                TextColor = Color.Silver,
                FontSize = (double)Application.Current.Resources["DefaultFontSizeKey"],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.End,
                InputTransparent = true,
            };
            Children.Add(UnitLabel);
            SetColumn(UnitLabel, 1);
        }

        private void OnClicked(object sender, EventArgs e)
        {


            double  value = Value != null ? (double)Convert.ChangeType(Value, typeof(double)) : 0.0;

            if( this.GetBinding(SwitchProperty) != null)
            {

            }
            


        }
    }
}
