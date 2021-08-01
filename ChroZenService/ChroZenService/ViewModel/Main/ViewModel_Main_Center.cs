using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService.ViewModel.Main
{
    public class ContentHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => int.Parse((string)parameter) == (int)value || ((int)value == -1 && int.Parse((string)parameter) == 2) ? new GridLength(58, GridUnitType.Star) : new GridLength(0);

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewModel_Main_Center : Observable
    {
        private Model model;

        private ConfigurationWrapper Configuration => model.Configuration;

        private StateWrapper State => model.State;

        public ViewModel_Main_Center()
        {
            model = Resolver.Resolve<Model>();

            try
            {
                ActiveInlet = Enumerable.Range(0, 3).First(i => Configuration.InletType[i] != InletTypes.None);
            }
            catch
            {
                ActiveInlet = -1;
            }

            try
            {
                ActiveDetector = Enumerable.Range(0, 3).First(i => Configuration.InletType[i] != InletTypes.None);
            }
            catch
            {
                ActiveDetector = -1;
            }
        }



        private int activeInlet = -1;
        [DoNotNotify]
        public int ActiveInlet 
        {
            get => activeInlet;
            set
            {
                if(activeInlet != value)
                {
                    activeInlet = value;

                    LeftGridRow = 2 * (activeInlet + 1);
                    InletType = Configuration.InletType[activeInlet];

                    OnPropertyChanged();
                }
            }
        }

        public int LeftGridRow { get; set; }
        public InletTypes InletType { get; set; }


        public ICommand Inlet => new Command<string>(execute: InletSelect, canExecute: CanInlet);

        private bool CanInlet(string row) => Configuration.InletType[int.Parse(row)] != InletTypes.None;

        private void InletSelect(string row)
        {
            ActiveInlet = int.Parse(row);
        }












        private int activeDetector = -1;
        [DoNotNotify]
        public int ActiveDetector 
        { 
            get => activeDetector;
            set
            {
                if (activeDetector != value)
                {
                    activeDetector = value;
                    RightGridRow = 2 * (activeDetector + 1);

                    OnPropertyChanged();
                }
            }
        }

        public int RightGridRow { get; set; }




        public ICommand Detector => new Command<string>(execute: DetectorSelect, canExecute: CanDetector);

        private bool CanDetector(string row) => Configuration.DetectorType[int.Parse(row)] != DetectorTypes.None;

        private void DetectorSelect(string row)
        {
            ActiveDetector = int.Parse(row);
        }





        public int Height => (int)(566 * 0.9 * App.ScreenWidth / 695);
        public ICommand SwipeUp => new Command((arg) =>
        {
            for (int i = 0; i < 3; ++i)
            {
                if ("Left".Equals(arg))
                {
                    if (i > ActiveInlet && Configuration.InletType[i] != InletTypes.None)
                    {
                        ActiveInlet = i;
                        break;
                    }
                }
                else if ("Right".Equals(arg))
                {
                    if (i > ActiveDetector && Configuration.DetectorType[i] != DetectorTypes.None)
                    {
                        ActiveDetector = i;
                        break;
                    }
                }
            }
        });
        public ICommand SwipeDown => new Command((arg) =>
        {
            for (int i = 3; i >= 0; --i)
            {
                if ("Left".Equals(arg))
                {
                    if (i < ActiveInlet && Configuration.InletType[i] != InletTypes.None)
                    {
                        ActiveInlet = i;
                        break;
                    }
                }
                else if ("Right".Equals(arg))
                {
                    if (i < ActiveDetector && Configuration.DetectorType[i] != DetectorTypes.None)
                    {
                        ActiveDetector = i;
                        break;
                    }
                }
            }
        });
    }
}
