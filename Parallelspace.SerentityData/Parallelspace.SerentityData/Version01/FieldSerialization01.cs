using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Parallelspace.SerentityData
{
    public struct FieldSerialization01
    {
        public const byte FIELDSERIALIZATION_VERSION = 0x01; // Version 0.1

        public enum FieldType
        {
            _EnumZeroNotUsed, UInt16, UInt32, UInt64, Int16, Int32, Int64, Byte, SByte, Boolean, Char, ByteArray16, ByteArray32, String, ASCIIString, Enum, Address, Unknown
        }

        internal const int __HEADER_FIELDTYPE = 0;
        internal const int __HEADER_ENDCODEDLENGTH = 1;

        internal const int __HEADER16_LENGTH = sizeof(byte) + sizeof(Int16); // FIELDTYPE, ENCODEDLENGTH
        internal const Int16 __ENCODED16_NULL = -(Int16)(0xAAAA / 2) - 1; // 0xAAAA = -21846
        internal const Int16 __ENCODED16_ERROR = __ENCODED16_NULL - 1;
        internal const Int16 __ENCODED16_EXCEPTION = __ENCODED16_ERROR - 1;
        internal const Int16 __ENCODED16_VALUE_0 = 0;
        public const Int16 ENCODED16_VALUE_MAX = 0x3fff; // 16,383

        internal const int __HEADER32_LENGTH = sizeof(byte) + sizeof(Int32); // FIELDTYPE, ENCODEDLENGTH
        internal const Int32 __ENCODED32_NULL = -(Int32)(0xAAAAAAAA / 2) - 1; // 0xAAAAAAAA = __ENCODED32_NULL = -1,431,655,766
        internal const byte __ENCODED32_ENCODEDVALUE_1BYTE = 0xf1;
        internal const byte __ENCODED32_ENCODEDVALUE_2BYTES = 0xf2;
        internal const byte __ENCODED32_ENCODEDVALUE_3BYTES = 0xf3;
        internal const Int32 __ENCODED32_VALUE_0 = 0;
        public const Int32 ENCODED32_VALUE_MAX = 0x0fffffff; // 268,435,455 (268MB)

        public static FieldType GetFieldType(byte[] fieldBuffer, int fieldBufferBase) // 16 and 32
        {
            FieldType fieldtype = (FieldType)fieldBuffer[fieldBufferBase + __HEADER_FIELDTYPE];
            return fieldtype;
        }

        private static void SetHeader16(byte[] buffer, FieldType type, Int16 encodedLength)
        {
            Debug.WriteLine($"Set16: FieldType: {type}\tencodedLength: {encodedLength}");
            buffer[__HEADER_FIELDTYPE] = (byte)type;
            buffer[__HEADER_ENDCODEDLENGTH + 1] = (byte)(encodedLength >> 0);
            buffer[__HEADER_ENDCODEDLENGTH] = (byte)(encodedLength >> 8);
        }

        private static Int16 GetEncodedLength16(byte[] fieldBuffer, int fieldBufferBase)
        {
            Int16 encodedLength = (Int16)((fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 1] << 0) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 0] << 8));
            return encodedLength;
        }

        private static void SetHeader32(byte[] buffer, FieldType type, Int32 encodedLength)
        {
            Debug.WriteLine($"Set32a: FieldType: {type}\tencodedLength: {encodedLength}");
            buffer[__HEADER_FIELDTYPE] = (byte)type;
            buffer[__HEADER_ENDCODEDLENGTH + 3] = (byte)(encodedLength >> 0);
            buffer[__HEADER_ENDCODEDLENGTH + 2] = (byte)(encodedLength >> 8);
            buffer[__HEADER_ENDCODEDLENGTH + 1] = (byte)(encodedLength >> 16);
            buffer[__HEADER_ENDCODEDLENGTH + 0] = (byte)(encodedLength >> 24);
        }

        private static void SetHeader32(byte[] buffer, FieldType type, byte b0, byte b1, byte b2, byte b3)
        {
            Debug.WriteLine($"Set32b: FieldType: {type}\tb0,b1,b2,b3: {b0} {b1} {b2} {b3}");
            buffer[__HEADER_FIELDTYPE] = (byte)type;
            buffer[__HEADER_ENDCODEDLENGTH + 3] = b3;
            buffer[__HEADER_ENDCODEDLENGTH + 2] = b2;
            buffer[__HEADER_ENDCODEDLENGTH + 1] = b1;
            buffer[__HEADER_ENDCODEDLENGTH + 0] = b0;
        }

        private static Int32 GetEncodedLength32(byte[] fieldBuffer, int fieldBufferBase)
        {
            Int32 encodedLength = (Int32)((fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 3] << 0) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 2] << 8) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 1] << 16) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 0] << 24));
            Debug.WriteLine($"Get32: FieldType: {fieldBuffer[fieldBufferBase + 0]}\tencodedLength: {encodedLength}");
            return encodedLength;
        }

        public static byte[] GetFieldBuffer(byte[] value)
        {
            Int32 encodedLength;
            byte[] buffer = default(byte[]);

            if (value == null || (value != null && value.Length > ENCODED32_VALUE_MAX)) // HEADER16
            {
                encodedLength = __ENCODED16_NULL;
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.ByteArray16, (Int16)encodedLength);
            }
            else if (value.Length == 0) // HEADER16
            {
                encodedLength = 0;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.ByteArray16, (Int16)encodedLength);
            }
            else if (value.Length == 1) // HEADER16
            {
                encodedLength = (Int16)(-((Int32)value[0] + 1));
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.ByteArray16, (Int16)encodedLength);
            }
            else if (value.Length == 2) // HEADER32
            {
                buffer = new byte[__HEADER32_LENGTH + 0];
                SetHeader32(buffer, FieldType.ByteArray32, __ENCODED32_ENCODEDVALUE_2BYTES, value[0], value[1], 0);
            }
            else if (value.Length == 3) // HEADER32
            {
                buffer = new byte[__HEADER32_LENGTH + 0];
                SetHeader32(buffer, FieldType.ByteArray32, __ENCODED32_ENCODEDVALUE_3BYTES, value[0], value[1], value[2]);
            }
            else if (value.Length >= 4 && value.Length <= ENCODED16_VALUE_MAX) // HEADER16
            {
                encodedLength = (Int16)value.Length;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.ByteArray16, (Int16)encodedLength);
                if (encodedLength > 0) value.CopyTo(buffer, __HEADER16_LENGTH);
            }
            else if (value.Length > ENCODED16_VALUE_MAX && value.Length <= ENCODED32_VALUE_MAX) // HEADER32
            {
                encodedLength = value.Length;
                buffer = new byte[__HEADER32_LENGTH + encodedLength];
                SetHeader32(buffer, FieldType.ByteArray32, encodedLength);
                if (encodedLength > 0) value.CopyTo(buffer, __HEADER32_LENGTH);
            }
            else // HEADER16 - shouldn't end up here ever 
            {
                encodedLength = __ENCODED16_EXCEPTION;
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.ByteArray16, (Int16)encodedLength);
            }

            return buffer;
        }

        public static byte[] GetByteArray(byte[] buffer, ref int fieldBufferBase)
        {
            byte[] decodedValue = default(byte[]);

            FieldType fieldtype = GetFieldType(buffer, fieldBufferBase);
            switch (fieldtype)
            {
                case FieldType.ByteArray16:
                    {
                        Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                        if (encodedLength == __ENCODED16_NULL ||
                            encodedLength == __ENCODED16_ERROR ||
                            encodedLength == __ENCODED16_EXCEPTION)
                        {
                            decodedValue = null;
                            encodedLength = 0;
                        }
                        else if (encodedLength >= -1 - byte.MaxValue && encodedLength <= -1)
                        {
                            decodedValue = new byte[1];
                            decodedValue[__HEADER_FIELDTYPE] = (byte)(-encodedLength - 1);
                            encodedLength = 0;
                        }
                        else if (encodedLength == 0)
                        {
                            decodedValue = Array.Empty<byte>();
                            encodedLength = 0;
                        }
                        else if (encodedLength > 0)
                        {
                            decodedValue = new byte[encodedLength];
                            for (int i = 0; i < encodedLength; i++)
                            {
                                decodedValue[i] = buffer[fieldBufferBase + __HEADER16_LENGTH + i];
                            }
                        }
                        else
                        {
                            if (encodedLength < 0) encodedLength = 0;
                        }
                        fieldBufferBase += __HEADER16_LENGTH + encodedLength;
                        break;
                    }
                case FieldType.ByteArray32:
                    {
                        Int32 encodedLength;
                        switch (buffer[__HEADER_ENDCODEDLENGTH + 0])
                        {
                            case __ENCODED32_ENCODEDVALUE_1BYTE:
                                {
                                    // Should get here ever
                                    decodedValue = null;
                                    encodedLength = 0;
                                    break;
                                }
                            case __ENCODED32_ENCODEDVALUE_2BYTES:
                                {
                                    decodedValue = new byte[2];
                                    decodedValue[0] = buffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 1];
                                    decodedValue[1] = buffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 2];
                                    encodedLength = 0;
                                    break;
                                }
                            case __ENCODED32_ENCODEDVALUE_3BYTES:
                                {
                                    decodedValue = new byte[3];
                                    decodedValue[0] = buffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 1];
                                    decodedValue[1] = buffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 2];
                                    decodedValue[2] = buffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 3];
                                    encodedLength = 0;
                                    break;
                                }
                            default:
                                {
                                    encodedLength = GetEncodedLength32(buffer, fieldBufferBase);
                                    decodedValue = new byte[encodedLength];
                                    for (int i = 0; i < encodedLength; i++)
                                    {
                                        decodedValue[i] = buffer[fieldBufferBase + __HEADER32_LENGTH + i];
                                    }
                                    break;
                                }
                        }
                        fieldBufferBase += __HEADER32_LENGTH + encodedLength;
                        break;
                    }
                default:
                    {
                        fieldBufferBase += buffer.Length;
                        decodedValue = null;
                        break;
                    }
            }

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(Address value)
        {
            Int16 length;
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value == null)
            {
                length = -1;
                encodedLength = __ENCODED16_NULL;
                buffer = new byte[__HEADER16_LENGTH + 0];
            }
            else if ((value.Value == null) ||
                     (value.Value != null && value.Value.Length > ENCODED16_VALUE_MAX))
            {
                length = -1;
                encodedLength = __ENCODED16_NULL;
                buffer = new byte[__HEADER16_LENGTH + 0];
            }
            else if (value.Value.Length == 0)
            {
                length = 0;
                encodedLength = 0;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
            }
            else
            {
                length = (Int16)value.Value.Length;
                encodedLength = length;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
            }

            SetHeader16(buffer, FieldType.Address, encodedLength);
            for (int i = 0; i < length; i++)
            {
                char c = value.Value[i];
                Int16 ch = (Int16)c;
                if (!(ch >= 0 && ch <= 255 && char.IsLetterOrDigit(c))) ch = (Int16)'?';
                buffer[__HEADER16_LENGTH + i] = (byte)(ch);
            }
            return buffer;
        }

        public static Address GetAddress(byte[] buffer, ref int fieldBufferBase)
        {
            Address decodedValue = new Address();

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (encodedLength == __ENCODED16_NULL && GetFieldType(buffer, fieldBufferBase) == FieldType.Address)
            {
                //buffer = null;
                encodedLength = 0;
            }
            else if (encodedLength == 0 && GetFieldType(buffer, fieldBufferBase) == FieldType.Address)
            {
                decodedValue = new Address(String.Empty);
                encodedLength = 0;
            }
            else if (encodedLength > 0 && GetFieldType(buffer, fieldBufferBase) == FieldType.Address)
            {
                Int16 length = (Int16)(encodedLength);
                char[] value = new char[length];
                int index = 0;
                for (int i = 0; i < encodedLength; i++)
                {
                    Int32 ch = (buffer[fieldBufferBase + __HEADER16_LENGTH + i]);
                    value[index++] = (char)ch;
                }
                decodedValue.Value = new string(value, 0, value.Length);
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(string value) // Unicode
        {
            byte[] buffer;
            buffer = GetFieldBuffer(value, true);
            return buffer;
        }

        public static byte[] GetFieldBuffer(string value, bool isUnicode) // Unicode or ASCII
        {
            Int16 length;
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if ((value == null) ||
                (value != null && isUnicode && value.Length * 2 > ENCODED16_VALUE_MAX) ||
                (value != null && !isUnicode && value.Length > ENCODED16_VALUE_MAX))
            {
                length = -1;
                encodedLength = __ENCODED16_NULL;
                buffer = new byte[__HEADER16_LENGTH + 0];
            }
            else if (value.Length == 0)
            {
                length = 0;
                encodedLength = 0;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
            }
            else if (!isUnicode) // ASCII
            {
                if (value.Length == 1)
                {
                    length = 0;
                    char c = value[0];
                    Int16 ch = (Int16)c;
                    if (!(ch >= 0 && ch <= 255)) ch = (Int16)'?';
                    encodedLength = (Int16)(-((Int32)ch + 1));
                    buffer = new byte[__HEADER16_LENGTH + 0];
                }
                else
                {
                    length = (Int16)value.Length;
                    encodedLength = length;
                    buffer = new byte[__HEADER16_LENGTH + encodedLength];
                }
            }
            else // isUnicode
            {
                length = (Int16)value.Length;
                encodedLength = (Int16)(length * 2);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
            }

            if (!isUnicode) // ASCII
            {
                SetHeader16(buffer, FieldType.ASCIIString, encodedLength);
                for (int i = 0; i < length; i++)
                {
                    char c = value[i];
                    Int16 ch = (Int16)c;
                    if (!(ch >= 0 && ch <= 255)) ch = (Int16)'?';
                    buffer[__HEADER16_LENGTH + i] = (byte)(ch);
                }
            }
            else // isUnicode
            {
                SetHeader16(buffer, FieldType.String, encodedLength);
                for (int i = 0; i < length; i++)
                {
                    Int16 ch = (Int16)value[i];
                    buffer[4 + 2 * i] = (byte)(ch >> 0);
                    buffer[__HEADER16_LENGTH + 2 * i] = (byte)(ch >> 8);
                }
            }
            return buffer;
        }

        public static string GetString(byte[] buffer, ref int fieldBufferBase)
        {
            string decodedValue = default(String);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (encodedLength == __ENCODED16_NULL && GetFieldType(buffer, fieldBufferBase) == FieldType.String)
            {
                decodedValue = null;
                encodedLength = 0;
            }
            else if (encodedLength == 0 && GetFieldType(buffer, fieldBufferBase) == FieldType.String)
            {
                decodedValue = String.Empty;
                encodedLength = 0;
            }
            else if (encodedLength > 0 && GetFieldType(buffer, fieldBufferBase) == FieldType.String)
            {
                Int16 length = (Int16)(encodedLength / 2);
                char[] value = new char[length];
                int index = 0;
                for (int i = 0; i < encodedLength; i += 2)
                {
                    Int32 ch = (buffer[fieldBufferBase + __HEADER16_LENGTH + 1 + i] << 0) | (buffer[fieldBufferBase + __HEADER16_LENGTH + i] << 8);
                    value[index++] = (char)ch;
                }
                decodedValue = new string(value, 0, value.Length);
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static string GetASCIIString(byte[] buffer, ref int fieldBufferBase)
        {
            string decodedValue = default(String);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (encodedLength == __ENCODED16_NULL && GetFieldType(buffer, fieldBufferBase) == FieldType.ASCIIString)
            {
                decodedValue = null;
                encodedLength = 0;
            }
            else if (encodedLength == 0 && GetFieldType(buffer, fieldBufferBase) == FieldType.ASCIIString)
            {
                decodedValue = String.Empty;
                encodedLength = 0;
            }
            else if (encodedLength >= -1 - byte.MaxValue && encodedLength <= -1 && GetFieldType(buffer, fieldBufferBase) == FieldType.ASCIIString)
            {
                char[] value = new char[1];
                Int32 ch = (Int32)(-encodedLength - 1);
                value[0] = (char)ch;
                encodedLength = 0;
                decodedValue = new string(value, 0, value.Length);
            }
            else if (encodedLength > 0 && GetFieldType(buffer, fieldBufferBase) == FieldType.ASCIIString)
            {
                Int16 length = (Int16)(encodedLength);
                char[] value = new char[length];
                int index = 0;
                for (int i = 0; i < encodedLength; i++)
                {
                    Int32 ch = (buffer[fieldBufferBase + __HEADER16_LENGTH + i]);
                    value[index++] = (char)ch;
                }
                decodedValue = new string(value, 0, value.Length);
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(byte value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= byte.MaxValue)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.Byte, encodedLength);
            }
            else
            {
                encodedLength = sizeof(byte);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.Byte, encodedLength);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value);
            }
            return buffer;
        }

        public static byte GetByte(byte[] buffer, ref int fieldBufferBase)
        {
            byte decodedValue = default(Byte);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.Byte)
            {
                if (encodedLength >= (Int16)(-byte.MaxValue) && encodedLength <= 0)
                {
                    decodedValue = (byte)(-encodedLength);
                    encodedLength = 0;
                }
                else
                {
                    decodedValue = buffer[fieldBufferBase + __HEADER16_LENGTH];
                }
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(sbyte value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= sbyte.MaxValue)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.SByte, encodedLength);
            }
            else
            {
                encodedLength = sizeof(byte);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.SByte, encodedLength);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value);
            }
            return buffer;
        }

        public static sbyte GetSByte(byte[] buffer, ref int fieldBufferBase)
        {
            sbyte decodedValue = default(SByte);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.SByte)
            {
                if (encodedLength >= (Int16)(-sbyte.MaxValue) && encodedLength <= 0)
                {
                    decodedValue = (sbyte)(-encodedLength);
                    encodedLength = 0;
                }
                else
                {
                    decodedValue = (sbyte)buffer[fieldBufferBase + __HEADER16_LENGTH];
                }
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(bool value)
        {
            Int16 encodedLength = (Int16)(value ? -1 : 0);
            byte[] buffer = new byte[__HEADER16_LENGTH + 0];
            SetHeader16(buffer, FieldType.Boolean, encodedLength);
            return buffer;
        }

        public static Boolean GetBoolean(byte[] buffer, ref int fieldBufferBase)
        {
            Boolean decodedValue = default(Boolean);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.Boolean)
            {
                decodedValue = (Int16)(-encodedLength) != 0;
                encodedLength = 0;
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(char ch)
        {
            Int16 encodedLength = sizeof(Int16);
            Int16 value = (Int16)ch;
            byte[] buffer = new byte[__HEADER16_LENGTH + encodedLength];
            SetHeader16(buffer, FieldType.Char, encodedLength);
            buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 0);
            buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 8);
            return buffer;
        }

        public static char GetChar(byte[] buffer, ref int fieldBufferBase)
        {
            char decodedValue = default(char);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.Char)
            {
                Int32 value = ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 0) | ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 8);
                decodedValue = (char)value;
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(Int16 value)
        {
            return GetFieldBuffer(value, false);
        }

        public static byte[] GetFieldBuffer(Int16 value, bool isEnumValue)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= __ENCODED16_VALUE_0 && value <= ENCODED16_VALUE_MAX)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.Int16, encodedLength);
            }
            else
            {
                encodedLength = sizeof(Int16);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.Int16, encodedLength);
                buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 0);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 8);
            }

            if (isEnumValue) SetHeader16(buffer, FieldType.Enum, encodedLength);

            return buffer;
        }

        public static Int16 GetInt16(byte[] buffer, ref int fieldBufferBase)
        {
            Int16 decodedValue = default(Int16);
            Int32 value;

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.Int16
                || GetFieldType(buffer, fieldBufferBase) == FieldType.UInt16
                || GetFieldType(buffer, fieldBufferBase) == FieldType.Enum)
            {
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    value = -encodedLength;
                    encodedLength = 0;
                }
                else
                {
                    value = ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 0) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 8);
                }
                decodedValue = (Int16)value;
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static Int16 GetEnum(byte[] buffer, ref int fieldBufferBase)
        {
            Int16 decodedValue;
            decodedValue = GetInt16(buffer, ref fieldBufferBase);
            return decodedValue;
        }

        public static byte[] GetFieldBuffer(Int32 value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= __ENCODED16_VALUE_0 && value <= ENCODED16_VALUE_MAX)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.Int32, encodedLength);
            }
            else
            {
                encodedLength = sizeof(Int32);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.Int32, encodedLength);
                buffer[__HEADER16_LENGTH + 3] = (byte)(value >> 0);
                buffer[__HEADER16_LENGTH + 2] = (byte)(value >> 8);
                buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 16);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 24);
            }
            return buffer;
        }

        public static Int32 GetInt32(byte[] buffer, ref int fieldBufferBase)
        {
            Int32 decodedValue = default(Int32);
            Int32 value;

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.Int32 || GetFieldType(buffer, fieldBufferBase) == FieldType.UInt32)
            {
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    Int16 value16 = (Int16)(-encodedLength);
                    value = value16;
                    encodedLength = 0;
                }
                else
                {
                    value = ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 3] << 0) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 2] << 8) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 16) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 24);
                }
                decodedValue = value;
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        public static byte[] GetFieldBuffer(Int64 value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= __ENCODED16_VALUE_0 && value <= ENCODED16_VALUE_MAX)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldType.Int64, encodedLength);
            }
            else
            {
                encodedLength = sizeof(Int64);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldType.Int64, encodedLength); ;
                buffer[__HEADER16_LENGTH + 7] = (byte)(value >> 0);
                buffer[__HEADER16_LENGTH + 6] = (byte)(value >> 8);
                buffer[__HEADER16_LENGTH + 5] = (byte)(value >> 16);
                buffer[__HEADER16_LENGTH + 4] = (byte)(value >> 24);
                buffer[__HEADER16_LENGTH + 3] = (byte)(value >> 32);
                buffer[__HEADER16_LENGTH + 2] = (byte)(value >> 40);
                buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 48);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 56);
            }
            return buffer;
        }

        public static Int64 GetInt64(byte[] buffer, ref int fieldBufferBase)
        {
            Int64 decodedValue = default(Int64);
            Int64 value;

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldType(buffer, fieldBufferBase) == FieldType.Int64 || GetFieldType(buffer, fieldBufferBase) == FieldType.UInt64)
            {
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    value = -encodedLength;
                    encodedLength = 0;
                }
                else
                {
                    value = ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 7] << 0) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 6] << 8) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 5] << 16) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 4] << 24) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 3] << 32) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 2] << 40) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 48) |
                            ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 56);

                }
                decodedValue = value;
            }
            else
            {
                if (encodedLength < 0) encodedLength = 0;
            }
            fieldBufferBase += __HEADER16_LENGTH + encodedLength;

            return decodedValue;
        }

        // https://referencesource.microsoft.com/mscorlib/system/bitconverter.cs.html#https://referencesource.microsoft.com/mscorlib/system/bitconverter.cs.html
        public static byte[] GetFieldBuffer(UInt16 value)
        {
            byte[] buffer = GetFieldBuffer((Int16)value);
            buffer[__HEADER_FIELDTYPE] = (byte)FieldType.UInt16;
            return buffer;
        }
        public static byte[] GetFieldBuffer(UInt32 value)
        {
            byte[] buffer = GetFieldBuffer((Int32)value);
            buffer[__HEADER_FIELDTYPE] = (byte)FieldType.UInt32;
            return buffer;
        }
        public static byte[] GetFieldBuffer(UInt64 value)
        {
            byte[] buffer = GetFieldBuffer((Int64)value);
            buffer[__HEADER_FIELDTYPE] = (byte)FieldType.UInt64;
            return buffer;
        }

        public static UInt16 GetUInt16(byte[] buffer, ref int fieldBufferBase)
        {
            UInt16 decodedValue;
            decodedValue = (UInt16)GetInt16(buffer, ref fieldBufferBase);
            return decodedValue;
        }
        public static UInt32 GetUInt32(byte[] buffer, ref int fieldBufferBase)
        {
            UInt32 decodedValue;
            decodedValue = (UInt32)GetInt32(buffer, ref fieldBufferBase);
            return decodedValue;
        }
        public static UInt64 GetUInt64(byte[] buffer, ref int fieldBufferBase)
        {
            UInt64 decodedValue;
            decodedValue = (UInt64)GetInt64(buffer, ref fieldBufferBase);
            return decodedValue;
        }
    }
}
