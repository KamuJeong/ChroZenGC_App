using ChroZenGC.Core;
using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using ChroZenService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChroZenService
{
    public class ViewModel_System : Observable
    {
        public ViewModel_Root Root { get; set;  }

        public Model Model { get; }

        public InformationWrapper Informaton => Model.Information;

        public ConfigurationWrapper Configuration => Model.Configuration;

        public StateWrapper State => Model.State;

        public DiagSensorStateWrapper Sensor => Model.DiagSensor;

        public DiagPowerCheckWrapper Power => Model.DiagPowerCheck;

        public ViewModel_System_Calibration Calibration { get; }

        public IAboutAppInfo About { get; }


        public ViewModel_System(Model model, ViewModel_System_Calibration calib, IAboutAppInfo about)
        {
            Model = model;
            Calibration = calib;
            About = about;

            Model.Information.PropertyModified += OnInformationPropertyModified;

            IPAddress = Model.Information.IPAddress;
            NetworkMask = Model.Information.NetworkMask;
            GateWay = Model.Information.GateWay;

            State.PropertyModified += StatePropertyModified;
        }

        private void StatePropertyModified(object sender, PropertyChangedEventArgs e)
        {
            IsEditable = State.Mode switch { Modes.Ready => true, Modes.NotReady => true, Modes.NotConnected => true, _ => false };
        }

        public bool IsEditable { get; set; } = true;

        private void OnInformationPropertyModified(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Binary")
            {
                IPAddress = Model.Information.IPAddress;
                NetworkMask = Model.Information.NetworkMask;
                GateWay = Model.Information.GateWay;
            }
        }


        private int selectedItem = 1;
        public int SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                if (State.Mode == Modes.Diagnostics || State.Mode == Modes.Calibration)
                {
                    AbortTask();
                }
            }
        }


        private async void AbortTask() => await Model.Send(new CommandWrapper(CommandCodes.Stop));

        private bool isInSystemMode = false;
        public bool IsInSystemMode 
        {
            get => isInSystemMode;
            set
            {
                isInSystemMode = value;
                if (State.Mode == Modes.Diagnostics || State.Mode == Modes.Calibration)
                {
                    AbortTask();
                }
            }
        }

        public ICommand SetNetworkCommand => new Command(OnSetNetwork);

        private async void OnSetNetwork(object obj)
        {
            var information = new InformationWrapper();
            information.Version = "SetIP";
            try
            {
                information.IPAddress = IPAddress;
            }
            catch
            {
                await Resolver.Resolve<View_Root>().DisplayAlert("Alert", "IP address is not valid", "OK");
                IPAddress = Model.Information.IPAddress;
                return;
            }
            try
            {
                information.NetworkMask = NetworkMask;
            }
            catch
            {
                await Resolver.Resolve<View_Root>().DisplayAlert("Alert", "Netmask is not valid", "OK");
                NetworkMask = Model.Information.NetworkMask;
                return;
            }
            try
            {
                information.GateWay = GateWay;
            }
            catch
            {
                await Resolver.Resolve<View_Root>().DisplayAlert("Alert", "Gateway is not valid", "OK");
                GateWay = Model.Information.GateWay;
                return;
            }

            await Model.Send(information);

            Model.Information.IPAddress = IPAddress;
            Model.Information.NetworkMask = NetworkMask;
            Model.Information.GateWay = GateWay;

        }

        public ICommand SyncDateTimeCommand => new Command(SyncDateTime);

        private async void SyncDateTime(object commandParameter)
        {
            var dt = DateTime.Now;

            var information = new InformationWrapper();
            information.Version = "SetClock";
            information.Packet.SysConfig.SysTime.wYear = (ushort)dt.Year;
            information.Packet.SysConfig.SysTime.wMonth = (ushort)dt.Month;
            information.Packet.SysConfig.SysTime.wDay = (ushort)dt.Day;
            information.Packet.SysConfig.SysTime.wHour = (ushort)dt.Hour;
            information.Packet.SysConfig.SysTime.wMinute = (ushort)dt.Minute;
            information.Packet.SysConfig.SysTime.wSecond = (ushort)dt.Second;

            await Model.Send(information);

            Model.Information.TimeDiffernece = TimeSpan.Zero;
        }

        public string IPAddress { get; set; }

        public string NetworkMask { get; set; }

        public string GateWay { get; set; }

        public Predicate<Enum> DetectorFilter => (e) => !new List<DetectorTypes> { DetectorTypes.FPD_Not_used, DetectorTypes.NPD_Not_used, DetectorTypes.ECD }
                                                                .Any(n => object.Equals(n, e));

        public ICommand ColumnCleanCommand => new Command(ColumnClean);

        private async void ColumnClean(object obj)
        {
            switch (obj)
            {
                case string param when param == "Start":
                    await Model.Send(new CommandWrapper(CommandCodes.ColumnCondition));
                    break;
                case string param when param == "Stop":
                    await Model.Send(new CommandWrapper(CommandCodes.Stop));
                    break;
            }
        }

        public ICommand DiagStartCommand => new Command(DiagStart);

        private async void DiagStart(object obj)
        {
            if (obj is string num)
            {
                await Model.Send(new DiagCommandWrapper(true, (DiagTarget)int.Parse(num)));
            }
        }

        public ICommand DiagStopCommand => new Command(DiagStop);

        private async void DiagStop(object obj)
        {
            if (obj is string num)
            {
                await Model.Send(new DiagCommandWrapper(false, (DiagTarget)int.Parse(num)));
            }
        }

        public ICommand CloseCommand => new Command(Disconnect);

        private void Disconnect(object obj)
        {
            Root.networkManager?.Close();
            if (Root.IsActual == false)
            {
                Root.IsActual = true;
                Root.IsRefreshing = true;
                Root.RefreshCommand.Execute(null);
            }
        }
    }
}
