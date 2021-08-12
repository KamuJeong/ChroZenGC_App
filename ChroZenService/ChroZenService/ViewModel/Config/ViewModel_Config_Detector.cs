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
        private DetectorSetupWrapper setup;
        public DetectorSetupWrapper Setup
        {
            get => setup;
            set
            {
                if (setup != null)
                    setup.PropertyModified -= OnDetectorPropertyChanged;
                setup = value;
                if (setup != null)
                    setup.PropertyModified += OnDetectorPropertyChanged;
            }
        }

        private void OnDetectorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary"
                || e.PropertyName.StartsWith(nameof(_TCDPolarityProgramWrapper)))
            {
                if (e.PropertyName.EndsWith("Polarity"))
                    SortTable();

                UpdatePolarityProgram();
            }
        }

        public ObservableCollection<PolarityProgramStep> PolarityProgram { get; } = new ObservableCollection<PolarityProgramStep>();
        private void UpdatePolarityProgram()
        {
            PolarityProgram.Clear();

            int i = 1;
            foreach (var p in Setup.PolarityProgram.TakeWhile(p => p.Polarity != Polarity.Delete))
            {
                PolarityProgram.Add(new PolarityProgramStep { Editable = true, Number = i++, Step = p });
            }

            if (PolarityProgram.Count < 5)
            {
                PolarityProgram.Add(new PolarityProgramStep { Editable = false, Number = i, Step = Setup.PolarityProgram[i - 1] });
            }

            foreach(var p in PolarityProgram)
            {
                p.Update();
            }
        }

        internal void StatePropertyChanged(int select, StateWrapper state)
        {
            switch (select)
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

            UpdatePolarityProgram();
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
            if (obj is PolarityProgramStep p)
            {
                p.Step.Polarity = Polarity.Positive;
            }
            SortTable();
            UpdatePolarityProgram();
        }

        private void SortTable()
        {
            var list = Setup.PolarityProgram.Where(p => p.Polarity != Polarity.Delete).OrderBy(p => p.Time).ToList();
            var deleted = Setup.PolarityProgram.Where(p => p.Polarity == Polarity.Delete).ToList();

            foreach (var pgm in deleted)
                pgm.Time = 0.0f;

            list.AddRange(deleted);

            for (int j = 0; j < list.Count; ++j)
                Setup.PolarityProgram[j] = list[j];
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
