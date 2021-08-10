using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService.ViewModel.Main
{
    public class ViewModel_Main_Center : Observable
    {
        private Model model;

        private ConfigurationWrapper Configuration => model.Configuration;

        private StateWrapper State => model.State;

        public void Initialize()
        {
            try
            {
                ActiveInlet = Enumerable.Range(0, 3).First(i => Configuration.InletType[i] != InletTypes.NotInstalled);
            }
            catch
            {
                ActiveInlet = -1;
            }

            try
            {
                ActiveDetector = Enumerable.Range(0, 3).First(i => Configuration.InletType[i] != InletTypes.NotInstalled);
            }
            catch
            {
                ActiveDetector = -1;
            }
        }

        public ViewModel_Main_Center()
        {
            model = Resolver.Resolve<Model>();

            model.State.PropertyModified += OnStateModified;

            foreach (var inlet in model.Inlets)
                inlet.PropertyModified += OnInletModified;

            foreach (var detector in model.Detectors)
                detector.PropertyModified += OnDetectorModified;

            Initialize();
        }


        private void UpdateInletData()
        {
            if (ActiveInlet >= 0 && ActiveInlet < 3)
            {
                LeftGridRow = 2 * (ActiveInlet + 1);
                InletType = Configuration.InletType[ActiveInlet];

                var inlet = model.Inlets[ActiveInlet];
                InletGasType = inlet.CarrierGas;
                if (InletType == InletTypes.Capillary)
                {
                    SplitRatio = inlet.SplitRatio;
                }
                else
                {
                    SplitRatio = 0;
                }
                APCMode = inlet.APCMode;

                InletFlow = State.Flow.Inlets[activeInlet][2];
                InletPressure = State.Flow.Pressure[activeInlet];
                InletTemperature = State.Temperature.Inlet[activeInlet];
            }
            else
            {
                LeftGridRow = 0;
                InletType = InletTypes.NotInstalled;
                InletGasType = GasTypes.N2;
                SplitRatio = 0;
                APCMode = APCModes.ConstantFlow;
                InletFlow = 0.0f;
                InletPressure = 0.0f;
                InletTemperature = 0.0f;
            }
        }


        private void OnInletModified(object sender, PropertyChangedEventArgs e) => UpdateInletData();

        private void OnStateModified(object sender, PropertyChangedEventArgs e)
        {
            UpdateInletData();
            UpdateDetectorData();
        }

        // Left Pane : Inlet data

        private int activeInlet = -1;
        public int ActiveInlet
        {
            get => activeInlet;
            set
            {
                activeInlet = value;
                UpdateInletData();
            }
        }

        public int LeftGridRow { get; set; }
        public InletTypes InletType { get; set; }
        public GasTypes InletGasType { get; set; }
        public float InletFlow { get; set; }
        public float InletPressure { get; set; }
        public APCModes APCMode { get; set; }
        public int SplitRatio { get; set; }
        public float InletTemperature { get; set; }


        public ICommand Inlet => new Command<string>(InletSelect);

        private void InletSelect(string row)
        {
            if(Configuration.InletType[int.Parse(row)] != InletTypes.NotInstalled)
                ActiveInlet = int.Parse(row);
        }

        // Right Pane : Detector data
        private void OnDetectorModified(object sender, PropertyChangedEventArgs e) => UpdateDetectorData();

        private void UpdateDetectorData()
        {
            if (activeDetector >= 0 && activeDetector < 3)
            {

                RightGridRow = 2 * (activeDetector + 1);


                DetectorType = Configuration.DetectorType[activeDetector];

                var detector = model.Detectors[activeDetector];
                Flame = DetectorType switch
                {
                    DetectorTypes.FID => detector.AutoIgnition?  FlameFlags.FlameON : FlameFlags.FlameOFF,
                    DetectorTypes.NPD => detector.AutoIgnition ? FlameFlags.FlameON : FlameFlags.FlameOFF,
                    DetectorTypes.FPD => detector.AutoIgnition ? FlameFlags.FlameON : FlameFlags.FlameOFF,
                    DetectorTypes.PFPD => detector.AutoIgnition ? FlameFlags.FlameON : FlameFlags.FlameOFF,
                    _ => FlameFlags.NotInstalled
                };
                DetectorSignal = State.Signal[activeDetector];
                DetectorFlow1 = State.Flow.Detectors[activeDetector][0];
                DetectorFlow2 = State.Flow.Detectors[activeDetector][1];
                DetectorFlow3 = State.Flow.Detectors[activeDetector][2];
                DetectorTemperature = State.Temperature.Detector[activeDetector];
            }
            else
            {
                Flame = FlameFlags.NotInstalled;
                RightGridRow = 0;
                DetectorType = DetectorTypes.NotInstalled;
                DetectorSignal = 0.0f;
                DetectorFlow1 = 0.0f;
                DetectorFlow2 = 0.0f;
                DetectorFlow3 = 0.0f;
                DetectorTemperature = 0.0f;
            }
        }


        private int activeDetector = -1;
        public int ActiveDetector
        {
            get => activeDetector;
            set
            {
                activeDetector = value;
                UpdateDetectorData();
            }
        }

        public enum FlameFlags  { NotInstalled, FlameOFF, FlameON };

        public int RightGridRow { get; set; }

        public DetectorTypes DetectorType { get; set; }
        public FlameFlags Flame { get; set; }
        public float DetectorSignal { get; set; }
        public float DetectorFlow1 { get; set; }
        public float DetectorFlow2 { get; set; }
        public float DetectorFlow3 { get; set; }
        public float DetectorTemperature { get; set; }

        public ICommand Detector => new Command<string>(DetectorSelect);

        private void DetectorSelect(string row)
        {
            if(Configuration.DetectorType[int.Parse(row)] != DetectorTypes.NotInstalled)
                ActiveDetector = int.Parse(row);
        }

        // Control

        public int Height => (int)(566 * 0.9 * App.ScreenWidth / 695);
        public ICommand SwipeUp => new Command((arg) =>
        {
            for (int i = 0; i < 3; ++i)
            {
                if ("Left".Equals(arg))
                {
                    if (i > ActiveInlet && Configuration.InletType[i] != InletTypes.NotInstalled)
                    {
                        ActiveInlet = i;
                        break;
                    }
                }
                else if ("Right".Equals(arg))
                {
                    if (i > ActiveDetector && Configuration.DetectorType[i] != DetectorTypes.NotInstalled)
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
                    if (i < ActiveInlet && Configuration.InletType[i] != InletTypes.NotInstalled)
                    {
                        ActiveInlet = i;
                        break;
                    }
                }
                else if ("Right".Equals(arg))
                {
                    if (i < ActiveDetector && Configuration.DetectorType[i] != DetectorTypes.NotInstalled)
                    {
                        ActiveDetector = i;
                        break;
                    }
                }
            }
        });
    }
}
