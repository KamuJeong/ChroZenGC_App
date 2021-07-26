using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
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
            => int.Parse((string)parameter) == (int)value ? new GridLength(70.9, GridUnitType.Star) : new GridLength(0);

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewModel_Main_Center : Observable
    {
        private Model model;

        public ConfigurationWrapper Configuration => model.Configuration;

        public StateWrapper State => model.State;

        public ViewModel_Main_Center()
        {
            model = Resolver.Resolve<Model>();

            ActiveInlet = Enumerable.Range(0, 3).FirstOrDefault(i => Configuration.InletType[i] != InletTypes.None);
            ActiveDetector = Enumerable.Range(0, 3).FirstOrDefault(i => Configuration.InletType[i] != InletTypes.None);
        }

        public int ActiveInlet { get; set; }

        public ICommand Inlet => new Command<string>(execute: InletSelect, canExecute: CanInlet);

        private bool CanInlet(string row) => Configuration.InletType[int.Parse(row)] != InletTypes.None;

        private void InletSelect(string row)
        {
            ActiveInlet = int.Parse(row);
        }

        public int ActiveDetector { get; set; }

        public ICommand Detector => new Command<string>(execute: DetectorSelect, canExecute: CanDetector);

        private bool CanDetector(string row) => Configuration.DetectorType[int.Parse(row)] != DetectorTypes.None;

        private void DetectorSelect(string row)
        {
            ActiveDetector = int.Parse(row);
        }

    }
}
