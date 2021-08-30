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
    public partial class View_System_Calibration : ContentView
    {
        public View_System_Calibration()
        {
            InitializeComponent();
        }

        private void CalibSelected(object sender, EventArgs e)
        {
            if (sender is NormalButton button)
            {
                if (button == calib1)
                {
                    Go(1);
                }
                else if (button == calib2)
                {
                    Go(2);
                }
                else if (button == calib3)
                {
                    Go(3);
                }
                else if (button == calib4)
                {
                    Go(4);
                }
                else if (button == calib5)
                {
                    Go(5);
                }
                else if (button == calib6)
                {
                    Go(6);
                }
                else if (button == calib7)
                {
                    Go(7);
                }
                else if (button == calib8)
                {
                    Go(8);
                }
                else if (button == calib9)
                {
                    Go(9);
                }
                else if (button == calib10)
                {
                    Go(10);
                }
                else if (button == calib11)
                {
                    Go(11);
                }
            }
        }

        public void GoHome()
        {
            Go(0);
        }

        private async void Go(int calib)
        {
            if (BindingContext is ViewModel_System_Calibration model)
            {
                if (model.State.Mode == Modes.Calibration)
                {
                    await model.Model.Send(new CommandWrapper(CommandCodes.Stop));
                }

                for (int i = 0; i < mainGrid.RowDefinitions.Count; ++i)
                {
                    mainGrid.RowDefinitions[i].Height = i == calib ? GridLength.Star : new GridLength(0);
                }

                foreach (var c in mainGrid.Children)
                {
                    c.IsVisible = (int)c.GetValue(Grid.RowProperty) == calib;
                }
            }
        }
    }
}