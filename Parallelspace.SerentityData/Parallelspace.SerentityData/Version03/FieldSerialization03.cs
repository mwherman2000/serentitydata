using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Parallelspace.SerentityData
{
    public struct FieldSerialization03
    {
        public const byte FIELDSERIALIZATION_VERSION = 0x03; // Version 0x03

        public enum FieldEncodingType
        {
            EnumZeroDoNotUse,
            Int16Hdr16PlusMinus,
            Int32Hdr16PlusMinus, Int32KMinus1, Int32K0, Int32K1, Int32K2, Int32K3, Int32K4, Int32K5, Int32K6, Int32K7, Int32K8, Int32K9, Int32K10,
            Int64Hdr16, Int64Hdr16Data, Int64Hdr32,
            UInt16Hdr16PlusMinus, UInt16K0, UInt16K1, UInt16K2, UInt16K3, UInt16K4, UInt16K5, UInt16K6, UInt16K7, UInt16K8, UInt16K9, UInt16K10, UInt16K11, UInt16K12, UInt16K13, UInt16K14, UInt16K15, UInt16K16, UInt16K17, UInt16K18, UInt16K19, UInt16K20, UInt16K21, UInt16K22, UInt16K23, UInt16K24, UInt16K25, UInt16K26, UInt16K27, UInt16K28, UInt16K29, UInt16K30, UInt16K31, UInt16K32, UInt16K33, UInt16K34, UInt16K35, UInt16K36, UInt16K37, UInt16K38, UInt16K39, UInt16K40, UInt16K41, UInt16K42, UInt16K43, UInt16K44, UInt16K45, UInt16K46, UInt16K47, UInt16K48, UInt16K49, UInt16K50, UInt16K51, UInt16K52, UInt16K53, UInt16K54, UInt16K55, UInt16K56, UInt16K57, UInt16K58, UInt16K59, UInt16K60,
            UInt32Hdr16PlusMinus, UInt32K0, UInt32K1, UInt32K2, UInt32K3, UInt32K4, UInt32K5, UInt32K6, UInt32K7, UInt32K8, UInt32K9, UInt32K10, UInt32K11, UInt32K12, UInt32K13, UInt32K14, UInt32K15, UInt32K16, UInt32K17, UInt32K18, UInt32K19, UInt32K20, UInt32K21, UInt32K22, UInt32K23, UInt32K24, UInt32K25, UInt32K26, UInt32K27, UInt32K28, UInt32K29, UInt32K30, UInt32K31, UInt32K32, UInt32K33, UInt32K34, UInt32K35, UInt32K36, UInt32K37, UInt32K38, UInt32K39, UInt32K40, UInt32K41, UInt32K42, UInt32K43, UInt32K44, UInt32K45, UInt32K46, UInt32K47, UInt32K48, UInt32K49, UInt32K50, UInt32K51, UInt32K52, UInt32K53, UInt32K54, UInt32K55, UInt32K56, UInt32K57, UInt32K58, UInt32K59, UInt32K60,
            UInt64Hdr16, UInt64Hdr16Data, UInt64Hdr32, UInt64K0, UInt64K1, UInt64K2, UInt64K3, UInt64K4, UInt64K5, UInt64K6, UInt64K7, UInt64K8, UInt64K9, UInt64K10, UInt64K11, UInt64K12, UInt64K13, UInt64K14, UInt64K15, UInt64K16, UInt64K17, UInt64K18, UInt64K19, UInt64K20, UInt64K21, UInt64K22, UInt64K23, UInt64K24, UInt64K25, UInt64K26, UInt64K27, UInt64K28, UInt64K29, UInt64K30, UInt64K31, UInt64K32, UInt64K33, UInt64K34, UInt64K35, UInt64K36, UInt64K37, UInt64K38, UInt64K39, UInt64K40, UInt64K41, UInt64K42, UInt64K43, UInt64K44, UInt64K45, UInt64K46, UInt64K47, UInt64K48, UInt64K49, UInt64K50, UInt64K51, UInt64K52, UInt64K53, UInt64K54, UInt64K55, UInt64K56, UInt64K57, UInt64K58, UInt64K59, UInt64K60,
            Byte, ByteK0, ByteK1, ByteK2, ByteK3, ByteK4, ByteK5, ByteK6, ByteK7, ByteK8, ByteK9, ByteK10, ByteK11, ByteK12, ByteK13, ByteK14, ByteK15, ByteK16, ByteK17, ByteK18, ByteK19, ByteK20,
            SByte,
            EnumHdr16PlusMinus, EnumK0, EnumK1, EnumK2, EnumK3, EnumK4, EnumK5, EnumK6, EnumK7, EnumK8, EnumK9, EnumK10,
            ByteArrayHdr16, ByteArrayHdr16Data, ByteArrayHdr32, ByteArrayHdr32Data,
            BooleanFalse, BooleanTrue, Char, String, ASCIIString, Address, Guid, Mapping,
            Unknown, RESERVED1, RESERVED2,
            /* BigInteger */

        }

        internal const int __HEADER_FIELDENCODINGTYPE = 0;
        internal const int __HEADER_ENDCODEDLENGTH = 1;

        internal const int __HEADER8_LENGTH = sizeof(byte); // FIELDTYPE only
        internal const int __HEADER16_LENGTH = sizeof(byte) + sizeof(Int16); // FIELDTYPE, ENCODEDLENGTH
        internal const Int16 __ENCODED16_NULL = -(Int16)(0xAAAA / 2) - 1; // 0xAAAA = -21846
        internal const Int16 __ENCODED16_ERROR = __ENCODED16_NULL - 1;
        internal const Int16 __ENCODED16_EXCEPTION = __ENCODED16_ERROR - 1;
        public const Int16 ENCODED16_VALUE_MAX = 0x3fff; // 16,383

        internal const int __HEADER32_LENGTH = sizeof(byte) + sizeof(Int32); // FIELDTYPE, ENCODEDLENGTH
        internal const Int32 __ENCODED32_NULL = -(Int32)(0xAAAAAAAA / 2) - 1; // 0xAAAAAAAA = __ENCODED32_NULL = -1,431,655,766
        internal const byte __ENCODED32_ENCODEDVALUE_1BYTE = 0xf1;
        internal const byte __ENCODED32_ENCODEDVALUE_2BYTES = 0xf2;
        internal const byte __ENCODED32_ENCODEDVALUE_3BYTES = 0xf3;
        internal const Int32 __ENCODED32_VALUE_0 = 0;
        public const Int32 ENCODED32_VALUE_MAX = 0x0fffffff; // 268,435,455

        public static FieldEncodingType GetFieldEncodingType(byte[] fieldBuffer, int fieldBufferBase) // 16 and 32
        {
            FieldEncodingType encoding = FieldEncodingType.Unknown;
            if (fieldBufferBase + __HEADER_FIELDENCODINGTYPE < fieldBuffer.Length)
            {
                encoding = (FieldEncodingType)fieldBuffer[fieldBufferBase + __HEADER_FIELDENCODINGTYPE];
            }
            return encoding;
        }

        public static void SetFieldEncodingType(byte[] fieldBuffer, FieldEncodingType encoding) // 8 and 16 and 32
        {
            fieldBuffer[__HEADER_FIELDENCODINGTYPE] = (byte)encoding;
        }

        private static void SetHeader16(byte[] buffer, FieldEncodingType encoding, Int16 encodedLength)
        {
            //Debug.WriteLine($"Set16: FieldType: {encoding}\tencodedLength: {encodedLength}");
            SetFieldEncodingType(buffer, encoding);
            buffer[__HEADER_ENDCODEDLENGTH + 1] = (byte)(encodedLength >> 0);
            buffer[__HEADER_ENDCODEDLENGTH + 0] = (byte)(encodedLength >> 8);
        }

        private static Int16 GetEncodedLength16(byte[] fieldBuffer, int fieldBufferBase)
        {
            Int16 encodedLength = (Int16)((fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 1] << 0) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 0] << 8));
            //Debug.WriteLine($"Get16: FieldType: {fieldBuffer[fieldBufferBase + 0]}\tencodedLength: {encodedLength}");
            return encodedLength;
        }

        private static void SetHeader32(byte[] buffer, FieldEncodingType encoding, Int32 encodedLength)
        {
            //Debug.WriteLine($"Set32a: FieldType: {encoding}\tencodedLength: {encodedLength}");
            SetFieldEncodingType(buffer, encoding);
            buffer[__HEADER_ENDCODEDLENGTH + 3] = (byte)(encodedLength >> 0);
            buffer[__HEADER_ENDCODEDLENGTH + 2] = (byte)(encodedLength >> 8);
            buffer[__HEADER_ENDCODEDLENGTH + 1] = (byte)(encodedLength >> 16);
            buffer[__HEADER_ENDCODEDLENGTH + 0] = (byte)(encodedLength >> 24);
        }

        private static Int32 GetEncodedLength32(byte[] fieldBuffer, int fieldBufferBase)
        {
            Int32 encodedLength = (Int32)((fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 3] << 0) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 2] << 8) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 1] << 16) |
                                          (fieldBuffer[fieldBufferBase + __HEADER_ENDCODEDLENGTH + 0] << 24));
            //Debug.WriteLine($"Get32: FieldType: {fieldBuffer[fieldBufferBase + 0]}\tencodedLength: {encodedLength}");
            return encodedLength;
        }

        private static void SetHeader32(byte[] buffer, FieldEncodingType encoding, byte b0, byte b1, byte b2, byte b3)
        {
            //Debug.WriteLine($"Set32b: FieldType: {encoding}\tb0,b1,b2,b3: {b0} {b1} {b2} {b3}");
            SetFieldEncodingType(buffer, encoding);
            buffer[__HEADER_ENDCODEDLENGTH + 3] = b3;
            buffer[__HEADER_ENDCODEDLENGTH + 2] = b2;
            buffer[__HEADER_ENDCODEDLENGTH + 1] = b1;
            buffer[__HEADER_ENDCODEDLENGTH + 0] = b0;
        }

        //
        // Encoding/decoding methods
        //

        public static byte[] Serialize(byte[] value)
        {
            Int32 encodedLength;
            byte[] buffer = default(byte[]);

            if (value == null || (value != null && value.Length > ENCODED32_VALUE_MAX)) // HEADER16
            {
                encodedLength = __ENCODED16_NULL;
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.ByteArrayHdr16, (Int16)encodedLength);
            }
            else if (value.Length == 0) // HEADER16
            {
                encodedLength = 0;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.ByteArrayHdr16, (Int16)encodedLength);
            }
            else if (value.Length == 1) // HEADER16
            {
                encodedLength = (Int16)(-((Int32)value[0] + 1));
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.ByteArrayHdr16, (Int16)encodedLength);
            }
            else if (value.Length == 2) // HEADER32
            {
                buffer = new byte[__HEADER32_LENGTH + 0];
                SetHeader32(buffer, FieldEncodingType.ByteArrayHdr32, __ENCODED32_ENCODEDVALUE_2BYTES, value[0], value[1], 0);
            }
            else if (value.Length == 3) // HEADER32
            {
                buffer = new byte[__HEADER32_LENGTH + 0];
                SetHeader32(buffer, FieldEncodingType.ByteArrayHdr32, __ENCODED32_ENCODEDVALUE_3BYTES, value[0], value[1], value[2]);
            }
            else if (value.Length >= 4 && value.Length <= ENCODED16_VALUE_MAX) // HEADER16
            {
                encodedLength = (Int16)value.Length;
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.ByteArrayHdr16Data, (Int16)encodedLength);
                if (encodedLength > 0) value.CopyTo(buffer, __HEADER16_LENGTH);
            }
            else if (value.Length > ENCODED16_VALUE_MAX && value.Length <= ENCODED32_VALUE_MAX) // HEADER32
            {
                encodedLength = value.Length;
                buffer = new byte[__HEADER32_LENGTH + encodedLength];
                SetHeader32(buffer, FieldEncodingType.ByteArrayHdr32Data, encodedLength);
                if (encodedLength > 0) value.CopyTo(buffer, __HEADER32_LENGTH);
            }
            else // HEADER16 - should never end up here ever 
            {
                encodedLength = __ENCODED16_EXCEPTION;
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.ByteArrayHdr16, (Int16)encodedLength);
            }

            return buffer;
        }

        public static byte[] DeserializeByteArray(byte[] buffer, ref int fieldBufferBase, FieldEncodingType fieldEncodingOverride = FieldEncodingType.EnumZeroDoNotUse)
        {
            byte[] decodedValue = default(byte[]);

            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (fieldEncodingOverride != FieldEncodingType.EnumZeroDoNotUse) encoding = fieldEncodingOverride; //Guid
            switch (encoding)
            {
                case FieldEncodingType.ByteArrayHdr16:
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
                            decodedValue[0] = (byte)(-encodedLength - 1);
                            encodedLength = 0;
                        }
                        else if (encodedLength == 0)
                        {
                            decodedValue = Array.Empty<byte>();
                            encodedLength = 0;
                        }
                        else
                        {
                            // Should never end up here
                            decodedValue = null;
                            encodedLength = 0;
                        }
                        fieldBufferBase += __HEADER16_LENGTH + encodedLength;
                        break;
                    }
                case FieldEncodingType.ByteArrayHdr16Data:
                    {
                        Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                        if (encodedLength > 0)
                        {
                            decodedValue = new byte[encodedLength];
                            for (int i = 0; i < encodedLength; i++)
                            {
                                decodedValue[i] = buffer[fieldBufferBase + __HEADER16_LENGTH + i];
                            }
                        }
                        else
                        {
                            // Should never end up here
                            decodedValue = null;
                            encodedLength = 0;
                        }
                        fieldBufferBase += __HEADER16_LENGTH + encodedLength;
                        break;
                    }
                case FieldEncodingType.ByteArrayHdr32:
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
                case FieldEncodingType.ByteArrayHdr32Data:
                    {
                        Int32 encodedLength;
                        encodedLength = GetEncodedLength32(buffer, fieldBufferBase);
                        if (encodedLength > 0)
                        {
                            decodedValue = new byte[encodedLength];
                            for (int i = 0; i < encodedLength; i++)
                            {
                                decodedValue[i] = buffer[fieldBufferBase + __HEADER32_LENGTH + i];
                            }
                        }
                        else
                        {
                            // Should never end up here
                            decodedValue = null;
                            encodedLength = 0;
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

        public static byte[] Serialize(Guid value)
        {
            byte[] buffer = Serialize(value.ToByteArray());
            SetFieldEncodingType(buffer, FieldEncodingType.Guid);
            return buffer;
        }

        public static Guid DeserializeGuid(byte[] buffer, ref int fieldBufferBase)
        {
            Guid decodedValue;
            decodedValue = new Guid(DeserializeByteArray(buffer, ref fieldBufferBase, FieldEncodingType.ByteArrayHdr16Data));
            return decodedValue;
        }

        public static byte[] Serialize(Address value)
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

            SetHeader16(buffer, FieldEncodingType.Address, encodedLength);
            for (int i = 0; i < length; i++)
            {
                char c = value.Value[i];
                Int16 ch = (Int16)c;
                if (!(ch >= 0 && ch <= 255 && char.IsLetterOrDigit(c))) ch = (Int16)'?';
                buffer[__HEADER16_LENGTH + i] = (byte)(ch);
            }
            return buffer;
        }

        public static Address DeserializeAddress(byte[] buffer, ref int fieldBufferBase)
        {
            Address decodedValue = new Address();

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (encodedLength == __ENCODED16_NULL && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.Address)
            {
                //buffer = null;
                encodedLength = 0;
            }
            else if (encodedLength == 0 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.Address)
            {
                decodedValue = new Address(String.Empty);
                encodedLength = 0;
            }
            else if (encodedLength > 0 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.Address)
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

        public static byte[] Serialize(string value) // Unicode
        {
            byte[] buffer;
            buffer = Serialize(value, true);
            return buffer;
        }

        public static byte[] Serialize(string value, bool isUnicode) // Unicode or ASCII
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
                SetHeader16(buffer, FieldEncodingType.ASCIIString, encodedLength);
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
                SetHeader16(buffer, FieldEncodingType.String, encodedLength);
                for (int i = 0; i < length; i++)
                {
                    Int16 ch = (Int16)value[i];
                    buffer[4 + 2 * i] = (byte)(ch >> 0);
                    buffer[__HEADER16_LENGTH + 2 * i] = (byte)(ch >> 8);
                }
            }
            return buffer;
        }

        public static string DeserializeString(byte[] buffer, ref int fieldBufferBase)
        {
            string decodedValue = default(String);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (encodedLength == __ENCODED16_NULL && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.String)
            {
                decodedValue = null;
                encodedLength = 0;
            }
            else if (encodedLength == 0 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.String)
            {
                decodedValue = String.Empty;
                encodedLength = 0;
            }
            else if (encodedLength > 0 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.String)
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

        public static string DeserializeASCIIString(byte[] buffer, ref int fieldBufferBase)
        {
            string decodedValue = default(String);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (encodedLength == __ENCODED16_NULL && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.ASCIIString)
            {
                decodedValue = null;
                encodedLength = 0;
            }
            else if (encodedLength == 0 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.ASCIIString)
            {
                decodedValue = String.Empty;
                encodedLength = 0;
            }
            else if (encodedLength >= -1 - byte.MaxValue && encodedLength <= -1 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.ASCIIString)
            {
                char[] value = new char[1];
                Int32 ch = (Int32)(-encodedLength - 1);
                value[0] = (char)ch;
                encodedLength = 0;
                decodedValue = new string(value, 0, value.Length);
            }
            else if (encodedLength > 0 && GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.ASCIIString)
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

        public static byte[] Serialize(Byte value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= (FieldEncodingType.ByteK20 - FieldEncodingType.ByteK0))
            {
                buffer = new byte[__HEADER8_LENGTH];
                SetFieldEncodingType(buffer, FieldEncodingType.ByteK0 + value);
            }
            else if (value >= 0 && value <= byte.MaxValue)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.Byte, encodedLength);
            }
            else
            {
                encodedLength = sizeof(byte);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.Byte, encodedLength);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value);
            }
            return buffer;
        }

        public static Byte DeserializeByte(byte[] buffer, ref int fieldBufferBase)
        {
            Byte decodedValue = default(Byte);
            Int16 encodedLength;

            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (encoding >= FieldEncodingType.ByteK0 && encoding <= FieldEncodingType.ByteK20)
            {
                decodedValue = (byte)(encoding - FieldEncodingType.ByteK0);
                encodedLength = __HEADER8_LENGTH;
            }
            else if (encoding == FieldEncodingType.Byte)
            {
                encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                if (encodedLength >= (Int16)(-byte.MaxValue) && encodedLength <= 0)
                {
                    decodedValue = (byte)(-encodedLength);
                    encodedLength = __HEADER16_LENGTH;
                }
                else
                {
                    decodedValue = buffer[fieldBufferBase + __HEADER16_LENGTH];
                    encodedLength += __HEADER16_LENGTH;
                }
            }
            else // Unknown encoding
            {
                encodedLength = (Int16)buffer.Length;
            }
            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static byte[] Serialize(SByte value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= sbyte.MaxValue)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.SByte, encodedLength);
            }
            else
            {
                encodedLength = sizeof(byte);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.SByte, encodedLength);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value);
            }
            return buffer;
        }

        public static SByte DeserializeSByte(byte[] buffer, ref int fieldBufferBase)
        {
            SByte decodedValue = default(SByte);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.SByte)
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

        public static byte[] Serialize(bool value)
        {
            byte[] buffer = new byte[__HEADER8_LENGTH + 0];
            if (value)
            {
                SetFieldEncodingType(buffer, FieldEncodingType.BooleanTrue);
            }
            else
            {
                SetFieldEncodingType(buffer, FieldEncodingType.BooleanFalse);
            }
            return buffer;
        }

        public static Boolean DeserializeBoolean(byte[] buffer, ref int fieldBufferBase)
        {
            Boolean decodedValue = default(Boolean);

            if (GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.BooleanTrue)
            {
                decodedValue = true;
            }
            else
            {
                decodedValue = false;
            }
            fieldBufferBase += __HEADER8_LENGTH + 0;

            return decodedValue;
        }

        public static byte[] Serialize(char ch)
        {
            Int16 encodedLength = sizeof(Int16);
            Int16 value = (Int16)ch;
            byte[] buffer = new byte[__HEADER16_LENGTH + encodedLength];
            SetHeader16(buffer, FieldEncodingType.Char, encodedLength);
            buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 0);
            buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 8);
            return buffer;
        }

        public static char DeserializeChar(byte[] buffer, ref int fieldBufferBase)
        {
            char decodedValue = default(char);

            Int16 encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
            if (GetFieldEncodingType(buffer, fieldBufferBase) == FieldEncodingType.Char)
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

        public static byte[] Serialize(Int16 value)
        {
            return Serialize(value, false);
        }

        public static byte[] Serialize(Int16 value, bool isEnumValue)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (isEnumValue)
            {
                if (value >= 0 && value <= (FieldEncodingType.EnumK0 - FieldEncodingType.EnumK10))
                {
                    buffer = new byte[__HEADER8_LENGTH];
                    SetFieldEncodingType(buffer, FieldEncodingType.EnumK0 + value);
                }
                else if (value >= 0 && value <= ENCODED16_VALUE_MAX)
                {
                    encodedLength = (Int16)(-value);
                    buffer = new byte[__HEADER16_LENGTH + 0];
                    SetHeader16(buffer, FieldEncodingType.EnumHdr16PlusMinus, encodedLength);
                }
                else
                {
                    encodedLength = sizeof(Int16);
                    buffer = new byte[__HEADER16_LENGTH + encodedLength];
                    SetHeader16(buffer, FieldEncodingType.EnumHdr16PlusMinus, encodedLength);
                    buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 0);
                    buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 8);
                }
            }
            else {
                if (value >= 0 && value <= ENCODED16_VALUE_MAX)
                {
                    encodedLength = (Int16)(-value);
                    buffer = new byte[__HEADER16_LENGTH + 0];
                    SetHeader16(buffer, FieldEncodingType.Int16Hdr16PlusMinus, encodedLength);
                }
                else
                {
                    encodedLength = sizeof(Int16);
                    buffer = new byte[__HEADER16_LENGTH + encodedLength];
                    SetHeader16(buffer, FieldEncodingType.Int16Hdr16PlusMinus, encodedLength);
                    buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 0);
                    buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 8);
                }
            }

            return buffer;
        }

        public static Int16 DeserializeInt16(byte[] buffer, ref int fieldBufferBase)
        {
            Int16 decodedValue = default(Int16);
            Int32 value;
            Int16 encodedLength;

            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (encoding >= FieldEncodingType.EnumK0 && encoding <= FieldEncodingType.EnumK10)
            {
                decodedValue = (Int16)(encoding - FieldEncodingType.EnumK0);
                encodedLength = __HEADER8_LENGTH;
            }
            else if (encoding == FieldEncodingType.Int16Hdr16PlusMinus || encoding == FieldEncodingType.EnumHdr16PlusMinus)
            {
                encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    value = -encodedLength;
                    encodedLength = __HEADER16_LENGTH;
                }
                else
                {
                    value = ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 0) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 8);
                    encodedLength += __HEADER16_LENGTH;
                }
                decodedValue = (Int16)value;
            }
            else // Unknown encoding
            {
                encodedLength = (Int16)buffer.Length;
            }

            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static Int16 DeserializeEnum(byte[] buffer, ref int fieldBufferBase)
        {
            Int16 decodedValue;
            decodedValue = DeserializeInt16(buffer, ref fieldBufferBase);
            return decodedValue;
        }

        public static byte[] Serialize(Int32 value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= (FieldEncodingType.Int32KMinus1 - FieldEncodingType.Int32K0) && value <= (FieldEncodingType.Int32K10 - FieldEncodingType.Int32K0))
            {
                buffer = new byte[__HEADER8_LENGTH];
                SetFieldEncodingType(buffer, FieldEncodingType.Int32K0 + value);
            }
            else if (value >= 0 && value <= ENCODED16_VALUE_MAX)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.Int32Hdr16PlusMinus, encodedLength);
            }
            else
            {
                encodedLength = sizeof(Int32);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.Int32Hdr16PlusMinus, encodedLength);
                buffer[__HEADER16_LENGTH + 3] = (byte)(value >> 0);
                buffer[__HEADER16_LENGTH + 2] = (byte)(value >> 8);
                buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 16);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 24);
            }
            return buffer;
        }

        public static Int32 DeserializeInt32(byte[] buffer, ref int fieldBufferBase)
        {
            Int32 decodedValue = default(Int32);
            Int32 value;
            Int16 encodedLength;

            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (encoding >= FieldEncodingType.Int32KMinus1 && encoding <= FieldEncodingType.Int32K10)
            {
                decodedValue = (Int16)(encoding - FieldEncodingType.Int32K0);
                encodedLength = __HEADER8_LENGTH;
            }
            else if (encoding == FieldEncodingType.Int32Hdr16PlusMinus)
            {
                encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    Int16 value16 = (Int16)(-encodedLength);
                    value = value16;
                    encodedLength = __HEADER16_LENGTH;
                }
                else
                {
                    value = ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 3] << 0) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 2] << 8) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 16) |
                            ((Int32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 24);
                    encodedLength += __HEADER16_LENGTH;
                }
                decodedValue = value;
            }
            else // Unknown encoding
            {
                encodedLength = (Int16)buffer.Length;
            }

            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static byte[] Serialize(Int64 value)
        {
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= ENCODED16_VALUE_MAX)
            {
                Int16 encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.Int64Hdr16, encodedLength);
            }
            else if (value > ENCODED16_VALUE_MAX && value <= ENCODED32_VALUE_MAX)
            {
                Int32 encodedLength = (Int32)(-value);
                buffer = new byte[__HEADER32_LENGTH + 0];
                SetHeader32(buffer, FieldEncodingType.Int64Hdr32, encodedLength);
            }
            else
            {
                Int16 encodedLength = sizeof(Int64);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.Int64Hdr16Data, (Int16)encodedLength); ;
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

        public static Int64 DeserializeInt64(byte[] buffer, ref int fieldBufferBase)
        {
            Int64 decodedValue = default(Int64);
            Int64 value;

            Int32 encodedLength;
            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            switch (encoding)
            {
                case FieldEncodingType.Int64Hdr16:
                    {
                        encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                        value = -encodedLength;
                        encodedLength = __HEADER16_LENGTH;
                        decodedValue = value;
                        break;
                    }
                case FieldEncodingType.Int64Hdr32:
                    {
                        encodedLength = GetEncodedLength32(buffer, fieldBufferBase);
                        value = -encodedLength;
                        encodedLength = __HEADER32_LENGTH;
                        decodedValue = value;
                        break;
                    }
                case FieldEncodingType.Int64Hdr16Data:
                    {
                        encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                        value = ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 7] << 0) |
                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 6] << 8) |

                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 5] << 16) |
                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 4] << 24) |

                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 3] << 32) |
                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 2] << 40) |
                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 48) |
                                ((Int64)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 56);
                        encodedLength += __HEADER16_LENGTH;
                        decodedValue = value;
                        break;
                    }
                default: // e.g. FieldEncodingType.Unknown
                    {
                        encodedLength = buffer.Length;
                        break;
                    }
            }

            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static byte[] Serialize(UInt16 value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= ENCODED16_VALUE_MAX)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.UInt16Hdr16PlusMinus, encodedLength);
            }
            else
            {
                encodedLength = sizeof(Int16);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.UInt16Hdr16PlusMinus, encodedLength);
                buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 0);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 8);
            }

            return buffer;
        }

        public static UInt16 DeserializeUInt16(byte[] buffer, ref int fieldBufferBase)
        {
            UInt16 decodedValue = default(UInt16);
            UInt16 value;
            Int16 encodedLength;

            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (encoding >= FieldEncodingType.UInt16K0 && encoding <= FieldEncodingType.UInt16K60)
            {
                decodedValue = (UInt16)(encoding - FieldEncodingType.EnumK0);
                encodedLength = __HEADER8_LENGTH;
            }
            else if (encoding == FieldEncodingType.UInt16Hdr16PlusMinus)
            {
                encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    value = (UInt16)(-encodedLength);
                    encodedLength = __HEADER16_LENGTH;
                }
                else
                {
                    UInt32 value32 = ((UInt32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 0) |
                                     ((UInt32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 8);
                    value = (UInt16)value32;
                    encodedLength += __HEADER16_LENGTH;
                }

                decodedValue = value;
            }
            else // Unknown encoding
            {
                encodedLength = (Int16)buffer.Length;
            }

            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static byte[] Serialize(UInt32 value)
        {
            Int16 encodedLength;
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= (FieldEncodingType.UInt32K60 - FieldEncodingType.UInt32K0))
            {
                buffer = new byte[__HEADER8_LENGTH];
                SetFieldEncodingType(buffer, FieldEncodingType.UInt32K0 + (Int32)value);
            }
            else if (value >= 0 && value <= ENCODED16_VALUE_MAX)
            {
                encodedLength = (Int16)(-value);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.UInt32Hdr16PlusMinus, encodedLength);
            }
            else
            {
                encodedLength = sizeof(UInt32);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.UInt32Hdr16PlusMinus, encodedLength);
                buffer[__HEADER16_LENGTH + 3] = (byte)(value >> 0);
                buffer[__HEADER16_LENGTH + 2] = (byte)(value >> 8);
                buffer[__HEADER16_LENGTH + 1] = (byte)(value >> 16);
                buffer[__HEADER16_LENGTH + 0] = (byte)(value >> 24);
            }
            return buffer;
        }

        public static UInt32 DeserializeUInt32(byte[] buffer, ref int fieldBufferBase)
        {
            UInt32 decodedValue = default(Int32);
            UInt32 value;
            Int16 encodedLength;

            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (encoding >= FieldEncodingType.UInt32K0 && encoding <= FieldEncodingType.UInt32K60)
            {
                decodedValue = (UInt32)(encoding - FieldEncodingType.UInt32K0);
                encodedLength = __HEADER8_LENGTH;
            }
            else if (encoding == FieldEncodingType.UInt32Hdr16PlusMinus)
            {
                encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                if (encodedLength >= (Int16)(-ENCODED16_VALUE_MAX) && encodedLength <= 0)
                {
                    UInt32 value32 = (UInt32)(-encodedLength);
                    value = value32;
                    encodedLength = __HEADER16_LENGTH;
                }
                else
                {
                    value = ((UInt32)buffer[fieldBufferBase + __HEADER16_LENGTH + 3] << 0) |
                            ((UInt32)buffer[fieldBufferBase + __HEADER16_LENGTH + 2] << 8) |
                            ((UInt32)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 16) |
                            ((UInt32)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 24);
                    encodedLength += __HEADER16_LENGTH;
                }
                decodedValue = value;
            }
            else // Unknown encoding
            {
                encodedLength = (Int16)buffer.Length;
            }

            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static byte[] Serialize(UInt64 value)
        {
            byte[] buffer = default(byte[]);

            if (value >= 0 && value <= (FieldEncodingType.UInt64K60 - FieldEncodingType.UInt64K0))
            {
                buffer = new byte[__HEADER8_LENGTH];
                SetFieldEncodingType(buffer, FieldEncodingType.UInt64K0 + (Int32)value);
            }
            else if (value >= 0 && value <= (UInt64)ENCODED16_VALUE_MAX)
            {
                Int16 value16 = (Int16)value;
                Int16 encodedLength = (Int16)(-value16);
                buffer = new byte[__HEADER16_LENGTH + 0];
                SetHeader16(buffer, FieldEncodingType.UInt64Hdr16, encodedLength);
            }
            else if (value > (UInt64)ENCODED16_VALUE_MAX && value <= (UInt64)ENCODED32_VALUE_MAX)
            {
                Int32 value32 = (Int32)value;
                Int32 encodedLength = (Int32)(-value32);
                buffer = new byte[__HEADER32_LENGTH + 0];
                SetHeader32(buffer, FieldEncodingType.UInt64Hdr32, encodedLength);
            }
            else
            {
                Int16 encodedLength = sizeof(UInt64);
                buffer = new byte[__HEADER16_LENGTH + encodedLength];
                SetHeader16(buffer, FieldEncodingType.UInt64Hdr16Data, (Int16)encodedLength); ;
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

        public static UInt64 DeserializeUInt64(byte[] buffer, ref int fieldBufferBase)
        {
            UInt64 decodedValue = default(UInt64);
            UInt64 value;

            Int32 encodedLength;
            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            if (encoding >= FieldEncodingType.UInt64K0 && encoding <= FieldEncodingType.UInt64K60)
            {
                decodedValue = (UInt32)(encoding - FieldEncodingType.UInt64K0);
                encodedLength = __HEADER8_LENGTH;
            }
            else
            {
                switch (encoding)
                {
                    case FieldEncodingType.UInt64Hdr16:
                        {
                            encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                            value = (UInt64)(-encodedLength);
                            encodedLength = __HEADER16_LENGTH;
                            decodedValue = value;
                            break;
                        }
                    case FieldEncodingType.UInt64Hdr32:
                        {
                            encodedLength = GetEncodedLength32(buffer, fieldBufferBase);
                            value = (UInt64)(-encodedLength);
                            encodedLength = __HEADER32_LENGTH;
                            decodedValue = value;
                            break;
                        }
                    case FieldEncodingType.UInt64Hdr16Data:
                        {
                            encodedLength = GetEncodedLength16(buffer, fieldBufferBase);
                            value = ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 7] << 0) |
                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 6] << 8) |

                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 5] << 16) |
                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 4] << 24) |

                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 3] << 32) |
                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 2] << 40) |
                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 1] << 48) |
                                    ((UInt64)buffer[fieldBufferBase + __HEADER16_LENGTH + 0] << 56);
                            encodedLength += __HEADER16_LENGTH;
                            decodedValue = value;
                            break;
                        }
                    default: // e.g. FieldEncodingType.Unknown
                        {
                            encodedLength = buffer.Length;
                            break;
                        }
                }
            }

            fieldBufferBase += encodedLength;

            return decodedValue;
        }

        public static object Deserialize(byte[] buffer, ref int fieldBufferBase)
        {
            FieldEncodingType encoding = GetFieldEncodingType(buffer, fieldBufferBase);
            switch (encoding)
            {
                case FieldEncodingType.SByte:
                    return DeserializeSByte(buffer, ref fieldBufferBase);

                case FieldEncodingType.Byte:
                case FieldEncodingType.ByteK0:
                case FieldEncodingType.ByteK1:
                case FieldEncodingType.ByteK2:
                case FieldEncodingType.ByteK3:
                case FieldEncodingType.ByteK4:
                case FieldEncodingType.ByteK5:
                case FieldEncodingType.ByteK6:
                case FieldEncodingType.ByteK7:
                case FieldEncodingType.ByteK8:
                case FieldEncodingType.ByteK9:
                case FieldEncodingType.ByteK10:
                case FieldEncodingType.ByteK11:
                case FieldEncodingType.ByteK12:
                case FieldEncodingType.ByteK13:
                case FieldEncodingType.ByteK14:
                case FieldEncodingType.ByteK15:
                case FieldEncodingType.ByteK16:
                case FieldEncodingType.ByteK17:
                case FieldEncodingType.ByteK18:
                case FieldEncodingType.ByteK19:
                case FieldEncodingType.ByteK20:
                    return DeserializeByte(buffer, ref fieldBufferBase);

                case FieldEncodingType.ByteArrayHdr16:
                case FieldEncodingType.ByteArrayHdr16Data:
                case FieldEncodingType.ByteArrayHdr32:
                case FieldEncodingType.ByteArrayHdr32Data:
                    return DeserializeByteArray(buffer, ref fieldBufferBase);

                case FieldEncodingType.BooleanFalse:
                case FieldEncodingType.BooleanTrue:
                    return DeserializeBoolean(buffer, ref fieldBufferBase);

                case FieldEncodingType.Char:
                    return DeserializeChar(buffer, ref fieldBufferBase);

                case FieldEncodingType.String:
                    return DeserializeString(buffer, ref fieldBufferBase);

                case FieldEncodingType.ASCIIString:
                    return DeserializeASCIIString(buffer, ref fieldBufferBase);

                case FieldEncodingType.Address:
                    return DeserializeAddress(buffer, ref fieldBufferBase);

                case FieldEncodingType.Guid:
                    return DeserializeGuid(buffer, ref fieldBufferBase);

                case FieldEncodingType.EnumHdr16PlusMinus:
                case FieldEncodingType.EnumK0:
                case FieldEncodingType.EnumK1:
                case FieldEncodingType.EnumK2:
                case FieldEncodingType.EnumK3:
                case FieldEncodingType.EnumK4:
                case FieldEncodingType.EnumK5:
                case FieldEncodingType.EnumK6:
                case FieldEncodingType.EnumK7:
                case FieldEncodingType.EnumK8:
                case FieldEncodingType.EnumK9:
                case FieldEncodingType.EnumK10:
                    return DeserializeInt16(buffer, ref fieldBufferBase);

                case FieldEncodingType.Int16Hdr16PlusMinus:
                    return DeserializeInt16(buffer, ref fieldBufferBase);

                case FieldEncodingType.UInt16Hdr16PlusMinus:
                case FieldEncodingType.UInt16K0:
                case FieldEncodingType.UInt16K1:
                case FieldEncodingType.UInt16K2:
                case FieldEncodingType.UInt16K3:
                case FieldEncodingType.UInt16K4:
                case FieldEncodingType.UInt16K5:
                case FieldEncodingType.UInt16K6:
                case FieldEncodingType.UInt16K7:
                case FieldEncodingType.UInt16K8:
                case FieldEncodingType.UInt16K9:
                case FieldEncodingType.UInt16K10:
                case FieldEncodingType.UInt16K11:
                case FieldEncodingType.UInt16K12:
                case FieldEncodingType.UInt16K13:
                case FieldEncodingType.UInt16K14:
                case FieldEncodingType.UInt16K15:
                case FieldEncodingType.UInt16K16:
                case FieldEncodingType.UInt16K17:
                case FieldEncodingType.UInt16K18:
                case FieldEncodingType.UInt16K19:
                case FieldEncodingType.UInt16K20:
                case FieldEncodingType.UInt16K21:
                case FieldEncodingType.UInt16K22:
                case FieldEncodingType.UInt16K23:
                case FieldEncodingType.UInt16K24:
                case FieldEncodingType.UInt16K25:
                case FieldEncodingType.UInt16K26:
                case FieldEncodingType.UInt16K27:
                case FieldEncodingType.UInt16K28:
                case FieldEncodingType.UInt16K29:
                case FieldEncodingType.UInt16K30:
                case FieldEncodingType.UInt16K31:
                case FieldEncodingType.UInt16K32:
                case FieldEncodingType.UInt16K33:
                case FieldEncodingType.UInt16K34:
                case FieldEncodingType.UInt16K35:
                case FieldEncodingType.UInt16K36:
                case FieldEncodingType.UInt16K37:
                case FieldEncodingType.UInt16K38:
                case FieldEncodingType.UInt16K39:
                case FieldEncodingType.UInt16K40:
                case FieldEncodingType.UInt16K41:
                case FieldEncodingType.UInt16K42:
                case FieldEncodingType.UInt16K43:
                case FieldEncodingType.UInt16K44:
                case FieldEncodingType.UInt16K45:
                case FieldEncodingType.UInt16K46:
                case FieldEncodingType.UInt16K47:
                case FieldEncodingType.UInt16K48:
                case FieldEncodingType.UInt16K49:
                case FieldEncodingType.UInt16K50:
                case FieldEncodingType.UInt16K51:
                case FieldEncodingType.UInt16K52:
                case FieldEncodingType.UInt16K53:
                case FieldEncodingType.UInt16K54:
                case FieldEncodingType.UInt16K55:
                case FieldEncodingType.UInt16K56:
                case FieldEncodingType.UInt16K57:
                case FieldEncodingType.UInt16K58:
                case FieldEncodingType.UInt16K59:
                case FieldEncodingType.UInt16K60:
                    return DeserializeUInt16(buffer, ref fieldBufferBase);

                case FieldEncodingType.Int32Hdr16PlusMinus:
                case FieldEncodingType.Int32KMinus1:
                case FieldEncodingType.Int32K0:
                case FieldEncodingType.Int32K1:
                case FieldEncodingType.Int32K2:
                case FieldEncodingType.Int32K3:
                case FieldEncodingType.Int32K4:
                case FieldEncodingType.Int32K5:
                case FieldEncodingType.Int32K6:
                case FieldEncodingType.Int32K7:
                case FieldEncodingType.Int32K8:
                case FieldEncodingType.Int32K9:
                case FieldEncodingType.Int32K10:
                    return DeserializeInt32(buffer, ref fieldBufferBase);

                case FieldEncodingType.UInt32Hdr16PlusMinus:
                case FieldEncodingType.UInt32K0:
                case FieldEncodingType.UInt32K1:
                case FieldEncodingType.UInt32K2:
                case FieldEncodingType.UInt32K3:
                case FieldEncodingType.UInt32K4:
                case FieldEncodingType.UInt32K5:
                case FieldEncodingType.UInt32K6:
                case FieldEncodingType.UInt32K7:
                case FieldEncodingType.UInt32K8:
                case FieldEncodingType.UInt32K9:
                case FieldEncodingType.UInt32K10:
                case FieldEncodingType.UInt32K11:
                case FieldEncodingType.UInt32K12:
                case FieldEncodingType.UInt32K13:
                case FieldEncodingType.UInt32K14:
                case FieldEncodingType.UInt32K15:
                case FieldEncodingType.UInt32K16:
                case FieldEncodingType.UInt32K17:
                case FieldEncodingType.UInt32K18:
                case FieldEncodingType.UInt32K19:
                case FieldEncodingType.UInt32K20:
                case FieldEncodingType.UInt32K21:
                case FieldEncodingType.UInt32K22:
                case FieldEncodingType.UInt32K23:
                case FieldEncodingType.UInt32K24:
                case FieldEncodingType.UInt32K25:
                case FieldEncodingType.UInt32K26:
                case FieldEncodingType.UInt32K27:
                case FieldEncodingType.UInt32K28:
                case FieldEncodingType.UInt32K29:
                case FieldEncodingType.UInt32K30:
                case FieldEncodingType.UInt32K31:
                case FieldEncodingType.UInt32K32:
                case FieldEncodingType.UInt32K33:
                case FieldEncodingType.UInt32K34:
                case FieldEncodingType.UInt32K35:
                case FieldEncodingType.UInt32K36:
                case FieldEncodingType.UInt32K37:
                case FieldEncodingType.UInt32K38:
                case FieldEncodingType.UInt32K39:
                case FieldEncodingType.UInt32K40:
                case FieldEncodingType.UInt32K41:
                case FieldEncodingType.UInt32K42:
                case FieldEncodingType.UInt32K43:
                case FieldEncodingType.UInt32K44:
                case FieldEncodingType.UInt32K45:
                case FieldEncodingType.UInt32K46:
                case FieldEncodingType.UInt32K47:
                case FieldEncodingType.UInt32K48:
                case FieldEncodingType.UInt32K49:
                case FieldEncodingType.UInt32K50:
                case FieldEncodingType.UInt32K51:
                case FieldEncodingType.UInt32K52:
                case FieldEncodingType.UInt32K53:
                case FieldEncodingType.UInt32K54:
                case FieldEncodingType.UInt32K55:
                case FieldEncodingType.UInt32K56:
                case FieldEncodingType.UInt32K57:
                case FieldEncodingType.UInt32K58:
                case FieldEncodingType.UInt32K59:
                case FieldEncodingType.UInt32K60:
                    return DeserializeUInt32(buffer, ref fieldBufferBase);

                case FieldEncodingType.Int64Hdr16:
                case FieldEncodingType.Int64Hdr16Data:
                case FieldEncodingType.Int64Hdr32:
                    return DeserializeInt64(buffer, ref fieldBufferBase);

                case FieldEncodingType.UInt64Hdr16:
                case FieldEncodingType.UInt64Hdr16Data:
                case FieldEncodingType.UInt64Hdr32:
                case FieldEncodingType.UInt64K0:
                case FieldEncodingType.UInt64K1:
                case FieldEncodingType.UInt64K2:
                case FieldEncodingType.UInt64K3:
                case FieldEncodingType.UInt64K4:
                case FieldEncodingType.UInt64K5:
                case FieldEncodingType.UInt64K6:
                case FieldEncodingType.UInt64K7:
                case FieldEncodingType.UInt64K8:
                case FieldEncodingType.UInt64K9:
                case FieldEncodingType.UInt64K10:
                case FieldEncodingType.UInt64K11:
                case FieldEncodingType.UInt64K12:
                case FieldEncodingType.UInt64K13:
                case FieldEncodingType.UInt64K14:
                case FieldEncodingType.UInt64K15:
                case FieldEncodingType.UInt64K16:
                case FieldEncodingType.UInt64K17:
                case FieldEncodingType.UInt64K18:
                case FieldEncodingType.UInt64K19:
                case FieldEncodingType.UInt64K20:
                case FieldEncodingType.UInt64K21:
                case FieldEncodingType.UInt64K22:
                case FieldEncodingType.UInt64K23:
                case FieldEncodingType.UInt64K24:
                case FieldEncodingType.UInt64K25:
                case FieldEncodingType.UInt64K26:
                case FieldEncodingType.UInt64K27:
                case FieldEncodingType.UInt64K28:
                case FieldEncodingType.UInt64K29:
                case FieldEncodingType.UInt64K30:
                case FieldEncodingType.UInt64K31:
                case FieldEncodingType.UInt64K32:
                case FieldEncodingType.UInt64K33:
                case FieldEncodingType.UInt64K34:
                case FieldEncodingType.UInt64K35:
                case FieldEncodingType.UInt64K36:
                case FieldEncodingType.UInt64K37:
                case FieldEncodingType.UInt64K38:
                case FieldEncodingType.UInt64K39:
                case FieldEncodingType.UInt64K40:
                case FieldEncodingType.UInt64K41:
                case FieldEncodingType.UInt64K42:
                case FieldEncodingType.UInt64K43:
                case FieldEncodingType.UInt64K44:
                case FieldEncodingType.UInt64K45:
                case FieldEncodingType.UInt64K46:
                case FieldEncodingType.UInt64K47:
                case FieldEncodingType.UInt64K48:
                case FieldEncodingType.UInt64K49:
                case FieldEncodingType.UInt64K50:
                case FieldEncodingType.UInt64K51:
                case FieldEncodingType.UInt64K52:
                case FieldEncodingType.UInt64K53:
                case FieldEncodingType.UInt64K54:
                case FieldEncodingType.UInt64K55:
                case FieldEncodingType.UInt64K56:
                case FieldEncodingType.UInt64K57:
                case FieldEncodingType.UInt64K58:
                case FieldEncodingType.UInt64K59:
                case FieldEncodingType.UInt64K60:
                    return DeserializeUInt64(buffer, ref fieldBufferBase);

                case FieldEncodingType.EnumZeroDoNotUse:
                case FieldEncodingType.Unknown:
                case FieldEncodingType.Mapping:
                case FieldEncodingType.RESERVED1:
                case FieldEncodingType.RESERVED2:
                default:
                    fieldBufferBase += buffer.Length;
                    return null;
            }
        }
    }
}
