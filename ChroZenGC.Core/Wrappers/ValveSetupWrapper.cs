using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _ValveProgramWrapper : StructureWrapper<_ValveProgram>
    {
        public _ValveProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_ValveProgram> func)
            : base(parent, func)
        {
            Valve = ValvePosition.Delete;
        }

        public float Time
        {
            get => Provider.fTime;
            set => Provider.fTime = value;
        }

        public ValvePosition Valve
        {
            get => Provider.btNumber;
            set => Provider.btNumber = value;
        }

        public int State
        {
            get => Provider.btState;
            set => Provider.btState = (byte)value;
        }

        public bool On
        {
            get => Provider.btState != 0;
            set => Provider.btState = (byte)(value ? 1 : 0);
        }
    }


    public class ValveSetupWrapper : PacketWrapper<ValveSetup>
    {
        public const uint PacketCode = 0x67150;
        public override uint Code => PacketCode;

        public ValveSetupWrapper()
        {
            Packet.bInitState = new byte[8];
            Packet.btMultiInitState = new byte[2];
            Packet.Prgm = new _ValveProgram[20];

            InitValveOnOff = new ArrayWrapper<byte>(this, () => Packet.bInitState);
            InitMultiValve = new ArrayWrapper<byte>(this, () => Packet.btMultiInitState);

            for (int i = 0; i < 20; ++i)
            {
                int j = i;
                Program.Add(new _ValveProgramWrapper(this, () => ref Packet.Prgm[j]));
            }
        }

        public ArrayWrapper<byte> InitValveOnOff { get; }

        public ArrayWrapper<byte> InitMultiValve { get; }

        public ObservableCollection<_ValveProgramWrapper> Program = new ObservableCollection<_ValveProgramWrapper>();
    }
}
