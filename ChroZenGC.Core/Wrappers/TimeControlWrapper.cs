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

        public DateTime DateTime
        {
            get => new DateTime(Provider.SysTime.wYear, Provider.SysTime.wMonth, Provider.SysTime.wDay,
                                            Provider.SysTime.wHour, Provider.SysTime.wMinute, Provider.SysTime.wSecond);
            set
            {
                Provider.SysTime.wYear = (ushort)value.Year;
                Provider.SysTime.wMonth = (ushort)value.Month;
                Provider.SysTime.wDay = (ushort)value.Day;
                Provider.SysTime.wHour = (ushort)value.Hour;
                Provider.SysTime.wMinute = (ushort)value.Minute;
                Provider.SysTime.wSecond = (ushort)value.Second;
            }
        }
        public TimeFunctions Function
        {
            get => Provider.btFunction;
            set => Provider.btFunction = value;
        }

        public float Value
        {
            get => Provider.fValue;
            set => Provider.fValue = value;
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

        public ObservableCollection<_TimeProgramWrapper> Program { get; } = new ObservableCollection<_TimeProgramWrapper>();
    }
}
