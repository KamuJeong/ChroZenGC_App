using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public class _SignalProgramWrapper : StructureWrapper<_SignalProgram>
    {
        public _SignalProgramWrapper(INotifyPropertyChanged parent, ReferenceProvider<_SignalProgram> provider) : base(parent, provider)
        {
        }

        public float Time
        {
            get => Provider.fTime;
            set => Provider.fTime = value;
        }

        public SignalDetectors Detector
        {
            get => Provider.btDet;
            set => Provider.btDet = value;
        }
    }


    public class SignalSetupWrapper : PacketWrapper<SignalSetup>
    {
        public const uint PacketCode = 0x67170;
        public override uint Code => PacketCode;

        public SignalSetupWrapper()
        {
            Packet.Prgm = new _SignalProgram[5];

            Packet.Prgm[0].btDet = SignalDetectors.RearDetector;

            for (int i = 0; i < 5; ++i)
            {
                int j = i;
                Program.Add(new _SignalProgramWrapper(this, () => ref Packet.Prgm[j]));
            }
        }

        protected override void OnPrePropertyModified(object sender, PropertyModifiedEventArgs args)
        {
            base.OnPrePropertyModified(sender, args);

            if (args.PropertyName == "_SignalProgramWrapper>Time")
            {
                if (args.Source is _SignalProgramWrapper p && p.Detector == SignalDetectors.Delete)
                {
                    p.Detector = SignalDetectors.FrontDetector;
                }
                SortProgram();
            }
            else if (args.PropertyName == "_SignalProgramWrapper>Detector")
            {
                if (args.Source is _SignalProgramWrapper p && p.Detector == SignalDetectors.Delete)
                {
                    SortProgram();
                }
            }
        }

        private void SortProgram()
        {
            var list = Packet.Prgm.Where(p => p.btDet != SignalDetectors.Delete).OrderBy(p => p.fTime).ToList();
            var deleted = Packet.Prgm.Where(p => p.btDet == SignalDetectors.Delete).ToList();

            for (int i = 0; i < deleted.Count; ++i)
                deleted[i] = new _SignalProgram { btDet = SignalDetectors.Delete, fTime = 0.0f };

            list.AddRange(deleted);

            for (int j = 0; j < list.Count; ++j)
                Packet.Prgm[j] = list[j];
        }

        public int PortNo
        {
            get => Packet.btPort;
            set => Packet.btPort = (byte)value;
        }
        
        public float Sensitivity
        {
            get => Packet.fSensitivity;
            set => Packet.fSensitivity = value;
        }

        public float Zero
        {
            get => Packet.fZero;
            set => Packet.fZero = value;
        }

        public bool SignalChange
        {
            get => Packet.bSignalChange != 0;
            set => Packet.bSignalChange = (byte)( value ? 1 : 0);
        }

        public InitSignalDetectors InitialDetector
        {
            get => Packet.btInitDet;
            set => Packet.btInitDet = value;
        }

        public ObservableCollection<_SignalProgramWrapper> Program = new ObservableCollection<_SignalProgramWrapper>();

    }
}
