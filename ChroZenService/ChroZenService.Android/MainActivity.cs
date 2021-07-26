using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.IO;
using Android.Util;

namespace ChroZenService.Droid
{
    [Activity(Label = "ChroZenService", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, HardwareAccelerated = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //2021-01-13 : 
            HideNavAndStatusBar();

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            base.OnCreate(savedInstanceState);


            global::Xamarin.Forms.Forms.SetFlags(new string[] { "RadioButton_Experimental", "Brush_Experimental", "Shapes_Experimental" });
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Bootstrapper.Init();

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            Window.DecorView.SystemUiVisibilityChange += DecorView_SystemUiVisibilityChange;

            App.ScreenHeight = (double)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;
            App.ScreenWidth = (double)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density;

            LoadApplication(new App());


        }

        private void DecorView_SystemUiVisibilityChange(object sender, View.SystemUiVisibilityChangeEventArgs e)
        {
            HideNavAndStatusBar();
        }

        protected override void OnResume()
        {
            base.OnResume();
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
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