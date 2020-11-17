using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public class YC_CommonModel
    {
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
