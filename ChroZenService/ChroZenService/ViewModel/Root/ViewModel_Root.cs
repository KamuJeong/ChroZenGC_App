﻿using ChroZenGC.Core;
using ChroZenGC.Core.Network;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace ChroZenService
{

    public static class BindingObjectExtensions
    {
        private static MethodInfo _bindablePropertyGetContextMethodInfo = typeof(BindableObject).GetMethod("GetContext", BindingFlags.NonPublic | BindingFlags.Instance);
        private static FieldInfo _bindablePropertyContextBindingFieldInfo;

        public static Binding GetBinding(this BindableObject bindableObject, BindableProperty bindableProperty)
        {
            object bindablePropertyContext = _bindablePropertyGetContextMethodInfo.Invoke(bindableObject, new[] { bindableProperty });

            if (bindablePropertyContext != null)
            {
                FieldInfo propertyInfo = _bindablePropertyContextBindingFieldInfo =
                    _bindablePropertyContextBindingFieldInfo ??
                        bindablePropertyContext.GetType().GetField("Binding");

                return (Binding)propertyInfo.GetValue(bindablePropertyContext);
            }

            return null;
        }
    }



    public class ViewModel_Root : Observable
    {
        public DeviceIPFinder IPFinder { get; set; }

        public INetworkManager networkManager { get; set; }

        public Model Model { get; }

        public string TimeTicker { get; set; }

        public ViewModel_Root(Model model, DeviceIPFinder finder)
        {
            Model = model;
            IPFinder = finder;


            Device.StartTimer(TimeSpan.FromSeconds(1.0), () =>
            {
                TimeTicker = DateTime.Now.ToString("T");

                bool isConnected = IsConnected;
//                IsConnected = networkManager != null ? networkManager.IsConnected : false;
                if(isConnected && !IsConnected)
                {
                    OnRefreshReception(null);
                }

                return true;
            } );

            OnRefreshReception(null);
        }

        public bool IsRefreshing { get; set; }

        public ICommand RefreshCommand => new Command(OnRefreshReception);

        private async void OnRefreshReception(object obj)
        {
            IPFinder.Start();

            await Task.Delay(2000);
            IsRefreshing = false;

            DeviceInterface = null;
        }

        public DeviceInterface DeviceInterface { get; set; }

        public bool IsConnected { get; set; }

        public ICommand ConnectCommand => new Command(OnConnected);

        private async void OnConnected(object obj)
        {
            IsConnected = true;
            return;

            if (DeviceInterface != null)
            {
                networkManager = new ChroZenGC.Core.Network.TCPManager(Model) { Host = DeviceInterface.IPAddress };
                await networkManager.ConnectAsync();
                if (networkManager.IsConnected)
                {
                    networkManager.WaitAsync();

                    await Model.Send(Model.Information);
                    await Model.Request(Model.Information);
                    await Model.Request(Model.Configuration);
                    await Model.Request(Model.Oven);
                }
            }
        }


        //public ICommand StopCommand => new Command(OnStopCommand);

        //private async void OnStopCommand(object obj)
        //{
        //    if (networkManager != null)
        //    {
        //        networkManager.Close();
        //        networkManager = null;
        //    }
        //    else
        //    {
        //        networkManager = new ChroZenGC.Core.Network.TCPManager(Model) { Host = "192.168.0.88" };
        //        await networkManager.ConnectAsync();
        //        if (networkManager.IsConnected)
        //        {
        //            networkManager.WaitAsync();

        //            await Model.Send(Model.Information);
        //            await Model.Request(Model.Information);
        //            await Model.Request(Model.Configuration);
        //            await Model.Request(Model.Oven);

        //        }
        //    }
        //}
    }
}
