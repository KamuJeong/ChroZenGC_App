using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using PropertyChanged;

namespace ChroZenGC.Core.Wrappers
{
    public delegate ref T ReferenceProvider<T>() where T : struct;

    public class Wrapper
    {
        public INotifyPropertyChanged Parent { get; }

        public Wrapper(INotifyPropertyChanged parent) => Parent = parent;

        protected virtual void NotifyToParent(object s, PropertyChangedEventArgs args)
        {
            if (Parent is Wrapper wrapper)
            {
                wrapper.NotifyToParent(s, new PropertyChangedEventArgs(GetType().Name + ">" + args.PropertyName));
            }
        }
    }


    public abstract class StructureWrapper<T> : Wrapper, INotifyPropertyChanged where T : struct
    {
        protected ReferenceProvider<T> referenceProvider;

        protected ref T Provider => ref referenceProvider.Invoke();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected StructureWrapper(INotifyPropertyChanged parent) : base(parent)
        {
            PropertyChanged += NotifyToParent;
        }

        public StructureWrapper(INotifyPropertyChanged parent, ReferenceProvider<T> provider) : this(parent)
            => referenceProvider = provider ?? throw new ArgumentNullException(nameof(provider));

    }

    public class ArrayWrapper<T> : Wrapper, INotifyPropertyChanged, IEnumerable<T>
    {
        private Func<T[]> arrayProvider;

        protected T[] Provider => arrayProvider.Invoke();

        public ArrayWrapper(INotifyPropertyChanged parent, Func<T[]> provider) : base(parent)
        {
            arrayProvider = provider ?? throw new ArgumentNullException(nameof(provider));
            PropertyChanged += NotifyToParent;
        }

        [DoNotNotify]
        public T this[int index]
        {
            get => Provider[index];
            set
            {
                if (!Provider[index].Equals(value))
                {
                    Provider[index] = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }

        public int Length => Provider.Length;

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerator<T> GetEnumerator() { foreach (T v in Provider) yield return v; }

        IEnumerator IEnumerable.GetEnumerator() => Provider.GetEnumerator();
    }

    public abstract class PacketWrapper<TPacket> : StructureWrapper<TPacket> where TPacket : struct
    {
        private TPacket packet;

        public ref TPacket Packet => ref Provider;

        public PacketWrapper() : base(null)
        {
            referenceProvider = () => ref packet;
        }

        public abstract uint Code { get;  }

        [DoNotNotify]
        public byte[] Binary
        {
            get => this.ToBytes<TPacket>();
            set
            {
                packet = value.ConverTo<TPacket>();
                OnPropertyChanged(nameof(Binary));
                OnPropertyChanged(null);
            }
        }

        private bool blockPropertyModifiedEvent = false;

        public event PropertyChangedEventHandler PropertyModified;

        protected sealed override void NotifyToParent(object sender, PropertyChangedEventArgs args)
        {
            if (blockPropertyModifiedEvent)
                return;

            args = new PropertyChangedEventArgs(args.PropertyName ?? string.Empty);

            blockPropertyModifiedEvent = true;
            OnPrePropertyModified(sender, args.PropertyName == null? new PropertyChangedEventArgs("") : args);
            blockPropertyModifiedEvent = false;

            PropertyModified?.Invoke(sender, args);
        }

        protected virtual void OnPrePropertyModified(object sender, PropertyChangedEventArgs args)
        {

        }
    }
}
