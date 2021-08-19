using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class CommandWrapper : PacketWrapper<GCCommand>
    {
        public const uint PacketCode = 0x67520;
        public override uint Code => PacketCode;

        public CommandWrapper(CommandCodes code, byte sub1 = 0, byte sub2 = 0)
        {
            Packet.btCommand = code;
            Packet.btSubCommand1 = sub1;
            Packet.btSubCommand2 = sub2;
        }
    }
}
