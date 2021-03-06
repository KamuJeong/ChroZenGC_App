using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _CurrentTemperatureWrapper : StructureWrapper<_CurrentTemperature>
    {
        public _CurrentTemperatureWrapper(INotifyPropertyChanged parent, ReferenceProvider<_CurrentTemperature> func)
            : base(parent, func)
        {
            Provider.fInj = new float[3];
            Provider.fInjSet = new float[3];
            Provider.fDet = new float[3];
            Provider.fAux = new float[8];
            Provider.fExt = new float[2];

            Inlet = new ArrayWrapper<float>(this, () => Provider.fInj);
            InletSet = new ArrayWrapper<float>(this, () => Provider.fInjSet);
            Detector = new ArrayWrapper<float>(this, () => Provider.fDet);
            Aux = new ArrayWrapper<float>(this, () => Provider.fAux);
            Ext = new ArrayWrapper<float>(this, () => Provider.fExt);
        }

        public float Oven
        {
            get => Provider.fOven;
            set => Provider.fOven = value;
        }

        public ArrayWrapper<float> Inlet { get; }

        public ArrayWrapper<float> InletSet { get; }

        public ArrayWrapper<float> Detector { get;  }

        public ArrayWrapper<float> Aux { get; }

        public ArrayWrapper<float> Ext { get; }
    }

    public class _CurrentFlowWrapper : StructureWrapper<_CurrentFlow>
    {
        public _CurrentFlowWrapper(INotifyPropertyChanged parent, ReferenceProvider<_CurrentFlow> func)
            : base(parent, func)
        {
            Provider.Disp_Press = new float[3];
            Provider.Disp_FrontInjFlow = new float[4];
            Provider.Disp_CenterInjFlow = new float[4];
            Provider.Disp_RearInjFlow = new float[4];
            Provider.Disp_Velocity_Inj = new float[3];
            Provider.Disp_Setflow = new float[3];
            Provider.Disp_Setpress = new float[3];
            Provider.Disp_FrontDetFlow = new float[3];
            Provider.Disp_CenterDetFlow = new float[3];
            Provider.Disp_RearDetFlow = new float[3];
            Provider.Disp_Aux1Flow = new float[3];
            Provider.Disp_Aux2Flow = new float[3];
            Provider.Disp_Aux3Flow = new float[3];

            Pressure = new ArrayWrapper<float>(this, () => Provider.Disp_Press);

            Inlets = new ObservableCollection<ArrayWrapper<float>>
            {
                new ArrayWrapper<float>(this, () => Provider.Disp_FrontInjFlow),
                new ArrayWrapper<float>(this, () => Provider.Disp_CenterInjFlow),
                new ArrayWrapper<float>(this, () => Provider.Disp_RearInjFlow)
            };

            Velocity = new ArrayWrapper<float>(this, () => Provider.Disp_Velocity_Inj);
            SetFlow = new ArrayWrapper<float>(this, () => Provider.Disp_Setflow);
            SetPressure = new ArrayWrapper<float>(this, () => Provider.Disp_Setpress);

            Detectors = new ObservableCollection<ArrayWrapper<float>>
            {
                new ArrayWrapper<float>(this, () => Provider.Disp_FrontDetFlow),
                new ArrayWrapper<float>(this, () => Provider.Disp_CenterDetFlow),
                new ArrayWrapper<float>(this, () => Provider.Disp_RearDetFlow)
            };


            AuxUPC1 = new ArrayWrapper<float>(this, () => Provider.Disp_Aux1Flow);
            AuxUPC2 = new ArrayWrapper<float>(this, () => Provider.Disp_Aux2Flow);
            AuxUPC3 = new ArrayWrapper<float>(this, () => Provider.Disp_Aux3Flow);
        }

        public ObservableCollection<ArrayWrapper<float>> Inlets { get; }

        public ArrayWrapper<float> Pressure { get; }

        public ArrayWrapper<float> Velocity { get; }

        public ArrayWrapper<float> SetFlow { get; }

        public ArrayWrapper<float> SetPressure { get; }

        public ObservableCollection<ArrayWrapper<float>> Detectors { get; }

        public ArrayWrapper<float> AuxUPC1 { get; }
        public ArrayWrapper<float> AuxUPC2 { get; }
        public ArrayWrapper<float> AuxUPC3 { get; }

    }

    public class StateWrapper : PacketWrapper<State>
    {
        public const uint PacketCode = 0x67500;

        public override uint Code => PacketCode;

        public _CurrentTemperatureWrapper Temperature { get; }

        public _CurrentFlowWrapper Flow { get; }


        public StateWrapper()
        {
            Temperature = new _CurrentTemperatureWrapper(this, () => ref Packet.ActTemp);
            Flow = new _CurrentFlowWrapper(this, () => ref Packet.ActFlow);

            Packet.btGasSaver = new byte[3];
            Packet.btCurSignal = new byte[3];
            Packet.btCurPolarity = new byte[3];
            Packet.fSignal = new float[3];
            Packet.btValveState = new byte[3];
            Packet.btMultiValveState = new byte[2];

            GasSaver = new ArrayWrapper<byte>(this, () => Packet.btGasSaver);
            CurrentSignal = new ArrayWrapper<byte>(this, () => Packet.btCurSignal);
            CurrentPolarity = new ArrayWrapper<byte>(this, () => Packet.btCurPolarity);
            Signal = new ArrayWrapper<float>(this, () => Packet.fSignal);
            ValveState = new ArrayWrapper<byte>(this, () => Packet.btValveState);
            MultiValveState = new ArrayWrapper<byte>(this, () => Packet.btMultiValveState);

            Mode = Modes.NotConnected;
        }

        public Modes Mode
        {
            get => (Modes)((byte)Packet.btState & 0x7F);
            set => Packet.btState = value;
        }

        public int ProgramStep
        {
            get => Packet.btPrgmStep;
            set => Packet.btPrgmStep = (byte)value;
        }

        public float RunTime
        {
            get => Packet.fRunTime;
            set => Packet.fRunTime = value;
        }

        public bool IsRepeatRun
        {
            get => Packet.bRepeatRun != 0;
            set => Packet.bRepeatRun = (byte)(value ? 1 : 0);
        }

        public uint CurrentRun
        {
            get => Packet.iCurrentRun;
            set => Packet.iCurrentRun = value;
        }

        public byte ErrorCode
        {
            get => Packet.btErrorCode;
            set => Packet.btErrorCode = value;
        }

        public ArrayWrapper<byte> GasSaver { get;  }

        public ArrayWrapper<byte> CurrentSignal { get; }

        public ArrayWrapper<byte> CurrentPolarity { get; }

        public TemperatureFlags TempReady
        {
            get => Packet.TempReady;
            set => Packet.TempReady = value;
        }

        public TemperatureFlags TempOnOff
        {
            get => Packet.TempOnoff;
            set => Packet.TempOnoff = value;
        }

        public FlowFlags FlowReady
        {
            get => Packet.FlowReady;
            set => Packet.FlowReady = value;
        }

        public FlowFlags FlowOnOff
        {
            get => Packet.FlowOnoff;
            set => Packet.FlowOnoff = value;
        }

        public ArrayWrapper<float> Signal { get; }

        public ArrayWrapper<byte> ValveState { get; }

        public ArrayWrapper<byte> MultiValveState { get; }

        public byte Step
        {
            get => Packet.btStep;
            set => Packet.btStep = value;
        }

    }
}
