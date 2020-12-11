using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //try
            {
                InitializeComponent();
            }
            //catch (Exception e)
            //{

            //    Debug.WriteLine(string.Format("e.Message : {0}, e.StackTrace : {1}", e.Message, e.StackTrace));
            //}
            NavigationPage.SetHasNavigationBar(this,false);

        }
    }
}
