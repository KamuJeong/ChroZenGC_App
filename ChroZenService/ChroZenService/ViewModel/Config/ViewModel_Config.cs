using Autofac;
using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
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

    public class ViewModel_Config : Observable
    {
        public Model Model { get; }

        public StateWrapper State => Model.State;

        public OvenWrapper Oven => Model.Oven;

        public List<ViewModel_Config_Inlet> Inlets { get; } = new List<ViewModel_Config_Inlet>();

        public List<ViewModel_Config_Detector> Detectors { get; } = new List<ViewModel_Config_Detector>();

        public ViewModel_Config_Signals Signals { get; }

        public ViewModel_Config()
        {
            Model = Resolver.Resolve<Model>();

            Inlets.Add(Resolver.Resolve<ViewModel_Config_Inlet>(
                new NamedParameter("type", Model.Configuration.InletType[0]), new NamedParameter("setup", Model.Inlets[0])));
            Inlets.Add(Resolver.Resolve<ViewModel_Config_Inlet>(
                new NamedParameter("type", Model.Configuration.InletType[1]), new NamedParameter("setup", Model.Inlets[1])));
            Inlets.Add(Resolver.Resolve<ViewModel_Config_Inlet>(
                new NamedParameter("type", Model.Configuration.InletType[2]), new NamedParameter("setup", Model.Inlets[2])));

            Detectors.Add(Resolver.Resolve<ViewModel_Config_Detector>(
                new NamedParameter("type", Model.Configuration.DetectorType[0]), new NamedParameter("setup", Model.Detectors[0])));
            Detectors.Add(Resolver.Resolve<ViewModel_Config_Detector>(
                new NamedParameter("type", Model.Configuration.DetectorType[1]), new NamedParameter("setup", Model.Detectors[1])));
            Detectors.Add(Resolver.Resolve<ViewModel_Config_Detector>(
                new NamedParameter("type", Model.Configuration.DetectorType[2]), new NamedParameter("setup", Model.Detectors[2])));

            Signals = Resolver.Resolve<ViewModel_Config_Signals>();

            State.PropertyModified += StatePropertyChanged;
            Oven.PropertyModified += OvenPropertyChanged;
            UpdateOvenProgram();
        }


        private void StatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            for(int i=0; i<3; ++i)
            {
                Inlets[i].StatePropertyChanged(i, State);
                Detectors[i].StatePropertyChanged(i, State);
            }
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
