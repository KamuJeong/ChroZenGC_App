using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class DiagCommandWrapper : PacketWrapper<DiagCommand>
    {
        public const uint PacketCode = 0x67900;
        public override uint Code => PacketCode;

        public DiagCommandWrapper(bool start, DiagTarget target)
        {
            Packet.bStartStop = start;
            Packet.btFunc = target;
        }
    }
}
