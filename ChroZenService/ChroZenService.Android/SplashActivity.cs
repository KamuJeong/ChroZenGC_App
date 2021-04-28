using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Util;
using System.Threading;

namespace ChroZenService.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            //2021-01-13 : 
            HideNavAndStatusBar();


            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            base.OnCreate(savedInstanceState, persistentState);
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            Window.DecorView.SystemUiVisibilityChange += DecorView_SystemUiVisibilityChange;

            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        private void DecorView_SystemUiVisibilityChange(object sender, View.SystemUiVisibilityChangeEventArgs e)
        {
            HideNavAndStatusBar();
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            //Task startupWork = new Task(() => { StartMain(); });
            //startupWork.Start();
            //StartMain(); //20210426
            StartActivity(new Intent(Application.Context, typeof(MainActivity))); //20210426
        }

        protected override void OnStart()
        {
            base.OnStart();
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        //bool bGoodToGo = false;

        //TaskCompletionSource<bool> tcsGoodToGo = new TaskCompletionSource<bool>();

        // Simulates background work that happens behind the splash screen
        async void StartMain()
        {
            //Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            //Log.Debug(TAG, "Startup work is finished - starting MainActivity.");

            
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            //StartActivityForResult(new Intent(Application.Context, typeof(MainActivity)),0);

            Console.WriteLine("==========================Await Main loading==========================");
            await Task.Delay(1000 * 60 * 2);
            Console.WriteLine("==========================Main loading finish==========================");

            //Finish();
        }

        private void HideNavAndStatusBar()
        {
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            //uiOptions |= (int)SystemUiFlags.LayoutStable;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }
    }
}