using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class CalibStateWrapper : PacketWrapper<CalibState>
    {
        public const uint PacketCode = 0x67710;
        public override uint Code => PacketCode;

        public CalibStateWrapper()
        {
            Packet.InletSensorZeroState = new SensorZeroValveStates[3];
            Packet.DetectorSensorZeroState = new SensorZeroValveStates[3];
            Packet.AuxSensorZeroState = new SensorZeroValveStates[3];
            Packet.InletValveState = new SensorZeroValveStates[3];
            Packet.DetectorValveState = new SensorZeroValveStates[3];
            Packet.AuxValveState = new SensorZeroValveStates[3];
            Packet.FrontInletValveVoltage = new float[3];
            Packet.CenterInletValveVoltage = new float[3];
            Packet.RearInletValveVoltage = new float[3];
            Packet.FrontDetectorValveVoltage = new float[3];
            Packet.CenterDetectorValveVoltage = new float[3];
            Packet.RearDetectorValveVoltage = new float[3];
            Packet.Aux1ValveVoltage = new float[3];
            Packet.Aux2ValveVoltage = new float[3];
            Packet.Aux3ValveVoltage = new float[3];
            Packet.InletValveError = new ValveCalibErrors[9];
            Packet.DetectorValveError = new ValveCalibErrors[9];
            Packet.AuxValveError = new ValveCalibErrors[9];
            Packet.InletSensorVoltage = new float[9];
            Packet.DetectorSensorVoltage = new float[9];
            Packet.AuxSensorVoltage = new float[9];

            InletSensorZeroState = new ArrayWrapper<SensorZeroValveStates>(this, () => Packet.InletSensorZeroState);
            DetectorSensorZeroState = new ArrayWrapper<SensorZeroValveStates>(this, () => Packet.DetectorSensorZeroState);
            AuxSensorZeroState = new ArrayWrapper<SensorZeroValveStates>(this, () => Packet.AuxSensorZeroState);
            InletValveState = new ArrayWrapper<SensorZeroValveStates>(this, () => Packet.InletValveState);
            DetectorValveState = new ArrayWrapper<SensorZeroValveStates>(this, () => Packet.DetectorValveState);
            AuxValveState = new ArrayWrapper<SensorZeroValveStates>(this, () => Packet.AuxValveState);
            FrontInletValveVoltage = new ArrayWrapper<float>(this, () => Packet.FrontInletValveVoltage);
            CenterInletValveVoltage = new ArrayWrapper<float>(this, () => Packet.CenterInletValveVoltage);
            RearInletValveVoltage = new ArrayWrapper<float>(this, () => Packet.RearInletValveVoltage);
            FrontDetectorValveVoltage = new ArrayWrapper<float>(this, () => Packet.FrontDetectorValveVoltage);
            CenterDetectorValveVoltage = new ArrayWrapper<float>(this, () => Packet.CenterDetectorValveVoltage);
            RearDetectorValveVoltage = new ArrayWrapper<float>(this, () => Packet.RearDetectorValveVoltage);
            Aux1ValveVoltage = new ArrayWrapper<float>(this, () => Packet.Aux1ValveVoltage);
            Aux2ValveVoltage = new ArrayWrapper<float>(this, () => Packet.Aux2ValveVoltage);
            Aux3ValveVoltage = new ArrayWrapper<float>(this, () => Packet.Aux3ValveVoltage);
            InletValveError = new ArrayWrapper<ValveCalibErrors>(this, () => Packet.InletValveError);
            DetectorValveError = new ArrayWrapper<ValveCalibErrors>(this, () => Packet.DetectorValveError);
            AuxValveError = new ArrayWrapper<ValveCalibErrors>(this, () => Packet.AuxValveError);
            InletSensorVoltage = new ArrayWrapper<float>(this, () => Packet.InletSensorVoltage);
            DetectorSensorVoltage = new ArrayWrapper<float>(this, () => Packet.DetectorSensorVoltage);
            AuxSensorVoltage = new ArrayWrapper<float>(this, () => Packet.AuxSensorVoltage);
        }

        public ArrayWrapper<SensorZeroValveStates> InletSensorZeroState { get; }
        public ArrayWrapper<SensorZeroValveStates> DetectorSensorZeroState { get; }
        public ArrayWrapper<SensorZeroValveStates> AuxSensorZeroState { get; }


        public ArrayWrapper<SensorZeroValveStates> InletValveState { get; }
        public ArrayWrapper<SensorZeroValveStates> DetectorValveState { get; }
        public ArrayWrapper<SensorZeroValveStates> AuxValveState { get; }

        public ArrayWrapper<float> FrontInletValveVoltage { get; }
        public ArrayWrapper<float> CenterInletValveVoltage { get; }
        public ArrayWrapper<float> RearInletValveVoltage { get; }

        public ArrayWrapper<float> FrontDetectorValveVoltage { get; }
        public ArrayWrapper<float> CenterDetectorValveVoltage { get; }
        public ArrayWrapper<float> RearDetectorValveVoltage { get; }

        public ArrayWrapper<ValveCalibErrors> InletValveError { get; }
        public ArrayWrapper<ValveCalibErrors> DetectorValveError { get; }
        public ArrayWrapper<ValveCalibErrors> AuxValveError { get; }

        public ArrayWrapper<float> Aux1ValveVoltage { get; }
        public ArrayWrapper<float> Aux2ValveVoltage { get; }
        public ArrayWrapper<float> Aux3ValveVoltage { get; }

        public ArrayWrapper<float> InletSensorVoltage { get; }
        public ArrayWrapper<float> DetectorSensorVoltage { get; }
        public ArrayWrapper<float> AuxSensorVoltage { get; }
    }
}
