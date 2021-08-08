using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChroZenService
{
    public partial class App : Application
    {
        public static double ScreenHeight { get; set; }
        public static double ScreenWidth { get; set; }

        public static double ClientHeight { get; private set; }

        public static Thickness HeaderMargin { get; } = new Thickness(10, 5);
        public static double FooterHeight {get; } = 72;

        public App()
        {
            double fontDefault = ScreenWidth / 40;

            Resources.Add("MainMarginKey", new Thickness(App.ScreenWidth / 40, 0));
            Resources.Add("SmallFontSizeKey", ScreenWidth / 50);
            Resources.Add("DefaultFontSizeKey", fontDefault);
            Resources.Add("CaptionFontSizeKey", fontDefault * 1.1);
            Resources.Add("ButtonFontSizeKey", ScreenWidth / 30);

            ClientHeight = ScreenHeight - HeaderMargin.Top - HeaderMargin.Bottom - fontDefault - FooterHeight; 

            InitializeComponent();


            MainPage = Resolver.Resolve<View_Root>();




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
