using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ImageButtonBehavior : Behavior<ImageButton>
    {
        protected override void OnAttachedTo(ImageButton button)
        {
            button.Pressed += OnButtonPressed;
            button.Released += OnButtonReleased;
            base.OnAttachedTo(button);
        }

        private async void OnButtonPressed(object sender, EventArgs e)
        {
            if (sender is ImageButton button)
            {
                if (button.GetValue(SourceReservedProperty) is null)
                {
                    button.SetValue(SourceReservedProperty, button.Source);
                }
                if (button.GetValue(SourcePressedProperty) is not null)
                {
                    button.Source = GetSourcePressed(button);
                }
                await button.ScaleTo(1.2, 50, Easing.SpringOut);
            }
        }

        private async void OnButtonReleased(object sender, EventArgs e)
        {
            if (sender is ImageButton button)
            {
                await button.ScaleTo(1, 500, Easing.SpringIn);

                button.Source = (ImageSource)button.GetValue(SourceReservedProperty);
            }
        }

        protected override void OnDetachingFrom(ImageButton button)
        {
            button.Pressed += OnButtonPressed;
            base.OnDetachingFrom(button);
        }

        public static readonly BindableProperty UseProperty =
            BindableProperty.CreateAttached("Use", typeof(bool), typeof(ImageButtonBehavior), false, propertyChanged: OnUsePropertyChanged);

        public static bool GetUse(BindableObject view)
        {
            return (bool)view.GetValue(UseProperty);
        }

        public static void SetUse(BindableObject view, bool value)
        {
            view.SetValue(UseProperty, value);
        }

        [SuppressPropertyChangedWarnings]
        private static void OnUsePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ImageButton button)
            {
                if ((bool)newValue)
                {
                    button.Behaviors.Add(new ImageButtonBehavior());
                }
                else
                {
                    var toRemove = button.Behaviors.FirstOrDefault(b => b is ImageButtonBehavior);
                    if (toRemove != null)
                    {
                        button.Behaviors.Remove(toRemove);
                    }

                }
            }
        }

        public static readonly BindableProperty SourcePressedProperty =
            BindableProperty.CreateAttached("SourcePressed", typeof(ImageSource), typeof(ImageButtonBehavior), null);

        public static ImageSource GetSourcePressed(BindableObject view)
        {
            return (ImageSource)view.GetValue(SourcePressedProperty);
        }

        public static void SetSourcePressed(BindableObject view, ImageSource value)
        {
            view.SetValue(SourcePressedProperty, value);
        }

        private static readonly BindableProperty SourceReservedProperty =
            BindableProperty.CreateAttached("SourceReservePressed", typeof(ImageSource), typeof(ImageButtonBehavior), null);

    }
}
