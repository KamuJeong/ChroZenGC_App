using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class SwitchImageButton : ImageButton
    {
        public SwitchImageButton()
        {
            Source = SourceOFF;

            BackgroundColor = Color.Transparent;
            Aspect = Aspect.AspectFit;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;
            Margin = new Thickness(2);
            HeightRequest = (double)Application.Current.Resources["CaptionFontSizeKey"] * 1.5 + 4;
            WidthRequest = HeightRequest * 190.0 / 40.0;

            //var trigger = new Trigger(typeof(SwitchImageButton));
            //trigger.Property = ImageButton.IsEnabledProperty;
            //trigger.Value = false;
            //trigger.Setters.Add(new Setter { Property = ImageButton.SourceProperty, Value = Disable });
            //Triggers.Add(trigger);

            Pressed += OnPressed;
        }

        private void OnPressed(object sender, EventArgs e)
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

        public static readonly BindableProperty ONProperty = BindableProperty.Create("ON", typeof(bool), typeof(SwitchImageButton), false, propertyChanged: OnSwitched, defaultBindingMode: BindingMode.TwoWay);

        private static void OnSwitched(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is SwitchImageButton button)
            {
                button.Source = (bool)newValue ? SourceON : SourceOFF;
            }
        }

        public bool ON
        {
            get => (bool)GetValue(ONProperty);
            set => SetValue(ONProperty, value);
        }

        static private ImageSource SourceON { get; } = ImageSource.FromResource("ChroZenService.Images.btn_on.png");

        static private ImageSource SourceOFF { get; } = ImageSource.FromResource("ChroZenService.Images.btn_off.png");

        static private ImageSource Disable { get; } = ImageSource.FromResource("ChroZenService.Images.DisabledSwitch.png");
    }
}
