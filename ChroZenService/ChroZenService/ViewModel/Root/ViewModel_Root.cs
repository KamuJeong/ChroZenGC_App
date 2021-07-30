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

        Model model;

        public ViewModel_Root(Model model)
        {
            this.model = model;
            MainView = Resolver.Resolve<View_Main>();
        }

        public View MainView { get; set; }

        public ICommand Home => new Command(() => MainView = Resolver.Resolve<View_Main>());

        //public ICommand Config => new Command(() => MainView = Resolver.Resolve<View_Config>());

        //public ICommand System => new Command(() => MainView = Resolver.Resolve<View_System>());

        public ICommand Config => new Command(() =>
            {
                if (timerStop)
                {
                    timerStop = false;
                    counter = 0;
                    Device.StartTimer(TimeSpan.FromMilliseconds(200.0), TimerCallBack);
                }
            });

        private bool TimerCallBack()
        {

            StateWrapper wrapper = new StateWrapper();
            wrapper.Mode = Modes.Run;
            wrapper.RunTime = (float)counter / 300.0f;
            wrapper.Signal[0] = (float)(random.NextDouble() * 100.0);
            wrapper.Signal[1] = (float)(random.NextDouble() * 100.0 + 100.0);
            wrapper.Signal[2] = (float)(random.NextDouble() * 100.0 + 200.0);

            model.State.Binary = wrapper.Binary;

            counter++;
            return timerStop == false;
        }

        public ICommand System => new Command(() => timerStop = true);
    }
}
