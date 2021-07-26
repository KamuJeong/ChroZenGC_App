using ChroZenGC.Core.Network;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChroZenGC.Core.Wrappers
{
    public static class PacketWrapperExtension
    {
        public static byte[] ToBytes(this Header head)
        {
            byte[] arr = new byte[24];
            IntPtr ptrHead = Marshal.AllocHGlobal(24);

            Marshal.StructureToPtr(head, ptrHead, false);
            Marshal.Copy(ptrHead, arr, 0, 24);
            Marshal.FreeHGlobal(ptrHead);

            return arr;
        }

        public static byte[] ToBytes<T>(this PacketWrapper<T> wrapper, ref Header head) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] arr = new byte[size + 24];
            IntPtr ptrHead = Marshal.AllocHGlobal(24);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(head, ptrHead, false);
            Marshal.StructureToPtr(wrapper.Packet, ptr, false);

            Marshal.Copy(ptrHead, arr, 0, 24);
            Marshal.Copy(ptr, arr, 24, size);

            Marshal.FreeHGlobal(ptrHead);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        public static byte[] ToBytes<T>(this PacketWrapper<T> wrapper) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(wrapper.Packet, ptr, false);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }


        public static T ConverTo<T>(this byte[] arr, int offset = 0) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));

            if (size > arr.Length - offset)
            {
                throw new ArgumentException(nameof(arr));
            }

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, offset, ptr, size);
            T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);

            return obj;
        }
    }
}
