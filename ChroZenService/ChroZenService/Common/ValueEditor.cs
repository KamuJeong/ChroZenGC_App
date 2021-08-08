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

        public static object GetBinding(this BindableObject bindableObject, BindableProperty bindableProperty)
        {
            object bindablePropertyContext = _bindablePropertyGetContextMethodInfo.Invoke(bindableObject, new[] { bindableProperty });

            if (bindablePropertyContext != null)
            {
                FieldInfo propertyInfo = _bindablePropertyContextBindingFieldInfo =
                    _bindablePropertyContextBindingFieldInfo ??
                        bindablePropertyContext.GetType().GetField("Binding");

                return propertyInfo.GetValue(bindablePropertyContext);
            }

            return null;
        }
    }


    public class ValueEditor : Grid
    {
        public static readonly BindableProperty CaptionProperty = BindableProperty.Create("Caption", typeof(string), typeof(ValueEditor), null);
        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }


        public static readonly BindableProperty MaxProperty = BindableProperty.Create("Max", typeof(double), typeof(ValueEditor), double.PositiveInfinity);
        public double Max
        {
            get => (double)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        public static readonly BindableProperty MinProperty = BindableProperty.Create("Min", typeof(double), typeof(ValueEditor), double.NegativeInfinity);
        public double Min
        {
            get => (double)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }


        private void UpdateValue()
        {
            if (Switch)
            {
                ValueLabel.Text = Value;
                ValueLabel.HorizontalTextAlignment = TextAlignment.End;
            }
            else
            {
                ValueLabel.Text = "OFF";
                ValueLabel.HorizontalTextAlignment = TextAlignment.Center;
            }
        }

        public static readonly BindableProperty SwitchProperty = BindableProperty.Create("Switch", typeof(bool), typeof(ValueEditor), true, defaultBindingMode: BindingMode.TwoWay, propertyChanged: SwitchValueChanged);

        private static void SwitchValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ValueEditor edit)
            {
                edit.UpdateValue();
            }
        }

        public bool Switch
        {
            get => (bool)GetValue(SwitchProperty);
            set => SetValue(SwitchProperty, value);
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(string), typeof(ValueEditor), null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: SwitchValueChanged);


        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty UnitProperty = BindableProperty.Create("Unit", typeof(string), typeof(ValueEditor), null, propertyChanged: UnitChanged);

        private static void UnitChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ValueEditor edit)
            {
                //edit.UnitLabel.Margin = newValue == null ? new Thickness(3,0,3,0) : new Thickness(3, 2);
                edit.UnitLabel.Text = (string)newValue;
            }
        }

        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

        public static readonly BindableProperty UnitWidthProperty = BindableProperty.Create("UnitWidth", typeof(double), typeof(ValueEditor), 0.0, propertyChanged: UnitWidthChanged);

        private static void UnitWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ValueEditor edit)
            {
                edit.UnitLabel.WidthRequest = (double)newValue;
            }
        }

        public double UnitWidth
        {
            get => (double)GetValue(UnitWidthProperty);
            set => SetValue(UnitWidthProperty, value);
        }

        private Button BackgroundButton { get; }

        public Label ValueLabel { get; }

        public Label UnitLabel { get; }

        public ValueEditor()
        {
            ColumnSpacing = 0;
            RowSpacing = 0;

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            };

            BackgroundButton = new Button
            {
                BorderColor = Color.Silver,
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                BorderWidth = 0.5,
                CornerRadius = 5,
                Background = (Brush)Application.Current.Resources["ValueEditorBackgroundKey"],
                HeightRequest = 0,
                WidthRequest = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                InputTransparent = true,
            };
            Children.Add(BackgroundButton);
            SetColumnSpan(BackgroundButton, 2);

            ValueLabel = new Label
            {
                TextColor = Color.White,
                FontSize = (double)Application.Current.Resources["CaptionFontSizeKey"],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End,
                InputTransparent = true,
                Margin = new Thickness(3, 3),
            };
            Children.Add(ValueLabel);

            UnitLabel = new Label
            {
                TextColor = Color.Silver,
                FontSize = (double)Application.Current.Resources["DefaultFontSizeKey"],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
                HorizontalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(3, 2, 5, 2),
                InputTransparent = true,
            };
            Children.Add(UnitLabel);
            SetColumn(UnitLabel, 1);

            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Center;

            var recognizer = new TapGestureRecognizer();
            recognizer.Command = new Command(OnClicked);

            PropertyChanged += ValueEditor_PropertyChanged;

            this.GestureRecognizers.Add(recognizer);
        }

        private void ValueEditor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsEnabled")
            {
                if (IsEnabled)
                {
                    BackgroundButton.Background = (Brush)Application.Current.Resources["ValueEditorBackgroundKey"];
                    BackgroundButton.ClearValue(Button.BackgroundColorProperty);
                }
                else
                {
                    BackgroundButton.BackgroundColor = Color.Transparent;
                    BackgroundButton.ClearValue(Button.BackgroundProperty);
                }
            }
        }

        private void OnClicked()
        {
            Element element = this;
            while(element.BindingContext != null)
            {
                var prop = element.BindingContext.GetType().GetProperty("IsEditable");
                if (prop != null && prop.GetValue(element.BindingContext) is bool editable)
                {
                    if (editable)
                        break;
                    else
                        return;
                }
                if (element.Parent == null)
                    break;
                else
                    element = element.Parent;
            }

            Navigation.PushModalAsync(new KeyPad(this), false);
        }
    }
}
