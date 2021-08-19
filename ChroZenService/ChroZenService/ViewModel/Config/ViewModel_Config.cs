using Autofac;
using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{

    public class ViewModel_Config : Observable
    {
        public Model Model { get; }

        public StateWrapper State => Model.State;

        public ConfigurationWrapper Configuration => Model.Configuration;

        public OvenWrapper Oven => Model.Oven;

        public List<ViewModel_Config_Inlet> Inlets { get; } = new List<ViewModel_Config_Inlet>();

        public List<ViewModel_Config_Detector> Detectors { get; } = new List<ViewModel_Config_Detector>();

        public ViewModel_Config_Signals Signals { get; }

        public ViewModel_Config_Valve Valve { get; }

        public AuxTempSetupWrapper AuxTemp => Model.AuxTemp;

        public ObservableCollection<AuxUPCSetupWrapper> AuxUPC => Model.AuxUPC;

        public ViewModel_Config(Model model, ViewModel_Config_Signals signals, ViewModel_Config_Valve valve)
        {
            Model = model;

            Inlets.Add(Resolver.Resolve<ViewModel_Config_Inlet>(new NamedParameter("port", 0)));
            Inlets.Add(Resolver.Resolve<ViewModel_Config_Inlet>(new NamedParameter("port", 1)));
            Inlets.Add(Resolver.Resolve<ViewModel_Config_Inlet>(new NamedParameter("port", 2)));

            Detectors.Add(Resolver.Resolve<ViewModel_Config_Detector>(new NamedParameter("port", 0)));
            Detectors.Add(Resolver.Resolve<ViewModel_Config_Detector>(new NamedParameter("port", 1)));
            Detectors.Add(Resolver.Resolve<ViewModel_Config_Detector>(new NamedParameter("port", 2)));

            Signals = signals;
            Valve = valve;

            Oven.PropertyModified += OvenPropertyChanged;
            UpdateOvenProgram();

            State.PropertyModified += StatePropertyModified;
        }

        private void StatePropertyModified(object sender, PropertyChangedEventArgs e)
        {
            IsEditable = State.Mode switch { Modes.Ready => true, Modes.NotReady => true, Modes.NotConnected => true, _ => false };
        }

        public bool IsEditable { get; set; } = true;

        public int SelectedItem { get; set; } = 1;


        // Oven setup

        public ObservableCollection<OvenProgramStep> OvenProgram { get; } = new ObservableCollection<OvenProgramStep>();
        public void UpdateOvenProgram()
        {
            int countUpdate = Oven.Program.TakeWhile(p => p.Rate != 0.0f).Count() + 1 - OvenProgram.Count;

            while (countUpdate > 0 && OvenProgram.Count < 25)
            {
                OvenProgram.Add(new OvenProgramStep { Number = OvenProgram.Count + 1, Step = Oven.Program[OvenProgram.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                OvenProgram.RemoveAt(OvenProgram.Count - 1);
                countUpdate++;
            }

            foreach (var p in OvenProgram)
                p.Update();
        }

        private void OvenPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Binary" || e.PropertyName == nameof(_OvenProgramWrapper) + ">" + nameof(_OvenProgramWrapper.Rate))
            {
                UpdateOvenProgram();
            }
        }


    }

    public class OvenProgramStep : Observable
    {
        public int Number { get; set; }
        public _OvenProgramWrapper Step { get; set; }

        public void Update()
        {
            OnPropertyChanged(null);
        }
    }
}
