using ChroZenGC.Core;
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
    public class ViewModel_Root : Observable
    {
        public DeviceIPFinder IPFinder { get; set; }

        public INetworkManager networkManager { get; set; }

        public Model Model { get; }

        public string TimeTicker { get; set; }

        public int WatchdogTimer { get; set; }

        public bool IsActual { get; set; } = true;

        public ViewModel_Root(Model model, DeviceIPFinder finder)
        {
            Model = model;

            Model.Configuration.PropertyModified += OnConfigurationModified;
            Model.State.PropertyModified += OnStateModified;


            IPFinder = finder;
            Device.StartTimer(TimeSpan.FromSeconds(1.0), () =>
            {
                TimeTicker = DateTime.Now.ToString("T");
                Model.Information.UpdateDateTime();

                if (IsConnected && IsActual)
                {
                    if (++WatchdogTimer > 5)
                    {
                        networkManager?.Close();
                        WatchdogTimer = 0;
                    }
                }

                bool isConnected = IsConnected;
                IsConnected = networkManager != null ? networkManager.IsConnected : false;
                if(isConnected && !IsConnected)
                {
                    IsRefreshing = true;
                    OnRefreshReception(null);
                }

                return true;
            } );

            OnRefreshReception(null);
        }

        private void OnStateModified(object sender, PropertyChangedEventArgs e)
        {
            WatchdogTimer = 0;
        }

        private void OnConfigurationModified(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Binary")
            {
                Resolver.Resolve<View_Config>().Initialize();
                Resolver.Resolve<View_System>().Initialize();
            }
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

        private bool isConnected;
        public bool IsConnected 
        {
            get => !IsActual || isConnected;
            set
            {
                isConnected = value;
                if (!value)
                    IsActual = true;
            }
        }

        public ICommand ConnectCommand => new Command(OnConnected);

        private async void OnConnected(object obj)
        {
            IPFinder.Stop();

            IsActual = true;

            if (DeviceInterface != null)
            {
                if (DeviceInterface.SerialNumber == "DEMO")
                {
                    IsActual = false;
                    OnConfigurationModified(null, new PropertyChangedEventArgs("Binary"));
                }
                else
                {
                    await Connect(DeviceInterface.IPAddress, DeviceInterface.SerialNumber);
                }
            }
            else
            {
                var addr = await Resolver.Resolve<View_Root>().DisplayPromptAsync("Connection", "Input the device's address to which you would connect", keyboard: Keyboard.Url);
                if(addr == null)
                {
                    IsRefreshing = true;
                    OnRefreshReception(null);
                }
                else
                {
                    await Connect(addr, addr);
                }
            }

            async Task Connect(string addr, string serial)
            {
                try
                {
                    networkManager = new ChroZenGC.Core.Network.TCPManager(Model) { Host = addr };
                    await Task.WhenAny(Task.Delay(3000), networkManager.ConnectAsync());
                    if (networkManager.IsConnected)
                    {
                        networkManager.WaitAsync();

                        await Model.Send(new InformationWrapper());
                        await Model.Request(Model.Information);
                        await Model.Request(Model.Configuration);
                        await Model.Request(Model.Oven);
                        await Model.Request(Model.Inlets[0], 0);
                        await Model.Request(Model.Inlets[1], 1);
                        await Model.Request(Model.Inlets[2], 2);
                        await Model.Request(Model.Detectors[0], 0);
                        await Model.Request(Model.Detectors[1], 1);
                        await Model.Request(Model.Detectors[2], 2);
                        await Model.Request(Model.Signals[0], 0);
                        await Model.Request(Model.Signals[1], 1);
                        await Model.Request(Model.Signals[2], 2);
                        await Model.Request(Model.Valve);
                        await Model.Request(Model.Special);
                    }
                    else
                    {
                        networkManager.Close();
                        await Resolver.Resolve<View_Root>().DisplayAlert("Alert", $"'{serial}' has not responded", "OK");

                        IsRefreshing = true;
                        OnRefreshReception(null);
                    }
                }
                catch
                {
                }
            }
        }

        public ICommand StartCommand => new Command(OnStart);

        private async void OnStart(object obj)
        {
            await Model.Send(new CommandWrapper(CommandCodes.Start));
        }

        public ICommand StopCommand => new Command(OnStop);

        private async void OnStop(object obj)
        {
            await Model.Send(new CommandWrapper(CommandCodes.Stop));
        }

        public ICommand ReadyCommand => new Command(OnReady);

        private async void OnReady(object obj)
        {
            await Model.Send(new CommandWrapper(CommandCodes.ReadyRun));
        }
    }
}
