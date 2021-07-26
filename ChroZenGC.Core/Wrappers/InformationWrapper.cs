using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class InformationWrapper : PacketWrapper<Information>
    {
        public const uint PacketCode = 0x67100;

        public override uint Code => PacketCode;


        public ref _SystemConfig SysConfig => ref Packet.SysConfig;

        public ref _Inst_Inform InstInfo => ref Packet.InstInfo;

        public string IPAddress => string.Format("{0}.{1}.{2}.{3}",
                    Packet.SysConfig.cIPAddress[0], Packet.SysConfig.cIPAddress[1],
                    Packet.SysConfig.cIPAddress[2], Packet.SysConfig.cIPAddress[3]);

        public string NetworkMask => string.Format("{0}.{1}.{2}.{3}",
                    Packet.SysConfig.cIPAddress[4], Packet.SysConfig.cIPAddress[5],
                    Packet.SysConfig.cIPAddress[6], Packet.SysConfig.cIPAddress[7]);

        public string GateWay => string.Format("{0}.{1}.{2}.{3}",
                    Packet.SysConfig.cIPAddress[8], Packet.SysConfig.cIPAddress[9],
                    Packet.SysConfig.cIPAddress[10], Packet.SysConfig.cIPAddress[11]);


        public InformationWrapper()
        {
            SysConfig.cIPAddress = new byte[16];
            InstInfo.InstVersion = "1.0.0";
        }
    }
}
