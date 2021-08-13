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
    public class ViewModel_Config_Signals : Observable
    {
        public Model Model {get;}

        public SignalSetupWrapper this[int index]
        {
            get => Model.Signals[index];
        }
        public ViewModel_Config_Signals(Model model)
        {
            Model = model;

            this[0].PropertyModified += OnPropertyModified1;
            this[1].PropertyModified += OnPropertyModified2;
            this[2].PropertyModified += OnPropertyModified3;

            UpdateProgram(this[0].Program, Program1);
            UpdateProgram(this[1].Program, Program2);
            UpdateProgram(this[2].Program, Program3);
        }

        private void OnPropertyModified3(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary"
                || e.PropertyName.StartsWith(nameof(_SignalProgramWrapper)))
            {
                UpdateProgram(this[2].Program, Program3);
            }
        }

        private void OnPropertyModified2(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary"
                || e.PropertyName.StartsWith(nameof(_SignalProgramWrapper)))
            {
                UpdateProgram(this[1].Program, Program2);
            }
        }

        private void OnPropertyModified1(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary"
                || e.PropertyName.StartsWith(nameof(_SignalProgramWrapper)))
            {
                UpdateProgram(this[0].Program, Program1);
            }
        }


        public ObservableCollection<SignalProgramStep> Program1 { get; } = new ObservableCollection<SignalProgramStep>();
        public ObservableCollection<SignalProgramStep> Program2 { get; } = new ObservableCollection<SignalProgramStep>();
        public ObservableCollection<SignalProgramStep> Program3 { get; } = new ObservableCollection<SignalProgramStep>();

        private void UpdateProgram(IList<_SignalProgramWrapper> wrapper, ObservableCollection<SignalProgramStep> program)
        {
            int countUpdate = wrapper.TakeWhile(p => p.Detector != SignalDetectors.Delete).Count() + 1 - program.Count;

            while (countUpdate > 0 && program.Count < 5)
            {
                program.Add(new SignalProgramStep { Number = program.Count + 1, Step = wrapper[program.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                program.RemoveAt(program.Count - 1);
                countUpdate++;
            }

            foreach (var p in program)
            {
                p.Editable = true;
                p.Update();
            }
            if (program.Count > 0)
            {
                program.Last().Editable = program.Last().Step.Detector != SignalDetectors.Delete;
                program.Last().Update();
            }
        }

        public ICommand TimeChangedCommand => new Command(OnTimeChanged);

        private void OnTimeChanged(object obj)
        {
            if (obj is SignalProgramStep p && p.Step.Time == 0.0f)
            {
                p.Step.Time = 1.0f;
                p.Step.Time = 0.0f;
            }
        }

    }

    public class SignalProgramStep : Observable
    {
        public int Number { get; set; }
        public _SignalProgramWrapper Step { get; set; }

        public bool Editable { get; set; } = true;
        public void Update()
        {
            OnPropertyChanged(null);
        }
    }
}
