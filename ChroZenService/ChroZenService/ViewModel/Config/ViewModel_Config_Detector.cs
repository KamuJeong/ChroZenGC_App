using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{ 
    public class ViewModel_Config_Detector : Observable
    {
        public DetectorSetupWrapper Setup { get; set; }

        internal void StatePropertyChanged(int select, StateWrapper state)
        {
            switch(select)
            {
                case 7:
                case 8:
                case 9:
                    Temperature = state.Temperature.Detector[select - 7];
                    Flow1 = state.Flow.Detectors[select - 7][0];
                    Flow2 = state.Flow.Detectors[select - 7][1];
                    Flow3 = state.Flow.Detectors[select - 7][2];
                    Signal = state.Signal[select - 7];
                    break;
            }
        }

        internal void OnSelectedItem(int select, Model model)
        {
            switch (select)
            {
                case 7:
                case 8:
                case 9:
                    Setup = model.Detectors[select - 7];
                    Type = model.Configuration.DetectorType[select - 7];
                    break;
                default:
                    return;
            }

            //MaxColumnFlow = Type == InletTypes.Capillary ? 30.0f : 200.0f;
            //Setup.TempMode = Type == InletTypes.OnColumn ? Setup.TempMode : TempModes.Isothermal;

            //TempProgram.Clear();
            //UpdateTempProgram();
            //FlowProgram.Clear();
            //UpdateFlowProgram();
            //PressProgram.Clear();
            //UpdatePressProgram();
        }

        public DetectorTypes Type { get; set; }

        public float Temperature { get; set; }

        public float Flow1 { get; set; }

        public float Flow2 { get; set; }

        public float Flow3 { get; set; }

        public float Signal { get; set; }

        // Detector
        public ICommand IgniteCommand => new Command(OnIgnition);

        private void OnIgnition(object obj)
        {
            switch (Type)
            {
                case DetectorTypes.FID:
                case DetectorTypes.NPD:
                    Setup.ElectrometerOnOff = Setup.Flow1OnOff = Setup.Flow2OnOff = Setup.Flow3OnOff = (bool)obj;
                    break;
                case DetectorTypes.FPD:
                    Setup.ElectrometerOnOff = Setup.Flow1OnOff = Setup.Flow3OnOff = (bool)obj;
                    break;
                case DetectorTypes.PFPD:
                    Setup.ElectrometerOnOff = Setup.Flow1OnOff = Setup.Flow2OnOff = (bool)obj;
                    break;
            }
        }

    }
}
