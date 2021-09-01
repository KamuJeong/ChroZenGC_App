using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_System_Calibration : Observable
    {
        public Model Model { get; }

        public ConfigurationWrapper Configuration => Model.Configuration;

        public StateWrapper State => Model.State;

        public CalibStateWrapper CalibState => Model.CalibState;

        public CalibOvenWrapper Oven { get; } = new CalibOvenWrapper();

        public CalibInletWrapper FrontInlet { get; } = new CalibInletWrapper();
        public CalibInletWrapper CenterInlet { get; } = new CalibInletWrapper();
        public CalibInletWrapper RearInlet { get; } = new CalibInletWrapper();


        public ViewModel_System_Calibration(Model model)
        {
            Model = model;

            State.PropertyModified += StatePropertyModified;
            CalibState.PropertyModified += CalibStatePropertyModeified;
        }

        private void CalibStatePropertyModeified(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Binary")
            {
                OnPropertyChanged(nameof(CalibState));
            }
        }

        private void StatePropertyModified(object sender, PropertyChangedEventArgs e)
        {
            IsEditable = State.Mode switch { Modes.Ready => true, Modes.NotReady => true, Modes.NotConnected => true, Modes.Calibration => true, _ => false };
            if (State.Mode == Modes.Calibration)
            {
                CurrentFunction = _LastCalibStartFunction;
            }
            else
            {
                CurrentFunction = CalibFunctions.None;
            }
        }

        public bool IsEditable { get; set; } = true;

        private CalibFunctions _LastCalibStartFunction = CalibFunctions.None;

        public CalibFunctions CurrentFunction { get; set; }

        private async void SendCommand(CalibActions action, CalibFunctions func, CalibTargets target)
        {
            await Model.Send(new CalibCommandWrapper(CommandCodes.Calibration, action, func, target));
            if (action == CalibActions.Start)
            {
                _LastCalibStartFunction = func;
            }
        }


        public ICommand ResetTempCommand => new Command(ResetTemp);

        private void ResetTemp(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 1:
                    Oven.Set.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Oven);
                    break;
                case 2:
                    FrontInlet.Temp.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Inlet1);
                    break;
                case 3:
                    CenterInlet.Temp.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Inlet2);
                    break;
                case 4:
                    RearInlet.Temp.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Inlet3);
                    break;
            }
        }

        public ICommand ApplyTempCommand => new Command(ApplyTemp);

        private async void ApplyTemp(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 1:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Oven);
                    await Model.Send(Oven);
                    break;
                case 2:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Inlet1);
                    FrontInlet.Type = CalibrationTypes.Temp;
                    await Model.Send(FrontInlet);
                    break;
                case 3:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Inlet2);
                    CenterInlet.Type = CalibrationTypes.Temp;
                    await Model.Send(CenterInlet);
                    break;
                case 4:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Inlet3);
                    RearInlet.Type = CalibrationTypes.Temp;
                    await Model.Send(RearInlet);
                    break;
            }
        }

        public ICommand StartSensorZeroCommand => new Command(StartSensorZero);

        private void StartSensorZero(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 2:
                    SendCommand(CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Inlet3);
                    break;
            }
        }

        public ICommand StopSensorZeroCommand => new Command(StopSensorZero);

        private void StopSensorZero(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 2:
                    SendCommand(CalibActions.Stop, CalibFunctions.SensZero, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(CalibActions.Stop, CalibFunctions.SensZero, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(CalibActions.Stop, CalibFunctions.SensZero, CalibTargets.Inlet3);
                    break;
            }

        }

        public ICommand ResetSensorZeroCommand => new Command(ResetSensorZero);

        private void ResetSensorZero(object obj)
        {
            if (CurrentFunction == CalibFunctions.SensZero)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.Inlet1);
                        break;
                    case 3:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.Inlet2);
                        break;
                    case 4:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.Inlet3);
                        break;
                }

        }

        public ICommand ApplySensorZeroCommand => new Command(ApplySensorZero);

        private void ApplySensorZero(object obj)
        {
            if (CurrentFunction == CalibFunctions.SensZero)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.Inlet1);
                        break;
                    case 3:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.Inlet2);
                        break;
                    case 4:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.Inlet3);
                        break;
                }
        }


        public ICommand StartValveCommand => new Command(StartValve);

        private void StartValve(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 2:
                    SendCommand(CalibActions.Start, CalibFunctions.Valve, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(CalibActions.Start, CalibFunctions.Valve, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(CalibActions.Start, CalibFunctions.Valve, CalibTargets.Inlet3);
                    break;
            }
        }

        public ICommand StopValveCommand => new Command(StopValve);

        private void StopValve(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 2:
                    SendCommand(CalibActions.Stop, CalibFunctions.Valve, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(CalibActions.Stop, CalibFunctions.Valve, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(CalibActions.Stop, CalibFunctions.Valve, CalibTargets.Inlet3);
                    break;
            }

        }

        public ICommand ResetValveCommand => new Command(ResetValve);

        private void ResetValve(object obj)
        {
            if (CurrentFunction == CalibFunctions.Valve)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.Inlet1);
                        break;
                    case 3:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.Inlet2);
                        break;
                    case 4:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.Inlet3);
                        break;
                }

        }

        public ICommand ApplyValveCommand => new Command(ApplyValve);

        private void ApplyValve(object obj)
        {
            if (CurrentFunction == CalibFunctions.Valve)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.Inlet1);
                        break;
                    case 3:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.Inlet2);
                        break;
                    case 4:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.Inlet3);
                        break;
                }
        }

        public ICommand StartFlowCommand => new Command(StartFlow);

        private async void StartFlow(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 2:
                    SendCommand(CalibActions.Start, CalibFunctions.Flow, CalibTargets.Inlet1);
                    FrontInlet.Type = CalibrationTypes.Flow;
                    await Model.Send(FrontInlet);
                    break;
                case 3:
                    SendCommand(CalibActions.Start, CalibFunctions.Flow, CalibTargets.Inlet2);
                    CenterInlet.Type = CalibrationTypes.Flow;
                    await Model.Send(CenterInlet);
                    break;
                case 4:
                    SendCommand(CalibActions.Start, CalibFunctions.Flow, CalibTargets.Inlet3);
                    RearInlet.Type = CalibrationTypes.Flow;
                    await Model.Send(RearInlet);
                    break;
            }
        }

        public ICommand StopFlowCommand => new Command(StopFlow);

        private void StopFlow(object obj)
        {
            switch (int.Parse((string)obj))
            {
                case 2:
                    SendCommand(CalibActions.Stop, CalibFunctions.Flow, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(CalibActions.Stop, CalibFunctions.Flow, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(CalibActions.Stop, CalibFunctions.Flow, CalibTargets.Inlet3);
                    break;
            }

        }

        public ICommand ResetFlowCommand => new Command(ResetFlow);

        private async void ResetFlow(object obj)
        {
            if (CurrentFunction == CalibFunctions.Flow)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.Inlet1);
                        FrontInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(FrontInlet);
                        break;
                    case 3:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.Inlet2);
                        CenterInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(CenterInlet);
                        break;
                    case 4:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.Inlet3);
                        RearInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(RearInlet);
                        break;
                }

        }

        public ICommand ApplyFlowCommand => new Command(ApplyFlow);

        private async void ApplyFlow(object obj)
        {
            if (CurrentFunction == CalibFunctions.Flow)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.Inlet1);
                        FrontInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(FrontInlet);
                        break;
                    case 3:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.Inlet2);
                        CenterInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(CenterInlet);
                        break;
                    case 4:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.Inlet3);
                        RearInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(RearInlet);
                        break;
                }
        }

        public ICommand Flow1Command => new Command(Flow1Set);

        private async void Flow1Set(object obj)
        {
            if (CurrentFunction == CalibFunctions.Flow)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        FrontInlet.Type = CalibrationTypes.Flow;
                        FrontInlet.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(FrontInlet);
                        break;
                    case 3:
                        CenterInlet.Type = CalibrationTypes.Flow;
                        CenterInlet.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(CenterInlet);
                        break;
                    case 4:
                        RearInlet.Type = CalibrationTypes.Flow;
                        RearInlet.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(RearInlet);
                        break;
                }
        }

        public ICommand Flow2Command => new Command(Flow2Set);

        private async void Flow2Set(object obj)
        {
            if (CurrentFunction == CalibFunctions.Flow)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        FrontInlet.Type = CalibrationTypes.Flow;
                        FrontInlet.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(FrontInlet);
                        break;
                    case 3:
                        CenterInlet.Type = CalibrationTypes.Flow;
                        CenterInlet.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(CenterInlet);
                        break;
                    case 4:
                        RearInlet.Type = CalibrationTypes.Flow;
                        RearInlet.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(RearInlet);
                        break;
                }
        }

        public ICommand Flow3Command => new Command(Flow3Set);

        private async void Flow3Set(object obj)
        {
            if (CurrentFunction == CalibFunctions.Flow)
                switch (int.Parse((string)obj))
                {
                    case 2:
                        FrontInlet.Type = CalibrationTypes.Flow;
                        FrontInlet.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(FrontInlet);
                        break;
                    case 3:
                        CenterInlet.Type = CalibrationTypes.Flow;
                        CenterInlet.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(CenterInlet);
                        break;
                    case 4:
                        RearInlet.Type = CalibrationTypes.Flow;
                        RearInlet.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(RearInlet);
                        break;
                }
        }

    }
}
