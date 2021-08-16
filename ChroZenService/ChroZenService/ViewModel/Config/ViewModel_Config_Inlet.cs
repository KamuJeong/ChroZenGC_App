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
        public int Port { get; }

        private Model Model { get; }

        public ConfigurationWrapper Configuration => Model.Configuration;

        public InletSetupWrapper Setup => Model.Inlets[Port];

        private StateWrapper State => Model.State;

        public ViewModel_Config_Inlet(int port)
        {
            Port = port;
            Model = Resolver.Resolve<Model>();

            Configuration.PropertyModified += OnConfigurationModified;
            State.PropertyModified += OnStatePropertyModified;
            Setup.PropertyModified += OnInletPropertyModified;

            Type = Configuration.InletType[Port];

            UpdateTempProgram();
            UpdateFlowProgram();
            UpdatePressProgram();
        }

        private void OnConfigurationModified(object sender, PropertyChangedEventArgs e)
        {
            Type = Configuration.InletType[Port];
            Setup.TempMode = Type == InletTypes.OnColumn ? Setup.TempMode : TempModes.Isothermal;
            UpdateTempProgram();
            UpdateFlowProgram();
            UpdatePressProgram();
        }

        private void OnStatePropertyModified(object sender, PropertyChangedEventArgs e)
        {
            Temperature = State.Temperature.Inlet[Port];
            ColumnFlow = State.Flow.Inlets[Port][2];
            TotalFlow = State.Flow.Inlets[Port][0];
            SplitFlow = State.Flow.Inlets[Port][3];
            Pressure = State.Flow.Pressure[Port];
            Velocity = State.Flow.Velocity[Port];
        }

        private void OnInletPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary"
                || e.PropertyName == nameof(_InletTempProgramWrapper) + ">" + nameof(_InletTempProgramWrapper.Rate))
            {
                UpdateTempProgram();
            }
            if (e.PropertyName == "Binary"
                || e.PropertyName == nameof(_ApcFlowProgramWrapper) + ">" + nameof(_ApcFlowProgramWrapper.Rate))
            {
                UpdateFlowProgram();
            }
            if (e.PropertyName == "Binary"
                || e.PropertyName == nameof(_ApcPressProgramWrapper) + ">" + nameof(_ApcPressProgramWrapper.Rate))
            {
                UpdatePressProgram();
            }
        }

        public InletTypes Type { get; set; }

        public float Temperature { get; set; }

        public float ColumnFlow { get; set; }

        public float TotalFlow { get; set; }

        public float SplitFlow { get; set; }

        public float Pressure { get; set; }

        public float Velocity { get; set; }


        public ObservableCollection<InletTempProgramStep> TempProgram { get; } = new ObservableCollection<InletTempProgramStep>();
        public void UpdateTempProgram()
        {
            int countUpdate = Setup.TempProgram.Skip(1).TakeWhile(p => p.Rate != 0.0f).Count() + 2 - TempProgram.Count;

            while (countUpdate > 0 && TempProgram.Count < 6)
            {
                TempProgram.Add(new InletTempProgramStep { Number = TempProgram.Count > 0 ? $"{TempProgram.Count}" : "Init", Step = Setup.TempProgram[TempProgram.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                TempProgram.RemoveAt(TempProgram.Count - 1);
                countUpdate++;
            }

            foreach (var p in TempProgram)
            {
                p.Editable = true;
                p.Update();
            }
            if (TempProgram.Count > 0)
            {
                TempProgram.Last().Editable = TempProgram.Last().Step.Rate != 0;
                TempProgram.Last().Update();
            }
        }

        public ObservableCollection<InletFlowProgramStep> FlowProgram { get; } = new ObservableCollection<InletFlowProgramStep>();
        public void UpdateFlowProgram()
        {
            int countUpdate = Setup.FlowProgram.Skip(1).TakeWhile(p => p.Rate != 0.0f).Count() + 2 - FlowProgram.Count;

            while (countUpdate > 0 && FlowProgram.Count < 6)
            {
                FlowProgram.Add(new InletFlowProgramStep { Number = FlowProgram.Count > 0 ? $"{FlowProgram.Count}" : "Init", Step = Setup.FlowProgram[FlowProgram.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                FlowProgram.RemoveAt(FlowProgram.Count - 1);
                countUpdate++;
            }

            foreach (var p in FlowProgram)
            {
                p.Editable = true;
                p.Update();
            }
            if (FlowProgram.Count > 0)
            {
                FlowProgram.Last().Editable = FlowProgram.Last().Step.Rate != 0;
                FlowProgram.Last().Update();
            }
        }

        public ObservableCollection<InletPressProgramStep> PressProgram { get; } = new ObservableCollection<InletPressProgramStep>();
        public void UpdatePressProgram()
        {
            int countUpdate = Setup.PressProgram.Skip(1).TakeWhile(p => p.Rate != 0.0f).Count() + 2 - PressProgram.Count;

            while (countUpdate > 0 && PressProgram.Count < 6)
            {
                PressProgram.Add(new InletPressProgramStep { Number = PressProgram.Count > 0 ? $"{PressProgram.Count}" : "Init", Step = Setup.PressProgram[PressProgram.Count] });
                countUpdate--;
            }

            while (countUpdate < 0)
            {
                PressProgram.RemoveAt(PressProgram.Count - 1);
                countUpdate++;
            }

            foreach (var p in PressProgram)
            {
                p.Editable = true;
                p.Update();
            }
            if (PressProgram.Count > 0)
            {
                PressProgram.Last().Editable = PressProgram.Last().Step.Rate != 0;
                PressProgram.Last().Update();
            }
        }
    }

    public class InletTempProgramStep : Observable
    {
        public string Number { get; set; }
        public _InletTempProgramWrapper Step { get; set; }
        public bool Editable { get; set; } = true;
        public void Update()
        {
            OnPropertyChanged(null);
        }
    }

    public class InletFlowProgramStep : Observable
    {
        public string Number { get; set; }
        public _ApcFlowProgramWrapper Step { get; set; }

        public bool Editable { get; set; } = true;
        public void Update()
        {
            OnPropertyChanged(null);
        }
    }

    public class InletPressProgramStep : Observable
    {
        public string Number { get; set; }
        public _ApcPressProgramWrapper Step { get; set; }

        public bool Editable { get; set; } = true;
        public void Update()
        {
            OnPropertyChanged(null);
        }
    }
}
