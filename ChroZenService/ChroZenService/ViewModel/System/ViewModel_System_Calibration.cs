using ChroZenGC.Core;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenService
{
    public class ViewModel_System_Calibration : Observable
    {
        public Model Model { get; }

        public ConfigurationWrapper Configuration => Model.Configuration;

        public StateWrapper State => Model.State;

        public ViewModel_System_Calibration(Model model)
        {
            Model = model;
        }

        public CalibOvenWrapper Oven { get; } = new CalibOvenWrapper();

    }
}
