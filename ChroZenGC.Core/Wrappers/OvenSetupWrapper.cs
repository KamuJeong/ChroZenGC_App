using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class OvenSetupWrapper : PacketWrapper<OvenSetup>
    {
        public const uint PacketCode = 0x67120;
        public override uint Code => PacketCode;








        public float TotalRunTime => 10.0f;

        public IEnumerable<ValueTuple<float, float>> ProgramPoints
        {
            get 
            {
                yield return (0.0f, 50.0f);
                yield return (5.0f, 300.0f);
            }
        }
    }
}
