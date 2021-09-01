using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Provider.Settings;

namespace ChroZenService.Droid
{
    internal class AppVersionAndBuild_Android : IAboutAppInfo
    {
        PackageInfo _appInfo;

        public AppVersionAndBuild_Android()
        {
            var context = Application.Context;
            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);

        }

        public string BuildNumber => _appInfo.LongVersionCode.ToString();

        public string PackageName => _appInfo.PackageName;

        public string VersionNumber => _appInfo.VersionName;

        private string id;
        public string Id
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(id))
                    return id;

                try
                {
                    var context = Android.App.Application.Context;
                    id = Secure.GetString(context.ContentResolver, Secure.AndroidId);
                }
                catch (Exception ex)
                {
                    Android.Util.Log.Warn("DeviceInfo", "Unable to get id: " + ex.ToString());
                }
                return id;
            }
        }
    }


    public class Bootstrapper : ChroZenService.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }

        protected override void Initialize()
        {
            base.Initialize();

            ContainerBuilder.RegisterType<AppVersionAndBuild_Android>().As<IAboutAppInfo>();
        }
    }
}