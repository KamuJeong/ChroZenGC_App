
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
    public partial class View_Root : ContentPage
    {
        public View_Root(ViewModel_Root viewModel)
        {
            Resources.Add("MainMarginKey", new Thickness(App.ScreenWidth / 20, App.ScreenHeight / 100));

            InitializeComponent();

            //TCPManager tcpManager = new TCPManager();
            //EventManager.MainInitializedEvent(tcpManager);
            //Task.Factory.StartNew(() => { tcpManager.ConnectDevice("192.168.0.88", 4242); });

            //NavigationPage.SetHasNavigationBar(this, false);



            BindingContext = viewModel;
         
        }

        protected override void OnAppearing()
        {



            //Thread t = new Thread(WaitingUntilVisibleThenRemoveSplashScreen);
            //t.Start();
            //WaitingUntilVisibleThenRemoveSplashScreen();
            Console.WriteLine("==================================Waiting for view visible==================================");
        }
    }
}
