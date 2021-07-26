using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChroZenService
{
    public partial class App : Application
    {
        public static double ScreenHeight {get; set; }
        public static double ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();


            MainPage = Resolver.Resolve<View_Root>();

            Resources.Add("DefaultFontSizeKey", ScreenHeight / 60);
            Resources.Add("ButtonFontSizeKey", ScreenHeight / 45);
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
