using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class NormalButton : Grid
    {
        private Button BackgroundButton, RealButton;
        private Label ValueLabel;


        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(NormalButton), null, propertyChanged: TextChanged);

        private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is NormalButton button)
            {
                button.ValueLabel.Text = (string)newValue;
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(NormalButton), 0.0, propertyChanged: FontSizeChanged);

        private static void FontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NormalButton button)
            {
                button.ValueLabel.FontSize = (double)newValue;
            }
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(NormalButton), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(NormalButton), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public event EventHandler Clicked;

        public NormalButton()
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
                TextColor = Color.White,
                FontSize = (double)Application.Current.Resources["CaptionFontSizeKey"] * 10 / 9,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                InputTransparent = true,
                Margin = new Thickness(3, 4),
            };
            Children.Add(ValueLabel);

            RealButton = new Button
            {
                BorderColor = Color.Transparent,
                BackgroundColor = Color.Transparent,
                HeightRequest = 0,
                WidthRequest = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            Children.Add(RealButton);
            RealButton.Pressed += _Pressed;

            Margin = new Thickness(2);
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Center;

            Scale = 0.9;

            PropertyChanged += Button_PropertyChanged;
        }

        public bool Lockable { get; set; } = true;

        private async  void _Pressed(object sender, EventArgs e)
        {
            if (Lockable)
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
            }

            Scale = 1.0;

            if (IsSet(CommandProperty))
            {
                Command.Execute(CommandParameter);
            }

            Clicked?.Invoke(this, new EventArgs());

            await this.ScaleTo(0.9, 500, Easing.SpringIn);
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
                    ValueLabel.TextColor = Color.Silver;
                }
                RealButton.IsEnabled = IsEnabled;
            }
        }
    }
}
