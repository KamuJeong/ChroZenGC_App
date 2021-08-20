using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_System_Diagnostics : ContentView
    {
        public View_System_Diagnostics()
        {
            InitializeComponent();
        }

        public void GoHome()
        {
            Go(0);
        }

        private void DiagSelected(object sender, EventArgs e)
        {
            if(sender is NormalButton button)
            {
                if(button == diag1)
                {
                    Go(1);
                }
                else if(button == diag2)
                {
                    Go(2);
                }
                else if(button == diag3)
                {
                    Go(3);
                }
                else if (button == diag4)
                {
                    Go(4);
                }
                else if (button == diag5)
                {
                    Go(5);
                }
                else if (button == diag6)
                {
                    Go(6);
                }
            }
        }

        private async void Go(int diag)
        {
            if(BindingContext is ViewModel_System model)
            {
                if(model.State.Mode == Modes.Diagnostics)
                {
                    await model.Model.Send(new DiagCommandWrapper(false, DiagTarget.Heater));
                }

                for(int i=0; i<mainGrid.RowDefinitions.Count; ++i)
                {
                    mainGrid.RowDefinitions[i].Height = i == diag ? GridLength.Star : new GridLength(0);
                }

                foreach(var c in mainGrid.Children)
                {
                    c.IsVisible = (int)c.GetValue(Grid.RowProperty) == diag;
                }
            }
        }
    }
}