using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _OvenProgramWrapper : StructureWrapper<_OvenProgram>
    {
        public _OvenProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_OvenProgram> func)
            : base(parent, func)
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

    public class _RunStartWrapper : StructureWrapper<_RunStart>
    {
        public _RunStartWrapper(INotifyPropertyChanged parent, ReferenceProvider<_RunStart> func)
            : base(parent, func)
        {

        }

        public bool OnOff
        {
            get => Provider.bOnoff != 0;
            set => Provider.bOnoff = (byte)(value ? 1 : 0);
        }

        public int Count
        {
            get => Provider.iCount;
            set => Provider.iCount = (ushort)value;
        }

        public float CycleTime
        {
            get => Provider.fCycletime;
            set => Provider.fCycletime = value;
        }
    }

    public class _PostRunWrapper : StructureWrapper<_PostRun>
    {
        public _PostRunWrapper(INotifyPropertyChanged parent, ReferenceProvider<_PostRun> func)
            : base(parent, func)
        {

        }
        public bool OnOff
        {
            get => Provider.bOnoff != 0;
            set => Provider.bOnoff = (byte)(value ? 1 : 0);
        }

        public float Temp
        {
            get => Provider.fTemp;
            set => Provider.fTemp = value;
        }

        public float Time
        {
            get => Provider.fTime;
            set => Provider.fTime = value;
        }
    }


    public class OvenWrapper : PacketWrapper<OvenSetup>
    {
        public const uint PacketCode = 0x67120;
        public override uint Code => PacketCode;

        public _OvenProgramWrapper[] Program { get; } = new _OvenProgramWrapper[25];

        public _RunStartWrapper RunStart { get; }

        public _PostRunWrapper PostRun { get; }

        public OvenWrapper()
        {
            Packet.Prgm = new _OvenProgram[25];
            for (int i = 0; i < 25; ++i)
            {
                int j = i;      // [IMPORTANT!!!]
                                // Closure should capture each local variable j, not outer variable i 

                Program[i] = new _OvenProgramWrapper(this, () => ref Packet.Prgm[j]);
            }
            RunStart = new _RunStartWrapper(this, () => ref Packet.Runstart);
            PostRun = new _PostRunWrapper(this, () => ref Packet.Postrun);

            MaxTemp = 450.0f;
            EquibTime = 1.0f;
            TempSet = 50.0f;
            InitTime = 10.0f;
            TotalRunTime = 10.0f;

            Points = new List<(float, float)> { (0.0f, 50.0f) };
        }

        protected sealed override void OnPrePropertyModified(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName.Split('>').FirstOrDefault();
            if (propertyName == "Binary" 
                || new string[] { nameof(Mode), nameof(InitTime), nameof(TempSet), nameof(_OvenProgramWrapper) }.Any(s => string.Equals(s, propertyName)))
            {
                // TotalRunTime & Points 계산
                float temp = TempSet;
                float total = InitTime;
                var pts = new List<ValueTuple<float, float>> { (0.0f, temp) };
                if (Mode == OvenMode.Program)
                {
                    foreach (var p in Program)
                    {
                        if (p.Rate <= 0.0f)
                            break;

                        pts.Add((total, temp));

                        total += Math.Abs((p.FinalTemp - temp) / p.Rate);
                        temp = p.FinalTemp;

                        pts.Add((total, temp));

                        total += p.FinalTime;
                    }
                }
                TotalRunTime = total;
                Points = pts;
            }
        }

        public float MaxTemp
        {
            get => Packet.fMaxTemp;
            set => Packet.fMaxTemp = value;
        }

        public float EquibTime
        {
            get => Packet.fEquibTime;
            set => Packet.fEquibTime = value;
        }

        public bool Cryogenic
        {
            get => Packet.bCryogenic != 0;
            set => Packet.bCryogenic = (byte)(value ? 1 : 0);
        }

        public Coolants Coolant
        {
            get => Packet.btCoolant;
            set => Packet.btCoolant = value;
        }

        public bool FastCryo
        {
            get => Packet.bFastCryo != 0;
            set => Packet.bFastCryo = (byte)(value ? 1 : 0);
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

        public float InitTime
        {
            get => Packet.fInitTime;
            set => Packet.fInitTime = value;
        }

        public OvenMode Mode
        {
            get => Packet.btMode;
            set => Packet.btMode = value;
        }

        public bool AutoReadyRun
        {
            get => Packet.bAutoReadyrun != 0;
            set => Packet.bAutoReadyrun = (byte)(value ? 1 : 0);
        }

        public float TotalRunTime
        {
            get => Packet.fTotalRunTime;
            set => Packet.fTotalRunTime = value;
        }

        public List<ValueTuple<float, float>> Points { get; set; }
    }
}
