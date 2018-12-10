using System;
using System.Collections.Generic;
using System.Text;

namespace Parallelspace.SerentityData
{
    public class Helpers
    {
        public static string ToHex(byte[] buffer)
        {
            string result = "0x";

            if (buffer == null) return "";

            Int32 length = buffer.Length;

            if (length == 0) return result;

            int chArrayLength = length * 2;

            char[] chArray = new char[chArrayLength];
            int i = 0;
            int index = 0;
            for (i = 0; i < chArrayLength; i += 2)
            {
                byte b = buffer[index++];
                chArray[i] = ToHexChar(b / 16);
                chArray[i + 1] = ToHexChar(b % 16);
            }

            result = (result + new String(chArray, 0, chArray.Length));

            return result;
        }

        public static string ToHex(string buffer, bool isUnicode = true)
        {
            string result = "";
            if (buffer == null) return result;

            Int16 length = (Int16)buffer.Length;

            result = "0x";
            if (length == 0) return result;

            char[] chArray;
            if (isUnicode)
            {
                int chArrayLength = length * 4;
                chArray = new char[chArrayLength];
                int index = 0;
                for (int i = 0; i < chArrayLength; i += 4)
                {
                    Int16 b = (Int16)buffer[index++];
                    chArray[i + 2] = ToHexChar((b / 16) & 0x0f);
                    chArray[i + 3] = ToHexChar((b % 16) & 0x0f);
                    b = (Int16)(b >> 8);
                    chArray[i + 0] = ToHexChar((b / 16) & 0x0f);
                    chArray[i + 1] = ToHexChar((b % 16) & 0x0f);
                }
            }
            else
            {
                int chArrayLength = length * 2;
                chArray = new char[chArrayLength];
                int index = 0;
                for (int i = 0; i < chArrayLength; i += 2)
                {
                    Int16 b = (Int16)buffer[index++];
                    chArray[i + 0] = ToHexChar((b / 16) & 0x0f);
                    chArray[i + 1] = ToHexChar((b % 16) & 0x0f);
                    b = (Int16)(b >> 8);
                    if (b != 0) // Unicode character in string
                    {
                        chArray[i + 0] = '?';
                        chArray[i + 1] = '?';
                    }
                }
            }

            result = (result + new String(chArray, 0, chArray.Length));

            return result;
        }

        private static char ToHexChar(int i)
        {
            if (i >= 0 && i < 16)
            {
                if (i < 10)
                {
                    return (char)(i + '0');
                }
                else
                {
                    return (char)(i - 10 + 'A');
                }
            }
            else
            {
                return '?';
            }
        }
    }
}
