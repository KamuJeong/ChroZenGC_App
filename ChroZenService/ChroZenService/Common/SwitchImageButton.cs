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

            Clicked += OnClicked;
        }
        private void OnClicked(object sender, EventArgs e)
        {
            ON = !ON;
        }

        public static readonly BindableProperty ONProperty = BindableProperty.Create("ON", typeof(bool), typeof(SwitchImageButton), false, propertyChanged: OnSwitched, defaultBindingMode: BindingMode.TwoWay);
        
        private static void OnSwitched(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is SwitchImageButton button)
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
    }
}
