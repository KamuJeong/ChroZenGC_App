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
using Xamarin.Essentials;

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

//            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags(new string[] { "RadioButton_Experimental", "Brush_Experimental", "Shapes_Experimental" });

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            Window.DecorView.SystemUiVisibilityChange += DecorView_SystemUiVisibilityChange;

            //Task.Run(async () =>
            //{
            //    const int seconds = 30;
            //    const string grefTag = "monodroid-gref";
            //    const string grefsFile = "grefs.txt";
            //    while (true)
            //    {
            //        var appDir = Application.ApplicationInfo.DataDir;
            //        var grefFile = Path.Combine("/data/data", PackageName, "files/.__override__", grefsFile);
            //        var grefFilePublic = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, grefsFile);
            //        if (File.Exists(grefFile))
            //        {
            //            try
            //            {
            //                File.Copy(grefFile, grefFilePublic, true);
            //                Log.Debug(grefTag, $"adb pull {grefFilePublic} {grefsFile}");
            //            }
            //            catch (Exception e)
            //            {
            //                Console.WriteLine(string.Format("GREF Log Err Message : {0}, StackTrace : {1}", e.Message, e.StackTrace));
            //            }
            //        }
            //        else
            //            Log.Debug(grefTag, "no grefs.txt found, gref logging enabled? (adb shell setprop debug.mono.log gref)");
            //        await Task.Delay(seconds * 1000);
            //    }
            //});
            //Task.Run(async () =>
            //{
            //    const int seconds = 120;
            //    const string grefTag = "monodroid-gref";
            //    const string grefsFile = "grefs.txt";
            //    while (true)
            //    {
            //        var appDir = Application.ApplicationInfo.DataDir;
            //        var grefFile = System.IO.Path.Combine("/data/data", PackageName, "files/.__override__", grefsFile);
            //        //var grefFilePublic = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "download", grefsFile);
            //        var grefFilePublic = System.IO.Path.Combine(Android.OS.Environment.DirectoryDownloads, grefsFile);
            //        if (System.IO.File.Exists(grefFile))
            //        {
            //            System.IO.File.Copy(grefFile, grefFilePublic, true);
            //            System.Console.Write(grefTag, $"adb pull {grefFilePublic} {grefsFile}");
            //        }
            //        else
            //            System.Console.Write(grefTag, "no grefs.txt found, gref logging enabled? (adb shell setprop debug.mono.log gref)");
            //        await Task.Delay(seconds * 1000);
            //    }
            //});

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