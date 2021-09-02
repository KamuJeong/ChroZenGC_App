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
    public class SensorZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is CalibStateWrapper state)
            {
                int param = int.Parse((string)parameter);

                switch ((CalibTargets)(param / 10))
                {
                    case CalibTargets.Inlet1:
                        return state.InletSensorZeroState[0] == SensorZeroValveStates.Error && state.InletValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.InletSensorZeroState[0]}";
                    case CalibTargets.Inlet2:
                        return state.InletSensorZeroState[1] == SensorZeroValveStates.Error && state.InletValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.InletSensorZeroState[1]}";
                    case CalibTargets.Inlet3:
                        return state.InletSensorZeroState[2] == SensorZeroValveStates.Error && state.InletValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.InletSensorZeroState[2]}";

                    case CalibTargets.Det1:
                        return state.DetectorSensorZeroState[0] == SensorZeroValveStates.Error && state.DetectorValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.DetectorSensorZeroState[0]}";
                    case CalibTargets.Det2:
                        return state.DetectorSensorZeroState[1] == SensorZeroValveStates.Error && state.DetectorValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.DetectorSensorZeroState[1]}";
                    case CalibTargets.Det3:
                        return state.DetectorSensorZeroState[2] == SensorZeroValveStates.Error && state.DetectorValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.DetectorSensorZeroState[2]}";

                    case CalibTargets.AuxUPC1:
                        return state.AuxSensorZeroState[0] == SensorZeroValveStates.Error && state.AuxValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.AuxSensorZeroState[0]}";
                    case CalibTargets.AuxUPC2:
                        return state.AuxSensorZeroState[1] == SensorZeroValveStates.Error && state.AuxValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.AuxSensorZeroState[1]}";
                    case CalibTargets.AuxUPC3:
                        return state.AuxSensorZeroState[2] == SensorZeroValveStates.Error && state.AuxValveError[param % 10] == 0
                            ? $"{SensorZeroValveStates.Pass}"
                            : $"{state.AuxSensorZeroState[2]}";
                }
            }
            return $"{SensorZeroValveStates.Stop}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValveCalibConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ToString(SensorZeroValveStates state, ValveCalibErrors error)
            {
                if (state == SensorZeroValveStates.Error)
                {
                    switch (error)
                    {
                        case ValveCalibErrors.VoltageHigh: return "VH Fail";
                        case ValveCalibErrors.TimeOver: return "TO Fail";
                        case ValveCalibErrors.Valve16V: return "16V Fail";
                    }
                    return "Fail";
                }
                else
                {
                    return $"{state}";
                }
            }

            if (value is CalibStateWrapper state)
            {
                int param = int.Parse((string)parameter);

                switch ((CalibTargets)(param / 10))
                {
                    case CalibTargets.Inlet1: return ToString(state.InletValveState[0], state.InletValveError[param % 10]);
                    case CalibTargets.Inlet2: return ToString(state.InletValveState[1], state.InletValveError[param % 10]);
                    case CalibTargets.Inlet3: return ToString(state.InletValveState[2], state.InletValveError[param % 10]);

                    case CalibTargets.Det1: return ToString(state.DetectorValveState[0], state.DetectorValveError[param % 10]);
                    case CalibTargets.Det2: return ToString(state.DetectorValveState[1], state.DetectorValveError[param % 10]);
                    case CalibTargets.Det3: return ToString(state.DetectorValveState[2], state.DetectorValveError[param % 10]);

                    case CalibTargets.AuxUPC1: return ToString(state.AuxValveState[0], state.AuxValveError[param % 10]);
                    case CalibTargets.AuxUPC2: return ToString(state.AuxValveState[1], state.AuxValveError[param % 10]);
                    case CalibTargets.AuxUPC3: return ToString(state.AuxValveState[2], state.AuxValveError[param % 10]);
                }
            }
            return $"{SensorZeroValveStates.Stop}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SplitFlowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ArrayWrapper<float> flow)
            {
                return flow[0] - flow[1] - flow[2];
            }
            return 0.0f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

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

                foreach (var c in mainGrid.Children)
                {
                    c.IsVisible = (int)c.GetValue(Grid.RowProperty) == calib;
                }

                for (int i = 0; i < mainGrid.RowDefinitions.Count; ++i)
                {
                    mainGrid.RowDefinitions[i].Height = i == calib ? GridLength.Star : new GridLength(0);
                }
            }
        }
    }
}