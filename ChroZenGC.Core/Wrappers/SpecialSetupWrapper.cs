using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _ColumnConditionWrapper : StructureWrapper<_ColumnCondition>
    {
        public _ColumnConditionWrapper(INotifyPropertyChanged parent, ReferenceProvider<_ColumnCondition> func)
            : base(parent, func)
        {

        }

        public float InitTemp
        {
            get => Provider.fInitTemp;
            set => Provider.fInitTemp = value;
        }

        public float InitTime
        {
            get => Provider.fInitTime;
            set => Provider.fInitTime = value;
        }

        public float Rate
        {
            get => Provider.fRate;
            set => Provider.fRate = value;
        }

        public float FinalTemp
        {
            get => Provider.fFinalTemp;
            set => Provider.fFinalTemp = value;
        }

        public float FinalTime
        {
            get => Provider.fFinalTime;
            set => Provider.fFinalTime = value;
        }
    }

    public class _RemoteAccessWrapper : StructureWrapper<_RemoteAccess>
    {
        public _RemoteAccessWrapper(INotifyPropertyChanged parent, ReferenceProvider<_RemoteAccess> func)
            : base(parent, func)
        {

        }

        public float Duration
        {
            get => Provider.fTime;
            set => Provider.fTime = value;
        }

        public bool OnOff
        {
            get => Provider.bOnoff != 0;
            set => Provider.bOnoff = (byte)(value ? 1 : 0);
        }

        public float EventTime1
        {
            get => Provider.fEventTime1;
            set => Provider.fEventTime1 = value;
        }

        public float EventTime2
        {
            get => Provider.fEventTime2;
            set => Provider.fEventTime2 = value;
        }
    }


    public class SpecialSetupWrapper : PacketWrapper<SpecialSetup>
    {
        public const uint PacketCode = 0x67180;
        public override uint Code => PacketCode;

        public SpecialSetupWrapper()
        {
            ColumnCondition = new _ColumnConditionWrapper(this, () => ref Packet.ColumnClean);
            RemoteAccess = new _RemoteAccessWrapper(this, () => ref Packet.RemoteAccess);
        }


        _ColumnConditionWrapper ColumnCondition { get; }
        _RemoteAccessWrapper RemoteAccess { get; }
    }
}
