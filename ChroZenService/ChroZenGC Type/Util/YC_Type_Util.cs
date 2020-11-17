using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public class YC_Type_Util
    {
        public static string GetString(char[] value)
        {
            try
            {
                //value 의 ff제거
                byte[] convertValue = value.ToList().Select(ch => (byte)(ch & (0xFF))).ToArray();       

                byte[] pbSource = Encoding.Convert(Encoding.GetEncoding("ks_c_5601-1987"), Encoding.UTF8, convertValue);   //CP949
                char[] psUnicode = UTF8Encoding.UTF8.GetChars(pbSource);
                string strReceiveText = new string(psUnicode);

                if (strReceiveText.IndexOf('\0') > 0)
                    strReceiveText = strReceiveText.Substring(0, strReceiveText.IndexOf('\0'));

                return strReceiveText;
            }
            catch (Exception ee)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0}r\n{1}", ee.StackTrace, ee.Message));
                return "";
            }
        }
        // Structure 정보를 Byte Array로 변환하는 함수
        public static byte[] StructToByte(object obj)
        {
            int nSize = Marshal.SizeOf(obj);
            byte[] arr = new byte[nSize];
            IntPtr ptr = Marshal.AllocHGlobal(nSize);

            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, nSize);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        // Byte Array를 Structure 로 변환하는 함수
        public static T ByteToStruct<T>(byte[] buffer) where T : struct
        {
            int nSize = Marshal.SizeOf(typeof(T));

            if (nSize > buffer.Length)
            {
                throw new Exception();
            }

            IntPtr ptr = Marshal.AllocHGlobal(nSize);
            Marshal.Copy(buffer, 0, ptr, nSize);
            T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);

            return obj;
        }

        public static char[] StringToCharArray(string str, int length)
        {

            if (str != null)
            {
                if (str.Length > length)
                { str = str.Substring(0, length); }
                return Encoding.ASCII.GetChars(Encoding.ASCII.GetBytes(str.PadRight(length, '\0')));
            }
            return null;
        }
    }
}
