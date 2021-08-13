using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using PropertyChanged;

namespace ChroZenGC.Core.Wrappers
{
    public delegate ref T ReferenceProvider<T>() where T : struct;

    public class PropertyModifiedEventArgs : PropertyChangedEventArgs
    {
        public Wrapper Source { get; }

        public PropertyModifiedEventArgs(Wrapper source, string propertyName) : base(propertyName)
        {
            Source = source;
        }
    }

    public class Wrapper
    {
        public INotifyPropertyChanged Parent { get; }

        public Wrapper(INotifyPropertyChanged parent) => Parent = parent;

        protected virtual void NotifyToParent(object s, PropertyChangedEventArgs args)
        {
            if (Parent is Wrapper wrapper)
            {
                if (args is PropertyModifiedEventArgs e)
                {
                    wrapper.NotifyToParent(s, new PropertyModifiedEventArgs(e.Source, GetType().Name + ">" + args.PropertyName));
                }
                else
                {
                    wrapper.NotifyToParent(s, new PropertyChangedEventArgs(GetType().Name + ">" + args.PropertyName));
                }
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
            PropertyChanged?.Invoke(this, new PropertyModifiedEventArgs(this, propertyName));
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
                    PropertyChanged?.Invoke(this, new PropertyModifiedEventArgs(this, null));
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

        [DoNotNotify]
        public int SequenceOfModification { get; set; } = 0;

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

            if (args.PropertyName == null)
            {
                if (args is PropertyModifiedEventArgs e)
                {
                    args = new PropertyModifiedEventArgs(e.Source, string.Empty);
                }
                else
                {
                    args = new PropertyModifiedEventArgs(null, string.Empty);
                }
            }

            blockPropertyModifiedEvent = true;
            OnPrePropertyModified(sender, args as PropertyModifiedEventArgs);
            blockPropertyModifiedEvent = false;

            PropertyModified?.Invoke(sender, args);
        }

        protected virtual void OnPrePropertyModified(object sender, PropertyModifiedEventArgs args)
        {

        }
    }
}
