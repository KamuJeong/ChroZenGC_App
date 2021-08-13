using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _TCDPolarityProgramWrapper : StructureWrapper<_TCDPolarityProgram>
    {
        public _TCDPolarityProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_TCDPolarityProgram> provider) : base(parent, provider)
        {
            Provider.btPolarity = Polarity.Delete;
        }

        public float Time
        {
            get => Provider.fTime;
            set => Provider.fTime = value;
        }

        public Polarity Polarity
        {
            get => Provider.btPolarity;
            set => Provider.btPolarity = value;
        }
    }

    public class DetectorSetupWrapper : PacketWrapper<DetectorSetup>
    {
        public const uint PacketCode = 0x67140;
        public override uint Code => PacketCode;

        public DetectorSetupWrapper()
        {
            Packet.Prgm = new _TCDPolarityProgram[6];

            for(int i=0; i<6; ++i)
            {
                int j = i;
                PolarityProgram.Add(new _TCDPolarityProgramWrapper(this, () => ref Packet.Prgm[j]));
            }

            LitOffset = 0.005f;
            IgniteFlow = 100.0f;
            IgniteTemp = 240.0f;

            TempSet = 50.0f;
        }

        protected override void OnPrePropertyModified(object sender, PropertyModifiedEventArgs args)
        {
            base.OnPrePropertyModified(sender, args);

            PolarityProgram[5].Time = 0.0f;
            PolarityProgram[5].Polarity = Polarity.Delete;

            if(args.PropertyName == "_TCDPolarityProgramWrapper>Time")
            {
                if(args.Source is _TCDPolarityProgramWrapper p && p.Polarity == Polarity.Delete)
                {
                    p.Polarity = Polarity.Positive;
                }
                SortProgram();
            }
            else if(args.PropertyName == "_TCDPolarityProgramWrapper>Polarity")
            {
                if (args.Source is _TCDPolarityProgramWrapper p && p.Polarity == Polarity.Delete)
                {
                    SortProgram();
                }
            }
        }

        private void SortProgram()
        {
            var list = Packet.Prgm.Where(p => p.btPolarity != Polarity.Delete).OrderBy(p => p.fTime).ToList();
            var deleted = Packet.Prgm.Where(p => p.btPolarity == Polarity.Delete).ToList();

            for (int i = 0; i < deleted.Count; ++i)
                deleted[i] = new _TCDPolarityProgram { btPolarity = Polarity.Delete, fTime = 0.0f };

            list.AddRange(deleted);

            for (int j = 0; j < list.Count; ++j)
                Packet.Prgm[j] = list[j];
        }

        public int PortNo
        {
            get => Packet.btPort;
            set => Packet.btPort = (byte)value;
        }

        public GasTypes MakeupGas
        {
            get => Packet.btMakeupgas;
            set => Packet.btMakeupgas = value;
        }

        public float LitOffset
        {
            get => Packet.fLitoffset;
            set => Packet.fLitoffset = value;
        }

        public float IgniteDelay
        {
            get => Packet.fIgnitedelay;
            set => Packet.fIgnitedelay = value;
        }

        public float IgniteFlow
        {
            get => Packet.fIgniteflow;
            set => Packet.fIgniteflow = value;
        }

        public float IgniteTemp
        {
            get => Packet.fIgnitetemp;
            set => Packet.fIgnitetemp = value;
        }
        public DetectorConnection Connection
        {
            get => Packet.btConnection;
            set => Packet.btConnection = value;
        }

        public bool AutoZero
        {
            get => Packet.bAutozero != 0;
            set => Packet.bAutozero = (byte)(value ? 1 : 0);
        }

        public int SignalRange
        {
            get => Packet.iSignalrange;
            set => Packet.iSignalrange = (short)value;
        }

        public float TempSet
        {
            get => Packet.fTempSet;
            set => Packet.fTempSet = value;
        }

        public bool TempOnOff
        {
            get => Packet.bTempOnoff != 0;
            set => Packet.bTempOnoff = (byte)(value ? 1 : 0);
        }

        public bool ElectrometerOnOff
        {
            get => Packet.bElectrometer != 0;
            set => Packet.bElectrometer = (byte)(value ? 1 : 0);
        }

        public bool AutoIgnition
        {
            get => Packet.bAutoIgnition != 0;
            set => Packet.bAutoIgnition = (byte)(value ? 1 : 0);
        }

        public int ECDCurrent
        {
            get => Packet.iECDCurrentValue;
            set => Packet.iECDCurrentValue = (short)value;
        }

        public int SignalVariation
        {
            get => Packet.iSignalvariation;
            set => Packet.iSignalvariation = (short)value;
        }

        public float FlowSet1
        {
            get => Packet.fFlowSet1;
            set => Packet.fFlowSet1 = value;
        }

        public bool Flow1OnOff
        {
            get => Packet.bFlowOnoff1 != 0;
            set => Packet.bFlowOnoff1 = (byte)(value ? 1 : 0);
        }

        public float FlowSet2
        {
            get => Packet.fFlowSet2;
            set => Packet.fFlowSet2 = value;
        }

        public bool Flow2OnOff
        {
            get => Packet.bFlowOnoff2 != 0;
            set => Packet.bFlowOnoff2 = (byte)(value ? 1 : 0);
        }

        public float FlowSet3
        {
            get => Packet.fFlowSet3;
            set => Packet.fFlowSet3 = value;
        }

        public bool Flow3OnOff
        {
            get => Packet.bFlowOnoff3 != 0;
            set => Packet.bFlowOnoff3 = (byte)(value ? 1 : 0);
        }

        public bool BaselineCorrect
        {
            get => Packet.bBaselineCorrect != 0;
            set => Packet.bBaselineCorrect = (byte)(value ? 1 : 0);
        }

        public bool PolarityChange
        {
            get => Packet.bPolarChange != 0;
            set => Packet.bPolarChange = (byte)(value ? 1 : 0);
        }

        public InitPolarity InitialPolarity
        {
            get => Packet.btInitPola;
            set => Packet.btInitPola = value;
        }

        public int BeadVoltageSet
        {
            get => Packet.iBeadVoltageSet;
            set => Packet.iBeadVoltageSet = (byte)value;
        }

        public bool BeadVoltageOnOff
        {
            get => Packet.iBeadVoltageOnoff != 0;
            set => Packet.iBeadVoltageOnoff = (byte)(value ? 1 : 0);
        }

        public ObservableCollection<_TCDPolarityProgramWrapper> PolarityProgram = new ObservableCollection<_TCDPolarityProgramWrapper>();

        public int BlockSelect
        {
            get => Packet.btBlockSelect;
            set => Packet.btBlockSelect = (byte)value;
        }
    }
}
