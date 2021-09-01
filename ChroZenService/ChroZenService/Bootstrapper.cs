using Autofac;
using ChroZenGC.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public interface IAboutAppInfo
    {
        string PackageName { get; }
        string VersionNumber { get; }
        string BuildNumber { get; }

        string Id { get; }
    }


    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder {  get; private set;  }

        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach (var type in currentAssembly.DefinedTypes
                      .Where(e =>
//                             e.IsSubclassOf(typeof(Page)) ||
                             e.IsSubclassOf(typeof(ContentView)) ||
                             e.IsSubclassOf(typeof(Observable))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }
            ContainerBuilder.RegisterType<ChroZenGC.Core.Model>().SingleInstance();
            ContainerBuilder.RegisterType<View_Root>().SingleInstance();
            ContainerBuilder.RegisterType<ViewModel_Root>().SingleInstance();
            ContainerBuilder.RegisterType<View_Main>().SingleInstance();
            ContainerBuilder.RegisterType<ViewModel_Main>().SingleInstance();
            ContainerBuilder.RegisterType<View_Config>().SingleInstance();
            ContainerBuilder.RegisterType<ViewModel_Config>().SingleInstance();
            ContainerBuilder.RegisterType<View_System>().SingleInstance();
            ContainerBuilder.RegisterType<ViewModel_System>().SingleInstance();
            ContainerBuilder.RegisterType<DeviceIPFinder>().SingleInstance();

        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
