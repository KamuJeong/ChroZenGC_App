using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
    }
}
