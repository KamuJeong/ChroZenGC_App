using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class SwitchButton : Grid
    {
        private Button BackgroundButton;
        private Label ValueLabel;


        public SwitchButton()
        {
            ColumnSpacing = 0;
            RowSpacing = 0;

            BackgroundButton = new Button
            {
                BorderColor = Color.Silver,
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

            ValueLabel = new Label
            {
                Text = "OFF",
                TextColor = Color.White,
                FontSize = (double)Application.Current.Resources["CaptionFontSizeKey"],
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,              
                InputTransparent = true,
                Margin = new Thickness(3, 4),
            };
            Children.Add(ValueLabel);

            Margin = new Thickness(2);
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Center;

            var recognizer = new TapGestureRecognizer();
            recognizer.Command = new Command(OnClicked);

            PropertyChanged += Button_PropertyChanged;

            this.GestureRecognizers.Add(recognizer);
        }

        private void OnClicked(object obj)
        {
            Element element = this;
            while (element.BindingContext != null)
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

            ON = !ON;
        }

        private void Button_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsEnabled")
            {
                if (IsEnabled)
                {
                    BackgroundButton.Background = (Brush)Application.Current.Resources["ValueEditorBackgroundKey"];
                    BackgroundButton.ClearValue(Button.BackgroundColorProperty);
                    ValueLabel.TextColor = Color.White;
                }
                else
                {
                    BackgroundButton.BackgroundColor = Color.Transparent;
                    BackgroundButton.ClearValue(Button.BackgroundProperty);
                    ValueLabel.TextColor = Color.Transparent;
                }
            }
        }

        public static readonly BindableProperty ONProperty = BindableProperty.Create("ON", typeof(bool), typeof(SwitchImageButton), false, propertyChanged: OnSwitched, defaultBindingMode: BindingMode.TwoWay);

        private static void OnSwitched(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is SwitchButton button)
            {
                button.ValueLabel.Text = (bool)newValue ? "ON" : "OFF";
            }
        }

        public bool ON
        {
            get => (bool)GetValue(ONProperty);
            set => SetValue(ONProperty, value);
        }
    }
}
