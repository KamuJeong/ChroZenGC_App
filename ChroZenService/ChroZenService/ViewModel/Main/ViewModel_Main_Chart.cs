using ChroZenGC.Core;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChroZenService.ViewModel.Main
{
    public class ViewModel_Main_Chart : Observable
    {
        private Model model;

        public ViewModel_Main_Chart()
        {
            model = Resolver.Resolve<Model>();

            model.State.PropertyChanged += OnStatePropertyChanged;
        }

        public int Counter { get; set; }

        public List<ValueTuple<float, float, float, float>> Points { get; }  = new List<ValueTuple<float, float, float, float>>();

        private void OnStatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary")
            {
                var state = sender as StateWrapper;
                if (state.Mode == ChroZenGC.Core.Packets.Modes.Run)
                {
                    if (state.RunTime < Points.LastOrDefault().Item1)
                    {
                        Points.Clear();
                        Counter = 0;
                    }
                    Points.Add((state.RunTime, state.Signal[0], state.Signal[1], state.Signal[2]));
                    Counter = Points.Count;
                }
            };
        }

        public float Min { get; set; }

        public float Max { get; set; } = 1000.0f;

    }
}
