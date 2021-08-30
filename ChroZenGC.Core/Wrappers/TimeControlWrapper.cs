using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _TimeProgramWrapper : StructureWrapper<_TimeProgram>
    {
        public _TimeProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_TimeProgram> provider) : base(parent, provider)
        {
            
        }

        public bool EveryDay
        {
            get => Provider.bDaily != 0;
            set => Provider.bDaily = (byte)(value ? 1 : 0);
        }

        public DateTime Date
        {
            get
            {
                try
                {
                    return new DateTime(Provider.SysTime.wYear, Provider.SysTime.wMonth, Provider.SysTime.wDay);
                }
                catch
                {
                    return new DateTime(2020, 1, 1);
                }
            }
            set
            {
                Provider.SysTime.wYear = (ushort)value.Year;
                Provider.SysTime.wMonth = (ushort)value.Month;
                Provider.SysTime.wDay = (ushort)value.Day;
            }
        }

        public TimeSpan Time
        {
            get
            {
                return new TimeSpan(Provider.SysTime.wHour, Provider.SysTime.wMinute, 0);
            }
            set
            {
                Provider.SysTime.wHour = (ushort)value.Hours;
                Provider.SysTime.wMinute = (ushort)value.Minutes;
                Provider.SysTime.wSecond = 0;
            }
        }


        public TimeFunctions Function
        {
            get => Provider.btFunction;
            set
            {
                if(Provider.btFunction == TimeFunctions.None && value != TimeFunctions.None)
                {
                    Date = DateTime.Today;
                    Time = DateTime.Now.TimeOfDay;
                }
                Provider.btFunction = value;
            }
        }

        public float Value
        {
            get => Provider.fValue;
            set => Provider.fValue = value;
        }

        internal void Update()
        {
            OnPropertyChanged(null);
        }
    }



    public class TimeControlWrapper : PacketWrapper<TimeControlSetup>
    {
        public const uint PacketCode = 0x67371;
        public override uint Code => PacketCode;

        public TimeControlWrapper()
        {
            Packet.Prgm = new _TimeProgram[20];

            for(int i=0; i<20; ++i)
            {
                int j = i;

                Program.Add(new _TimeProgramWrapper(this, () => ref Packet.Prgm[j]));
            }
        }

        protected override void OnPrePropertyModified(object sender, PropertyModifiedEventArgs args)
        {
            base.OnPrePropertyModified(sender, args);

            if(args.PropertyName == "Binary")
            {
                foreach (var p in Program)
                    p.Update();
            }

            foreach (var p in Program)
            {
                if(p.Function == TimeFunctions.None)
                {
                    p.EveryDay = false;
                    p.Date = new DateTime(2020, 1, 1);
                    p.Time = new TimeSpan(0, 0, 0);
                    p.Value = 0;
                }
            }

        }

        public ObservableCollection<_TimeProgramWrapper> Program { get; } = new ObservableCollection<_TimeProgramWrapper>();
    }
}
