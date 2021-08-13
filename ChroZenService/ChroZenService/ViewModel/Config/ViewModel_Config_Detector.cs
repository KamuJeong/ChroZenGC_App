using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using ChroZenService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_Config_Detector : Observable
    {
        public DetectorSetupWrapper Setup { get; }


        public ViewModel_Config_Detector(DetectorTypes type, DetectorSetupWrapper setup)
        {
            Setup = setup;
            Type = type;

            Setup.PropertyModified += OnDetectorPropertyChanged;

            UpdatePolarityProgram();
        }

        private void OnDetectorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary" 
                || e.PropertyName.StartsWith(nameof(_TCDPolarityProgramWrapper)))
            {
                UpdatePolarityProgram();
            }
        }

        public ObservableCollection<PolarityProgramStep> PolarityProgram { get; } = new ObservableCollection<PolarityProgramStep>();
        private void UpdatePolarityProgram()
        {
            int countUpdate = Setup.PolarityProgram.TakeWhile(p => p.Polarity != Polarity.Delete).Count() + 1 - PolarityProgram.Count;

            while (countUpdate > 0 && PolarityProgram.Count < 5)
            {
                PolarityProgram.Add(new PolarityProgramStep { Number = PolarityProgram.Count + 1, Step = Setup.PolarityProgram[PolarityProgram.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                PolarityProgram.RemoveAt(PolarityProgram.Count - 1);
                countUpdate++;
            }

            foreach (var p in PolarityProgram)
            {
                p.Editable = true;
                p.Update();
            }
            if (PolarityProgram.Count > 0)
            {
                PolarityProgram.Last().Editable = PolarityProgram.Last().Step.Polarity != Polarity.Delete;
                PolarityProgram.Last().Update();
            }
        }

        internal void StatePropertyChanged(int port, StateWrapper state)
        {
            Temperature = state.Temperature.Detector[port];
            Flow1 = state.Flow.Detectors[port][0];
            Flow2 = state.Flow.Detectors[port][1];
            Flow3 = state.Flow.Detectors[port][2];
            Signal = state.Signal[port];
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

        public ICommand TimeChangedCommand => new Command(OnTimeChanged);

        private void OnTimeChanged(object obj)
        {
            if (obj is PolarityProgramStep p && p.Step.Time == 0.0f)
            {
                p.Step.Time = 1.0f;
                p.Step.Time = 0.0f;
            }
        }
    }

    public class PolarityProgramStep : Observable
    {
        public int Number { get; set; }
        public _TCDPolarityProgramWrapper Step { get; set; }

        public bool Editable { get; set; } = true;
        public void Update()
        {
            OnPropertyChanged(null);
        }
    }
}
