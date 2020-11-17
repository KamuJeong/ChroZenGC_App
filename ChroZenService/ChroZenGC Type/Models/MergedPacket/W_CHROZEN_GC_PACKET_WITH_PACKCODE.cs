using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static YC_ChroZenGC_Type.YC_Const;

namespace YC_ChroZenGC_Type
{
    public interface I_CHROZEN_GC_PACKET
    {

    }

    public class W_CHROZEN_GC_PACKET_WITH_PACKCODE
    {
        public I_CHROZEN_GC_PACKET packet;
        public E_PACKCODE packcode;

        public W_CHROZEN_GC_PACKET_WITH_PACKCODE(I_CHROZEN_GC_PACKET ppacket, E_PACKCODE ppackcode)
        {
            packet = ppacket;
            packcode = ppackcode;
        }
    }
}
