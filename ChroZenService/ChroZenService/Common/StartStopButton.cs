using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChroZenService
{
    public class StartStopButton : NormalImageButton
    {
        public static readonly BindableProperty IsStartedProperty = BindableProperty.Create("IsStarted", typeof(bool), typeof(StartStopButton), false, propertyChanged: IsStartedChanged);

        private static void IsStartedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is StartStopButton button)
            {
                button.Source = (bool)newValue ? SourceStop : SourceStart;
            }
        }

        public bool IsStarted
        {
            get => (bool)GetValue(IsStartedProperty);
            set => SetValue(IsStartedProperty, value);
        }

        public StartStopButton()
        {
            Source = SourceStart;
        }

        protected override async Task<bool> OnPressed(object sender, EventArgs e)
        {
            if (!IsStarted && Lockable)
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
                            return false;
                    }
                    if (element.Parent == null)
                        break;
                    else
                        element = element.Parent;
                }
            }

            Scale = 1.0;

            await this.ScaleTo(0.9, 250, Easing.SpringIn);

            if (IsSet(CommandProperty))
            {
                Command.Execute((CommandParameter, IsStarted));
            }

            return true;
        }

        static private ImageSource SourceStart { get; } = ImageSource.FromResource("ChroZenService.Images.start.png");
        static private ImageSource SourceStop { get; } = ImageSource.FromResource("ChroZenService.Images.calib_stop.jpg");
    }
}
