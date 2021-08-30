using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class CalibTempSetWrapper : StructureWrapper<_CalibTempSet>
    {
        public CalibTempSetWrapper(INotifyPropertyChanged parent, ReferenceProvider<_CalibTempSet> func)
            : base(parent, func)
        {
            Reset();
        }

        public float Set1
        {
            get => Provider.Set1;
            set => Provider.Set1 = value;
        }

        public float Set2
        {
            get => Provider.Set2;
            set => Provider.Set2 = value;
        }

        public float Measure1
        {
            get => Provider.Measure1;
            set => Provider.Measure1 = value;
        }

        public float Measure2
        {
            get => Provider.Measure2;
            set => Provider.Measure2 = value;
        }

        public void Reset()
        {
            Set1 = Measure1 = 52.1f;
            Set2 = Measure2 = 211.3f;
        }
    }


    public class CalibOvenWrapper : PacketWrapper<CalibOven>
    {
        public const uint PacketCode = 0x67800;
        public override uint Code => PacketCode;

        public CalibOvenWrapper()
        {
            Set = new CalibTempSetWrapper(this, () => ref Packet.Set);
        }

        public CalibTempSetWrapper Set { get; }
    }
}
