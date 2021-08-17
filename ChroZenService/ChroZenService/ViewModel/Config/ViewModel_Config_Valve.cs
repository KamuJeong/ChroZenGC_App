using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using PropertyChanged;
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
    public class ViewModel_Config_Valve : Observable
    {
        private Model Model { get; }

        public ConfigurationWrapper Configuration => Model.Configuration;

        public ValveSetupWrapper Setup => Model.Valve;

        public ViewModel_Config_Valve(Model model)
        {
            Model = model;
            ValveFilter = Filter;

            Configuration.PropertyModified += OnCofigruationModified;
            Setup.PropertyModified += OnPropertyModified;

            UpdateProgram(Setup.Program);
        }

        private void OnCofigruationModified(object sender, PropertyChangedEventArgs e)
        {
            ValveFilter = null;
            ValveFilter = Filter;
        }

        private void OnPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary"
                || e.PropertyName.StartsWith(nameof(_ValveProgramWrapper)))
            {
                UpdateProgram(Setup.Program);
            }
        }

        public ObservableCollection<ValveProgramStep> Program { get; } = new ObservableCollection<ValveProgramStep>();

        private void UpdateProgram(IList<_ValveProgramWrapper> wrapper)
        {
            int countUpdate = wrapper.TakeWhile(p => p.Valve != ValvePosition.Delete).Count() + 1 - Program.Count;

            while (countUpdate > 0 && Program.Count < 20)
            {
                Program.Add(new ValveProgramStep { Number = Program.Count + 1, Step = wrapper[Program.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                Program.RemoveAt(Program.Count - 1);
                countUpdate++;
            }

            foreach (var p in Program)
            {
                p.Editable = true;
                p.Update();
            }
            if (Program.Count > 0)
            {
                Program.Last().Editable = Program.Last().Step.Valve != ValvePosition.Delete;
                Program.Last().Update();
            }
        }

        public ICommand TimeChangedCommand => new Command(OnTimeChanged);

        [SuppressPropertyChangedWarnings]
        private void OnTimeChanged(object obj)
        {
            if (obj is ValveProgramStep p && p.Step.Time == 0.0f)
            {
                p.Step.Time = 1.0f;
                p.Step.Time = 0.0f;
            }
        }

        public Predicate<Enum> ValveFilter { get; set; }

        private bool Filter(Enum e)
        {
            var p = (ValvePosition)Convert.ChangeType(e, typeof(ValvePosition));
            switch (p)
            {
                case ValvePosition.Valve1:
                case ValvePosition.Valve2:
                case ValvePosition.Valve3:
                case ValvePosition.Valve4:
                case ValvePosition.Valve5:
                case ValvePosition.Valve6:
                case ValvePosition.Valve7:
                case ValvePosition.Valve8:
                    return Configuration.ValveConfig.ValveType[p - ValvePosition.Valve1] != ValveTypes.None;
                case ValvePosition.Multi1:
                case ValvePosition.Multi2:
                    return Configuration.ValveConfig.MultiValveType[p - ValvePosition.Multi1] != ValveTypes.None;
            }
            return true;
        }

    }

    public class ValveProgramStep : Observable
    {
        public int Number { get; set; }
        public _ValveProgramWrapper Step { get; set; }

        public bool Editable { get; set; } = true;
        public void Update()
        {
            OnPropertyChanged(null);
        }
    }
}
