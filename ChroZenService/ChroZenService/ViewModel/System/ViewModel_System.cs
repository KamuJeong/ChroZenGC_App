using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_System : Observable
    {
        public ViewModel_Root Root { get; }

        public Model Model { get; }

        public InformationWrapper Informaton => Model.Information;

        public ConfigurationWrapper Configuration => Model.Configuration;

        public ViewModel_System(Model model, ViewModel_Root root)
        {
            Model = model;
            Root = root;
        }

        public int SelectedItem { get; set; } = 1;

        public ICommand SetNetworkCommand => new Command(OnSetNetwork);

        private static void OnSetNetwork(object obj)
        {
            
        }

        public string IPAddress { get; set; }

        public string NetworkMask { get; set; }

        public string GateWay { get; set; }

        public Predicate<Enum> DetectorFilter => (e) => !new List<DetectorTypes> { DetectorTypes.FPD_Not_used, DetectorTypes.NPD_Not_used, DetectorTypes.ECD }
                                                                .Any(n => object.Equals(n, e));
    }
}
