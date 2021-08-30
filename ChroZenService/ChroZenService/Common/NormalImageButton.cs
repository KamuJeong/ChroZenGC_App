using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class NormalImageButton : ImageButton
    {
        public static readonly new BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(NormalImageButton), null);
        public static readonly new BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(NormalImageButton), null);

        public new ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public new object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public new event EventHandler Clicked;

        public NormalImageButton()
        {
            BackgroundColor = Color.Transparent;
            Aspect = Aspect.AspectFit;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;
            Margin = new Thickness(2);
            HeightRequest = (double)Application.Current.Resources["CaptionFontSizeKey"] * 1.7 + 4;

            Scale = 0.9;

            Pressed += _Pressed;
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            var size = base.OnMeasure(widthConstraint, heightConstraint);
            if(!IsSet(WidthRequestProperty))
                WidthRequest = heightConstraint * size.Request.Width / size.Request.Height;
            return size;
        }

        public bool Lockable { get; set; } = true;

        private async void _Pressed(object sender, EventArgs e)
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

            await this.ScaleTo(0.9, 250, Easing.SpringIn); ;

            if (IsSet(CommandProperty))
            {
                Command.Execute(CommandParameter);
            }

            Clicked?.Invoke(sender, e);
        }
    }
}
