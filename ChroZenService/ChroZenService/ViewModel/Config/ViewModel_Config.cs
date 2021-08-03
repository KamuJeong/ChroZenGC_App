using ChroZenGC.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{ 
    public class ViewModel_Config : Observable
    {
        public Model Model { get; }

        public ViewModel_Config()
        {
            Model = Resolver.Resolve<Model>();

        }

    }
}
