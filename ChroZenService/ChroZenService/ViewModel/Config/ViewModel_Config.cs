using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{

    public class ViewModel_Config : Observable
    {
        public Model Model { get; }

        public StateWrapper State => Model.State;

        public OvenWrapper Oven => Model.Oven;

        public ViewModel_Config_Inlet Inlet { get;  }





        public ViewModel_Config()
        {
            Model = Resolver.Resolve<Model>();
            Inlet = Resolver.Resolve<ViewModel_Config_Inlet>();

            State.PropertyModified += StatePropertyChanged;
            Oven.PropertyModified += OvenPropertyChanged;
            UpdateOvenProgram();
        }

        private void StatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Inlet.StatePropertyChanged(SelectedItem, State);
        }

        public bool IsEditable { get; set; } = true;

        private int selectedItem = 1;
        public int SelectedItem
        {
            get => selectedItem;
            set
            {
                Inlet.OnSelectedItem(selectedItem = value, Model);
            }
        }

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
        }

        private void OvenPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Binary" || e.PropertyName == nameof(_OvenProgramWrapper) + ">" + nameof(_OvenProgramWrapper.Rate))
            {
                UpdateOvenProgram();
            }
        }

        // inlet


    }

    public class OvenProgramStep
    {
        public int Number { get; set; }
        public _OvenProgramWrapper Step { get; set; }
    }
}
