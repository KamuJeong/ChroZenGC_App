using ChroZenGC.Core;
using ChroZenGC.Core.Wrappers;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService.ViewModel.Main
{

    public class ViewModel_Main_Top : Observable
    {
        private Model model;

        public ViewModel_Main_Top()
        {
            model = Resolver.Resolve<Model>();

            model.State.PropertyModified += OnStatePropertyChanged;
        }

        [SuppressPropertyChangedWarnings]
        private void OnStatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {  
            switch(model.State.Mode)
            {
//                case ChroZenGC.Core.Packets.Modes.Ready:    LED = Color.LimeGreen; break;
//                case ChroZenGC.Core.Packets.Modes.Run:      LED = Color.Gold; break;
                case ChroZenGC.Core.Packets.Modes.Error:    LED = Color.OrangeRed; break;
//                case ChroZenGC.Core.Packets.Modes.Postrun:  LED = Color.SteelBlue; break;
                default:                                    LED = Color.Silver; break;
            }

            GasSaver = " GAS SAVER " + string.Concat(model.State.GasSaver.Select((s, i) => new { s, p = $"{i + 1} " })
                        .Where(t => t.s != 0)
                        .Select(t => t.p));
        }

        public Color LED { get; set; } = Color.DimGray;

        public string GasSaver { get; set; } = " GAS SAVER ";
    }
}
