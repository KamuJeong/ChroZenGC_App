using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_Root : Observable
    {
        public ViewModel_Root()
        {
            MainView = Resolver.Resolve<View_Main>();
        }

        public View MainView { get; set; }

        public ICommand Home => new Command(() => MainView = Resolver.Resolve<View_Main>());

        public ICommand Config => new Command(() => MainView = Resolver.Resolve<View_Config>());

        public ICommand System => new Command(() => MainView = Resolver.Resolve<View_System>());

    }
}
