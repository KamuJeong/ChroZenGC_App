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

        public CalibDetectorWrapper FrontDetector { get; } = new CalibDetectorWrapper();
        public CalibDetectorWrapper CenterDetector { get; } = new CalibDetectorWrapper();
        public CalibDetectorWrapper RearDetector { get; } = new CalibDetectorWrapper();

        public CalibAuxUPCWrapper AuxUPC1 { get; } = new CalibAuxUPCWrapper();
        public CalibAuxUPCWrapper AuxUPC2 { get; } = new CalibAuxUPCWrapper();
        public CalibAuxUPCWrapper AuxUPC3 { get; } = new CalibAuxUPCWrapper();

        public CalibAuxTempWrapper AuxTemp { get; } = new CalibAuxTempWrapper();

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
                if (CurrentFunction != CalibFunctions.None)
                {
                    CurrentFunction = CalibFunctions.None;
                    for (int i = 0; i < 3; ++i)
                    {
                        CalibState.InletSensorZeroState[i] = SensorZeroValveStates.Stop;
                        CalibState.InletValveState[i] = SensorZeroValveStates.Stop;
                        CalibState.DetectorSensorZeroState[i] = SensorZeroValveStates.Stop;
                        CalibState.DetectorValveState[i] = SensorZeroValveStates.Stop;
                        CalibState.AuxSensorZeroState[i] = SensorZeroValveStates.Stop;
                        CalibState.AuxValveState[i] = SensorZeroValveStates.Stop;
                    }

                    OnPropertyChanged(nameof(CalibState));
                }
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

                case 5:
                    FrontDetector.Temp.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Det1);
                    break;
                case 6:
                    CenterDetector.Temp.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Det2);
                    break;
                case 7:
                    RearDetector.Temp.Reset();
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Det3);
                    break;

                case 11:
                    AuxTemp.Aux1_Set1 = AuxTemp.Aux1_Measure1 = 52.1f;
                    AuxTemp.Aux1_Set2 = AuxTemp.Aux1_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux1);
                    break;
                case 12:
                    AuxTemp.Aux2_Set1 = AuxTemp.Aux2_Measure1 = 52.1f;
                    AuxTemp.Aux2_Set2 = AuxTemp.Aux2_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux2);
                    break;
                case 13:
                    AuxTemp.Aux3_Set1 = AuxTemp.Aux3_Measure1 = 52.1f;
                    AuxTemp.Aux3_Set2 = AuxTemp.Aux3_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux3);
                    break;
                case 14:
                    AuxTemp.Aux4_Set1 = AuxTemp.Aux4_Measure1 = 52.1f;
                    AuxTemp.Aux4_Set2 = AuxTemp.Aux4_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux4);
                    break;
                case 15:
                    AuxTemp.Aux5_Set1 = AuxTemp.Aux5_Measure1 = 52.1f;
                    AuxTemp.Aux5_Set2 = AuxTemp.Aux5_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux5);
                    break;
                case 16:
                    AuxTemp.Aux6_Set1 = AuxTemp.Aux6_Measure1 = 52.1f;
                    AuxTemp.Aux6_Set2 = AuxTemp.Aux6_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux6);
                    break;
                case 17:
                    AuxTemp.Aux7_Set1 = AuxTemp.Aux7_Measure1 = 52.1f;
                    AuxTemp.Aux7_Set2 = AuxTemp.Aux7_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux7);
                    break;
                case 18:
                    AuxTemp.Aux8_Set1 = AuxTemp.Aux8_Measure1 = 52.1f;
                    AuxTemp.Aux8_Set2 = AuxTemp.Aux8_Measure2 = 211.3f;
                    SendCommand(CalibActions.Reset, CalibFunctions.Temp, CalibTargets.Aux8);
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

                case 5:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Det1);
                    FrontDetector.Type = CalibrationTypes.Temp;
                    await Model.Send(FrontDetector);
                    break;
                case 6:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Det2);
                    CenterDetector.Type = CalibrationTypes.Temp;
                    await Model.Send(CenterDetector);
                    break;
                case 7:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Det3);
                    RearDetector.Type = CalibrationTypes.Temp;
                    await Model.Send(RearDetector);
                    break;

                case 11:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux1);
                    await Model.Send(AuxTemp);
                    break;
                case 12:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux2);
                    await Model.Send(AuxTemp);
                    break;
                case 13:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux3);
                    await Model.Send(AuxTemp);
                    break;
                case 14:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux4);
                    await Model.Send(AuxTemp);
                    break;
                case 15:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux5);
                    await Model.Send(AuxTemp);
                    break;
                case 16:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux6);
                    await Model.Send(AuxTemp);
                    break;
                case 17:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux7);
                    await Model.Send(AuxTemp);
                    break;
                case 18:
                    SendCommand(CalibActions.Apply, CalibFunctions.Temp, CalibTargets.Aux8);
                    await Model.Send(AuxTemp);
                    break;
            }
        }

        public ICommand StartStopSensorZeroCommand => new Command(StartStopSensorZero);

        private void StartStopSensorZero(object obj)
        {
            var (p, s) = (ValueTuple<object, bool>)obj;

            switch (int.Parse((string)p))
            {
                case 2:
                    SendCommand(s? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Inlet3);
                    break;

                case 5:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Det1);
                    break;
                case 6:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Det2);
                    break;
                case 7:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.Det3);
                    break;

                case 8:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.AuxUPC1);
                    break;
                case 9:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.AuxUPC2);
                    break;
                case 10:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.SensZero, CalibTargets.AuxUPC3);
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

                    case 5:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.Det1);
                        break;
                    case 6:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.Det2);
                        break;
                    case 7:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.Det3);
                        break;

                    case 8:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.AuxUPC1);
                        break;
                    case 9:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.AuxUPC2);
                        break;
                    case 10:
                        SendCommand(CalibActions.Reset, CalibFunctions.SensZero, CalibTargets.AuxUPC3);
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

                    case 5:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.Det1);
                        break;
                    case 6:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.Det2);
                        break;
                    case 7:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.Det3);
                        break;


                    case 8:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.AuxUPC1);
                        break;
                    case 9:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.AuxUPC2);
                        break;
                    case 10:
                        SendCommand(CalibActions.Apply, CalibFunctions.SensZero, CalibTargets.AuxUPC3);
                        break;
                }
        }

        public ICommand StartStopValveCommand => new Command(StartStopValve);

        private void StartStopValve(object obj)
        {
            var (p, s) = (ValueTuple<object, bool>)obj;

            switch (int.Parse((string)p))
            {
                case 2:
                    SendCommand(s? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.Inlet1);
                    break;
                case 3:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.Inlet2);
                    break;
                case 4:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.Inlet3);
                    break;

                case 5:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.Det1);
                    break;
                case 6:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.Det2);
                    break;
                case 7:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.Det3);
                    break;

                case 8:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.AuxUPC1);
                    break;
                case 9:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.AuxUPC2);
                    break;
                case 10:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Valve, CalibTargets.AuxUPC3);
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

                    case 5:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.Det1);
                        break;
                    case 6:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.Det2);
                        break;
                    case 7:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.Det3);
                        break;

                    case 8:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.AuxUPC1);
                        break;
                    case 9:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.AuxUPC2);
                        break;
                    case 10:
                        SendCommand(CalibActions.Reset, CalibFunctions.Valve, CalibTargets.AuxUPC3);
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

                    case 5:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.Det1);
                        break;
                    case 6:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.Det2);
                        break;
                    case 7:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.Det3);
                        break;

                    case 8:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.AuxUPC1);
                        break;
                    case 9:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.AuxUPC2);
                        break;
                    case 10:
                        SendCommand(CalibActions.Apply, CalibFunctions.Valve, CalibTargets.AuxUPC3);
                        break;
                }
        }

        public ICommand StartStopFlowCommand => new Command(StartStopFlow);

        private async void StartStopFlow(object obj)
        {
            var (p, s) = (ValueTuple<object, bool>)obj;

            switch (int.Parse((string)p))
            {
                case 2:
                    SendCommand(s? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.Inlet1);
                    if (!s)
                    {
                        FrontInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(FrontInlet);
                    }
                    break;
                case 3:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.Inlet2);
                    if (!s)
                    {
                        CenterInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(CenterInlet);
                    }
                    break;
                case 4:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.Inlet3);
                    if (!s)
                    {
                        RearInlet.Type = CalibrationTypes.Flow;
                        await Model.Send(RearInlet);
                    }
                    break;

                case 5:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.Det1);
                    if (!s)
                    {
                        FrontDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(FrontDetector);
                    }
                    break;
                case 6:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.Det2);
                    if (!s)
                    {
                        CenterDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(CenterDetector);
                    }
                    break;
                case 7:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.Det3);
                    if (!s)
                    {
                        RearDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(RearDetector);
                    }
                    break;

                case 8:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.AuxUPC1);
                    if (!s)
                    {
                        AuxUPC1.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC1);
                    }
                    break;
                case 9:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.AuxUPC2);
                    if (!s)
                    {
                        AuxUPC2.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC2);
                    }
                    break;
                case 10:
                    SendCommand(s ? CalibActions.Stop : CalibActions.Start, CalibFunctions.Flow, CalibTargets.AuxUPC3);
                    if (!s)
                    {
                        AuxUPC3.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC3);
                    }
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

                    case 5:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.Det1);
                        FrontDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(FrontDetector);
                        break;
                    case 6:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.Det2);
                        CenterDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(CenterDetector);
                        break;
                    case 7:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.Det3);
                        RearDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(RearDetector);
                        break;

                    case 8:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.AuxUPC1);
                        AuxUPC1.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC1);
                        break;
                    case 9:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.AuxUPC2);
                        AuxUPC2.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC2);
                        break;
                    case 10:
                        SendCommand(CalibActions.Reset, CalibFunctions.Flow, CalibTargets.AuxUPC3);
                        AuxUPC3.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC3);
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

                    case 5:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.Det1);
                        FrontDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(FrontDetector);
                        break;
                    case 6:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.Det2);
                        CenterDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(CenterDetector);
                        break;
                    case 7:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.Det3);
                        RearDetector.Type = CalibrationTypes.Flow;
                        await Model.Send(RearDetector);
                        break;


                    case 8:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.AuxUPC1);
                        AuxUPC1.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC1);
                        break;
                    case 9:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.AuxUPC2);
                        AuxUPC2.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC2);
                        break;
                    case 10:
                        SendCommand(CalibActions.Apply, CalibFunctions.Flow, CalibTargets.AuxUPC3);
                        AuxUPC3.Type = CalibrationTypes.Flow;
                        await Model.Send(AuxUPC3);
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

                    case 5:
                        FrontDetector.Type = CalibrationTypes.Flow;
                        FrontDetector.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(FrontDetector);
                        break;
                    case 6:
                        CenterDetector.Type = CalibrationTypes.Flow;
                        CenterDetector.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(CenterDetector);
                        break;
                    case 7:
                        RearDetector.Type = CalibrationTypes.Flow;
                        RearDetector.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(RearDetector);
                        break;

                    case 8:
                        AuxUPC1.Type = CalibrationTypes.Flow;
                        AuxUPC1.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(AuxUPC1);
                        break;
                    case 9:
                        AuxUPC2.Type = CalibrationTypes.Flow;
                        AuxUPC2.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(AuxUPC2);
                        break;
                    case 10:
                        AuxUPC3.Type = CalibrationTypes.Flow;
                        AuxUPC3.Sensor = CalibrationSensors.Sensor1;
                        await Model.Send(AuxUPC3);
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


                    case 5:
                        FrontDetector.Type = CalibrationTypes.Flow;
                        FrontDetector.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(FrontDetector);
                        break;
                    case 6:
                        CenterDetector.Type = CalibrationTypes.Flow;
                        CenterDetector.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(CenterDetector);
                        break;
                    case 7:
                        RearDetector.Type = CalibrationTypes.Flow;
                        RearDetector.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(RearDetector);
                        break;


                    case 8:
                        AuxUPC1.Type = CalibrationTypes.Flow;
                        AuxUPC1.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(AuxUPC1);
                        break;
                    case 9:
                        AuxUPC2.Type = CalibrationTypes.Flow;
                        AuxUPC2.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(AuxUPC2);
                        break;
                    case 10:
                        AuxUPC3.Type = CalibrationTypes.Flow;
                        AuxUPC3.Sensor = CalibrationSensors.Sensor2;
                        await Model.Send(AuxUPC3);
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


                    case 5:
                        FrontDetector.Type = CalibrationTypes.Flow;
                        FrontDetector.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(FrontDetector);
                        break;
                    case 6:
                        CenterDetector.Type = CalibrationTypes.Flow;
                        CenterDetector.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(CenterDetector);
                        break;
                    case 7:
                        RearDetector.Type = CalibrationTypes.Flow;
                        RearDetector.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(RearDetector);
                        break;


                    case 8:
                        AuxUPC1.Type = CalibrationTypes.Flow;
                        AuxUPC1.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(AuxUPC1);
                        break;
                    case 9:
                        AuxUPC2.Type = CalibrationTypes.Flow;
                        AuxUPC2.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(AuxUPC2);
                        break;
                    case 10:
                        AuxUPC3.Type = CalibrationTypes.Flow;
                        AuxUPC3.Sensor = CalibrationSensors.Sensor3;
                        await Model.Send(AuxUPC3);
                        break;
                }
        }

    }
}
