using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _InletTempProgramWrapper : StructureWrapper<_InletTempProgram>
    {
        public _InletTempProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_InletTempProgram> provider) : base(parent, provider)
        {
        }
        public float Rate
        {
            get => Provider.fRate;
            set => Provider.fRate = value;
        }

        public float FinalTemp
        {
            get => Provider.fFinalTemp;
            set => Provider.fFinalTime = value;
        }

        public float FinalTime
        {
            get => Provider.fFinalTime;
            set => Provider.fFinalTime = value;
        }
    }

    public class _ApcFlowProgramWrapper : StructureWrapper<_ApcFlowProgram>
    {
        public _ApcFlowProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_ApcFlowProgram> provider) : base(parent, provider)
        {

        }

        public float Rate
        {
            get => Provider.fRate;
            set => Provider.fRate = value;
        }

        public float FinalFlow
        {
            get => Provider.fFinalFlow;
            set => Provider.fFinalTime = value;
        }

        public float FinalTime
        {
            get => Provider.fFinalTime;
            set => Provider.fFinalTime = value;
        }
    }

    public class _ApcPressProgramWrapper : StructureWrapper<_ApcPressProgram>
    {
        public _ApcPressProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_ApcPressProgram> provider) : base(parent, provider)
        {
        }

        public float Rate
        {
            get => Provider.fRate;
            set => Provider.fRate = value;
        }

        public float FinalFlow
        {
            get => Provider.fFinalPress;
            set => Provider.fFinalTime = value;
        }

        public float FinalTime
        {
            get => Provider.fFinalTime;
            set => Provider.fFinalTime = value;
        }
    }

    public class InletSetupWrapper : PacketWrapper<InletSetup>
    {
        public const uint PacketCode = 0x67130;
        public override uint Code => PacketCode;

        public InletSetupWrapper()
        {
            Packet.tempPrgm = new _InletTempProgram[6];
            Packet.flowPrgm = new _ApcFlowProgram[6];
            Packet.presPrgm = new _ApcPressProgram[6];

            for (int i = 0; i < 6; ++i)
            {
                int j = i;
                TempProgram.Add(new _InletTempProgramWrapper(this, () => ref Packet.tempPrgm[j]));
                FlowProgram.Add(new _ApcFlowProgramWrapper(this, () => ref Packet.flowPrgm[j]));
                PressProgram.Add(new _ApcPressProgramWrapper(this, () => ref Packet.presPrgm[j]));
            }

            SplitRatio = 10;
            SplitOnTime = 1.0f;
            SplitFlowSet = 27.0f;
            TotalFlowSet = 33;
            Length = 30;
            Diameter = 0.32f;
            Thickness = 0.25f;
            ColumnFlowSet = 3.0f;
        }

        protected override void OnPrePropertyModified(object sender, PropertyChangedEventArgs args)
        {
            base.OnPrePropertyModified(sender, args);

            switch(args.PropertyName)
            {
                case nameof(PressureCorrectOn):
                    VaccumCorrect = PressureCorrectOn ? false : VaccumCorrect;
                    break;
                case nameof(VaccumCorrect):
                    PressureCorrectOn = VaccumCorrect ? false : PressureCorrectOn;
                    break;
                case nameof(SplitRatio):
                    SplitFlowSet = SplitRatio * ColumnFlowSet;
                    TotalFlowSet = ColumnFlowSet + SplitFlowSet + 3.0f;
                    break;
                case nameof(SplitFlowSet):
                    ColumnFlowSet = SplitFlowSet / SplitRatio;
                    TotalFlowSet = ColumnFlowSet + SplitFlowSet + 3.0f;
                    break;
                case nameof(TotalFlowSet):
                    ColumnFlowSet = Math.Max(0.0f, TotalFlowSet - 3.0f) / (1 + SplitRatio);
                    SplitFlowSet = SplitRatio * ColumnFlowSet;
                    break;
                case nameof(ColumnFlowSet):
                    SplitFlowSet = SplitRatio * ColumnFlowSet;
                    TotalFlowSet = ColumnFlowSet + SplitFlowSet;
                    break;
            }
        }

        public int PortNo
        {
            get => Provider.btPortNo;
            set => Provider.btPortNo = (byte)value;
        }

        public GasTypes CarrierGas
        {
            get => Provider.btCarriergas;
            set => Provider.btCarriergas = value;
        }

        public APCModes APCMode
        {
            get => Provider.btApcMode;
            set => Provider.btApcMode = value;
        }

        public InletConnection Connection
        {
            get => Provider.btConnection;
            set => Provider.btConnection = value;
        }

        public float Length
        {
            get => Provider.fLength;
            set => Provider.fLength = value;
        }

        public float Diameter
        {
            get => Provider.fDiameter;
            set => Provider.fDiameter = value;
        }

        public float Thickness
        {
            get => Provider.fThickness;
            set => Provider.fThickness = value;
        }

        public bool GasSaverOn
        {
            get => Provider.bGasSaverMode != 0;
            set => Provider.bGasSaverMode = (byte)(value ? 1 : 0);
        }

        public float GasSaverTime
        {
            get => Provider.fGasSaverTime;
            set => Provider.fGasSaverTime = value;
        }

        public float GasSaverFlow
        {
            get => Provider.fGasSaverFlow;
            set => Provider.fGasSaverFlow = value;
        }

        public bool PressureCorrectOn
        {
            get => Provider.bPressCorrect != 0;
            set => Provider.bPressCorrect = (byte)(value ? 1 : 0);
        }

        public float PressureCorrect
        {
            get => Provider.fPressCorrect;
            set => Provider.fPressCorrect = value;
        }

        public bool VaccumCorrect
        {
            get => Provider.bVacuumCorrect != 0;
            set => Provider.bVacuumCorrect = (byte)(value ? 1 : 0);
        }

        public TempModes TempMode
        {
            get => Provider.btTempMode;
            set => Provider.btTempMode = value;
        }

        public float TempSet
        {
            get => Provider.fTempSet;
            set => Provider.fTempSet = value;
        }

        public bool TempOnOff
        {
            get => Provider.fTempOnoff != 0;
            set => Provider.fTempOnoff = (byte)(value ? 1 : 0);
        }

        public InjectModes InjectMode
        {
            get => Provider.btInjMode;
            set => Provider.btInjMode = value;
        }

        public float ColumnFlowSet
        {
            get => Provider.fColumnFlowSet;
            set => Provider.fColumnFlowSet = value;
        }

        public bool ColumnFlowOnOff
        {
            get => Provider.fColumnFlowOnoff != 0;
            set => Provider.fColumnFlowOnoff = (byte)(value ? 1 : 0);
        }

        public float PressureSet
        {
            get => Provider.fPressureSet;
            set => Provider.fPressureSet = value;
        }

        public bool PressureOnOff
        {
            get => Provider.fPressureOnoff != 0;
            set => Provider.fPressureOnoff = (byte)(value ? 1 : 0);
        }

        public int SplitRatio
        {
            get => Provider.iSplitratio;
            set => Provider.iSplitratio = (short)value;
        }

        public float Pulsed_FlowPressSet
        {
            get => Provider.fPulsed_FlowPressSet;
            set => Provider.fPulsed_FlowPressSet = value;
        }

        public float Pulsed_Time
        {
            get => Provider.fPulsed_Time;
            set => Provider.fPulsed_Time = value;
        }

        public float SplitFlowSet
        {
            get => Provider.fSplitFlowSet;
            set => Provider.fSplitFlowSet = value;
        }

        public float SplitOnTime
        {
            get => Provider.fSplitOnTime;
            set => Provider.fSplitOnTime = value;
        }

        public float TotalFlowSet
        {
            get => Provider.fTotalFlowSet;
            set => Provider.fTotalFlowSet = value;
        }

        public bool TotalFlowOnOff
        {
            get => Provider.fTotalFlowOnoff != 0;
            set => Provider.fTotalFlowOnoff = (byte)(value ? 1 : 0);
        }

        public ObservableCollection<_InletTempProgramWrapper> TempProgram = new ObservableCollection<_InletTempProgramWrapper>();

        public ObservableCollection<_ApcFlowProgramWrapper> FlowProgram = new ObservableCollection<_ApcFlowProgramWrapper>();

        public ObservableCollection<_ApcPressProgramWrapper> PressProgram = new ObservableCollection<_ApcPressProgramWrapper>();

    }
}
