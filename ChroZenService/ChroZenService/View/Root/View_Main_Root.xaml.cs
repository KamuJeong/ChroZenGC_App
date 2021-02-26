
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ChroZenService.ChroZenService_Const;

namespace ChroZenService
{
    public partial class View_Main_Root : ContentPage
    {
        public View_Main_Root()
        {
            InitializeComponent();

            TCPManager tcpManager = new TCPManager();
            EventManager.MainInitializedEvent(tcpManager);
            Task.Factory.StartNew(() => { tcpManager.ConnectDevice("192.168.0.88", 4242); });

            NavigationPage.SetHasNavigationBar(this, false);
         
        }

        protected override void OnAppearing()
        {
            Thread t = new Thread(WaitingUntilVisibleThenRemoveSplashScreen);
            t.Start();
            Console.WriteLine("==================================Waiting for view visible==================================");
        }

        private void WaitingUntilVisibleThenRemoveSplashScreen()
        {
            Task.Delay(1000 * 30);
            var splashAnimation = new Animation(v => WhitePage.Opacity = v, 1, 0);
            splashAnimation.Commit(this, "SplashAnimation", 16, 3000, Easing.Linear, (v, c) => WhitePage.IsVisible = false);
        }
    }
}
