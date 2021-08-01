using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
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
        bool timerStop = true;
        int counter = 0;

        Random random = new Random();

        public Model Model { get; }

        public ViewModel_Root(Model model)
        {
            Model = model;
            MainView = Resolver.Resolve<View_Main>();
        }

        public View MainView { get; set; }

        public ICommand Home => new Command(() => MainView = Resolver.Resolve<View_Main>());

        public ICommand Config => new Command(() => MainView = Resolver.Resolve<View_Config>());

        public ICommand System => new Command(() => MainView = Resolver.Resolve<View_System>());

        //public ICommand Config => new Command(() =>
        //    {
        //        if (timerStop)
        //        {
        //            model.Oven.Mode = OvenMode.Program;
        //            model.Oven.Program[0].Rate = 10.0f;

        //            model.State.Mode = Modes.Run;
        //            timerStop = false;
        //            counter = 0;
        //            Device.StartTimer(TimeSpan.FromMilliseconds(200.0), TimerCallBack);
        //        }
        //    });

        //private bool TimerCallBack()
        //{

        //    StateWrapper wrapper = new StateWrapper();
        //    wrapper.Mode = model.State.Mode;
        //    wrapper.RunTime = (float)counter / 300.0f;
        //    wrapper.Signal[0] = (float)(random.NextDouble() * 100.0);
        //    wrapper.Signal[1] = (float)(random.NextDouble() * 100.0 + 100.0);
        //    wrapper.Signal[2] = (float)(random.NextDouble() * 100.0 + 200.0);


        //    wrapper.GasSaver[0] = 1;
        //    wrapper.GasSaver[2] = 1;

        //    model.State.Binary = wrapper.Binary;

        //    counter++;
        //    return timerStop == false;
        //}

        //public ICommand System => new Command(() => { model.Oven.Mode = OvenMode.Isothermal;  timerStop = true; model.State.Mode = Modes.Ready; });
    }
}
