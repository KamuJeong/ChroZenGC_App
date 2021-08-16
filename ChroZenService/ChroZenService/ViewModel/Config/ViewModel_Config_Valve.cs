using ChroZenGC.Core;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

    }
}
