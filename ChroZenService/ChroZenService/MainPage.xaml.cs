using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChroZenService
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);

            TCPManager.ConnectDevice("192.168.254.194", 4242);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
