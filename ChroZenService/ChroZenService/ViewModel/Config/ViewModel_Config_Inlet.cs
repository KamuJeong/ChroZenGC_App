using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_Config_Inlet : Observable
    {
        private InletSetupWrapper setup;
        public InletSetupWrapper Setup 
        {
            get => setup;
            set
            {
                if (setup != null)
                    setup.PropertyModified -= OnInletPropertyChanged;
                setup = value;
                if (setup != null)
                    setup.PropertyModified += OnInletPropertyChanged;
            }
        }

        private void OnInletPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary" || e.PropertyName == nameof(_InletTempProgramWrapper) + ">" + nameof(_InletTempProgramWrapper.Rate))
            {
                UpdateTempProgram();
            }
        }

        public InletTypes Type { get; set; }

        public float Temperature { get; set; }

        public float ColumnFlow { get; set; }
        public float MaxColumnFlow { get; set; } = 200.0f;

        public float TotalFlow { get; set; }

        public float SplitFlow { get; set; }

        public float Pressure { get; set; }

        public float Velocity { get; set; }


        public void StatePropertyChanged(int select, StateWrapper state)
        {
            switch (select)
            {
                case 3:
                case 4:
                case 5:
                    Temperature = state.Temperature.Inlet[select - 3];
                    ColumnFlow = state.Flow.Inlets[select - 3][2];
                    TotalFlow = state.Flow.Inlets[select - 3][0];
                    SplitFlow = state.Flow.Inlets[select - 3][3];
                    Pressure = state.Flow.Pressure[select - 3];
                    Velocity = state.Flow.Velocity[select - 3];
                    break;
            }
        }

        public void OnSelectedItem(int select, Model model)
        {
            switch(select)
            {
                case 3:
                    Setup = model.Inlets[0];
                    Type = model.Configuration.InletType[0];
                    break;
                case 4:
                    Setup = model.Inlets[1];
                    Type = model.Configuration.InletType[1];
                    break;
                case 5:
                    Setup = model.Inlets[2];
                    Type = model.Configuration.InletType[2];
                    break;
                default:
                    return;
            }

            MaxColumnFlow = Type == InletTypes.Capillary ? 30.0f : 200.0f;
            Setup.TempMode = Type == InletTypes.OnColumn ? Setup.TempMode : TempModes.Isothermal;

            TempProgram.Clear();
            UpdateTempProgram();
        }

        public ObservableCollection<InletTempProgramStep> TempProgram { get; } = new ObservableCollection<InletTempProgramStep>();
        public void UpdateTempProgram()
        {
            int countUpdate = Setup.TempProgram.Skip(1).TakeWhile(p => p.Rate != 0.0f).Count() + 2 - TempProgram.Count;
           
            while (countUpdate > 0 && TempProgram.Count < 6)
            {
                TempProgram.Add(new InletTempProgramStep { Number = TempProgram.Count > 0? $"{TempProgram.Count}" : "Init", Step = Setup.TempProgram[TempProgram.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                TempProgram.RemoveAt(TempProgram.Count - 1);
                countUpdate++;
            }

            foreach(var p in TempProgram)
            {
                p.Editable = true;
            }
            if(TempProgram.Count > 0)
                TempProgram.Last().Editable = TempProgram.Last().Step.Rate != 0;
        }
    }

    public class InletTempProgramStep : Observable
    {
        public string Number { get; set; }
        public _InletTempProgramWrapper Step { get; set; }

        public bool Editable { get; set; } = true;
    }
}
