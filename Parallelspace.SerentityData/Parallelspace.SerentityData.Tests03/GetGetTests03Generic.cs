﻿using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

using Parallelspace.SerentityData;

namespace Parallelspace.SerentityData.Tests03
{
    [TestClass]
    public class GetGetTests03Generic
    {
        [TestInitialize]
        public void Initialize03Generic()
        {
        }

        [TestMethod]
        public void SignedBytes03Generic()
        {
            byte[] buffer;

            sbyte[] testcasesSBytes = { 0, 1, -1, 2, -2, 0xe, 0xf, 0x34, 0x45, 0x0,
                                            sbyte.MinValue, sbyte.MaxValue,
                                            0x07, 0x7F, 
                                            -0x07, -0x7F,
0,-0,
1,-1,
2,-2,
3,-3,
4,-4,
5,-5,
6,-6,
7,-7,
8,-8,
9,-9,
10,-10,
11,-11,
12,-12,
13,-13,
14,-14,
15,-15,
16,-16,
17,-17,
18,-18,
19,-19,
20,-20,
21,-21,
22,-22,
23,-23,
24,-24,
25,-25,
26,-26,
27,-27,
28,-28,
29,-29,
30,-30,
31,-31,
32,-32,
33,-33,
34,-34,
35,-35,
36,-36,
37,-37,
38,-38,
39,-39,
40,-40,
41,-41,
42,-42,
43,-43,
44,-44,
45,-45,
46,-46,
47,-47,
48,-48,
49,-49,
50,-50,
51,-51,
52,-52,
53,-53,
54,-54,
55,-55,
56,-56,
57,-57,
58,-58,
59,-59,
60,-60,
61,-61,
};

            foreach (sbyte testcase in testcasesSBytes)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                sbyte result = (sbyte)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= sbyte.MaxValue)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Byte)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), buffer.Length);
                }
            }

            foreach (sbyte testcase in testcasesSBytes)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                sbyte result;
                try
                {
                    result = (sbyte)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(sbyte);
                }
                if (testcase >= 0 && testcase <= sbyte.MaxValue)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(sbyte), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Byte)}");
                    Assert.AreEqual(default(sbyte), result);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), buffer.Length);
                }
            }
        }

        [TestMethod]
        public void UnsignedBytes03Generic()
        {
            byte[] buffer;

            byte[] testcasesBytes = { 0, 1, 2, 0xe, 0xf, 0x34, 0x45, 0x0, byte.MinValue, byte.MaxValue,
                                      0x07, 0x7F,
                                        0,
                                        1,
                                        2,
                                        3,
                                        4,
                                        5,
                                        6,
                                        7,
                                        8,
                                        9,
                                        10,
                                        11,
                                        12,
                                        13,
                                        14,
                                        15,
                                        16,
                                        17,
                                        18,
                                        19,
                                        20,
                                        21,
                                        22,
                                        23,
                                        24,
                                        25,
                                        26,
                                        27,
                                        28,
                                        29,
                                        30,
                                        31,
                                        32,
                                        33,
                                        34,
                                        35,
                                        36,
                                        37,
                                        38,
                                        39,
                                        40,
                                        41,
                                        42,
                                        43,
                                        44,
                                        45,
                                        46,
                                        47,
                                        48,
                                        49,
                                        50,
                                        51,
                                        52,
                                        53,
                                        54,
                                        55,
                                        56,
                                        57,
                                        58,
                                        59,
                                        60,
                                        61,
            };
            
            foreach (byte testcase in testcasesBytes)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                byte result = (byte)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= 20)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= byte.MaxValue)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Byte)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), buffer.Length);
                }
            }

            foreach (byte testcase in testcasesBytes)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                byte result;
                try
                {
                    result = (byte)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(byte);
                }
                if (testcase >= 0 && testcase <= 20)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(default(byte), result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= byte.MaxValue)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(byte), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Byte)}");
                    Assert.AreEqual(default(byte), result);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), buffer.Length);
                }
            }
        }

        [TestMethod]
        public void Chars03Generic()
        {
            byte[] buffer;

            char[] testcasesChar = { '\0', 'a', 'A', '安',
                                     'X', '\x0058', (char)88, '\u0058' };
            foreach (char testcase in testcasesChar)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                char result = (char)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(char)}");
                Assert.AreEqual(testcase, result);
                Assert.AreEqual(1 + 2 + sizeof(char), bufferOffset);
                Assert.AreEqual(1 + 2 + sizeof(char), buffer.Length);
            }

            foreach (char testcase in testcasesChar)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                char result;
                try
                {
                    result = (char)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(char);
                }
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(char)}");
                Assert.AreEqual(default(char), result);
                Assert.AreEqual(1 + 2 + sizeof(char), bufferOffset);
                Assert.AreEqual(1 + 2 + sizeof(char), buffer.Length);
            }
        }

        [TestMethod]
        public void SignedInts03Generic()
        {
            byte[] buffer;

            Int16[] testcasesInt16 = { 0, 1, -1, 2, -2, 0x3FFF, -0x3FFF, (0x3FFF+1), -(0x3FFF+1), 25000, -25000,
                                        FieldSerialization03.ENCODED16_VALUE_MAX - 1, FieldSerialization03.ENCODED16_VALUE_MAX, FieldSerialization03.ENCODED16_VALUE_MAX + 1,
                                        Int16.MinValue, Int16.MaxValue,
                                        0x07, 0x7F, 0x7F7F, 
                                        -0x07, -0x7F, -0x7F7F,
0,-0,
1,-1,
2,-2,
3,-3,
4,-4,
5,-5,
6,-6,
7,-7,
8,-8,
9,-9,
10,-10,
11,-11,
12,-12,
13,-13,
14,-14,
15,-15,
16,-16,
17,-17,
18,-18,
19,-19,
20,-20,
21,-21,
22,-22,
23,-23,
24,-24,
25,-25,
26,-26,
27,-27,
28,-28,
29,-29,
30,-30,
31,-31,
32,-32,
33,-33,
34,-34,
35,-35,
36,-36,
37,-37,
38,-38,
39,-39,
40,-40,
41,-41,
42,-42,
43,-43,
44,-44,
45,-45,
46,-46,
47,-47,
48,-48,
49,-49,
50,-50,
51,-51,
52,-52,
53,-53,
54,-54,
55,-55,
56,-56,
57,-57,
58,-58,
59,-59,
60,-60,
61,-61,
};
        
            foreach (Int16 testcase in testcasesInt16)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Int16 result = (Int16)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Int16)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(Int16), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Int16), buffer.Length);
                }
            }

            foreach (Int16 testcase in testcasesInt16)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                Int16 result;
                try
                {
                    result = (Int16)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(Int16);
                }
                if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(Int16), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Int16)}");
                    Assert.AreEqual(default(Int16), result);
                    Assert.AreEqual(1 + 2 + sizeof(Int16), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Int16), buffer.Length);
                }
            }

            Int32[] testcasesInt32 = { 0, 1, -1, 2, -2, 0x3FFF, -0x3FFF, (0x3FFF+1), -(0x3FFF+1), 25000, -25000,
                                        FieldSerialization03.ENCODED16_VALUE_MAX - 1, FieldSerialization03.ENCODED16_VALUE_MAX, FieldSerialization03.ENCODED16_VALUE_MAX + 1,
                                        FieldSerialization03.ENCODED32_VALUE_MAX - 1, FieldSerialization03.ENCODED32_VALUE_MAX, FieldSerialization03.ENCODED32_VALUE_MAX + 1,
                                        Int16.MinValue, Int16.MaxValue,
                                        Int32.MinValue, Int32.MaxValue,
                                        UInt16.MinValue, UInt16.MaxValue,
                                        0x07, 0x7F, 0x7F7F, 0x7F7F7F, 0x7F7F7F7F, 
                                        -0x07, -0x7F, -0x7F7F, -0x7F7F7F, -0x7F7F7F7F,
0,-0,
1,-1,
2,-2,
3,-3,
4,-4,
5,-5,
6,-6,
7,-7,
8,-8,
9,-9,
10,-10,
11,-11,
12,-12,
13,-13,
14,-14,
15,-15,
16,-16,
17,-17,
18,-18,
19,-19,
20,-20,
21,-21,
22,-22,
23,-23,
24,-24,
25,-25,
26,-26,
27,-27,
28,-28,
29,-29,
30,-30,
31,-31,
32,-32,
33,-33,
34,-34,
35,-35,
36,-36,
37,-37,
38,-38,
39,-39,
40,-40,
41,-41,
42,-42,
43,-43,
44,-44,
45,-45,
46,-46,
47,-47,
48,-48,
49,-49,
50,-50,
51,-51,
52,-52,
53,-53,
54,-54,
55,-55,
56,-56,
57,-57,
58,-58,
59,-59,
60,-60,
61,-61,
};

            foreach (Int32 testcase in testcasesInt32)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Int32 result = (Int32)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= -1 && testcase <= 10)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Int32)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(Int32), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Int32), buffer.Length);
                }
            }

            foreach (Int32 testcase in testcasesInt32)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                Int32 result;
                try
                {
                    result = (Int32)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(Int32);
                }
                if (testcase >= -1 && testcase <= 10)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(default(Int32), result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(Int32), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Int32)}");
                    Assert.AreEqual(default(Int32), result);
                    Assert.AreEqual(1 + 2 + sizeof(Int32), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Int32), buffer.Length);
                }
            }

            Int64[] testcasesInt64 = { 1, 0, 1, -1, 2, -2, 0x3FFF, -0x3FFF, (0x3FFF+1), -(0x3FFF+1), 25000, -25000,
                                        FieldSerialization03.ENCODED16_VALUE_MAX - 1, FieldSerialization03.ENCODED16_VALUE_MAX, FieldSerialization03.ENCODED16_VALUE_MAX + 1,
                                        FieldSerialization03.ENCODED32_VALUE_MAX - 1, FieldSerialization03.ENCODED32_VALUE_MAX, FieldSerialization03.ENCODED32_VALUE_MAX + 1,
                                        Int16.MinValue, Int16.MaxValue,
                                        Int32.MinValue, Int32.MaxValue,
                                        Int64.MinValue, Int64.MaxValue,
                                        UInt16.MinValue, UInt16.MaxValue,
                                        UInt32.MinValue, UInt32.MaxValue,
                                        0x07, 0x7F, 0x7F7F, 0x7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F7F, 0x7F7F7F7F7F7F, 0x7F7F7F7F7F7F7F, 0x7F7F7F7F7F7F7F7F,
                                        -0x07, -0x7F, -0x7F7F, -0x7F7F7F, -0x7F7F7F7F, -0x7F7F7F7F7F, -0x7F7F7F7F7F7F, -0x7F7F7F7F7F7F7F, -0x7F7F7F7F7F7F7F7F,
0,-0,
1,-1,
2,-2,
3,-3,
4,-4,
5,-5,
6,-6,
7,-7,
8,-8,
9,-9,
10,-10,
11,-11,
12,-12,
13,-13,
14,-14,
15,-15,
16,-16,
17,-17,
18,-18,
19,-19,
20,-20,
21,-21,
22,-22,
23,-23,
24,-24,
25,-25,
26,-26,
27,-27,
28,-28,
29,-29,
30,-30,
31,-31,
32,-32,
33,-33,
34,-34,
35,-35,
36,-36,
37,-37,
38,-38,
39,-39,
40,-40,
41,-41,
42,-42,
43,-43,
44,-44,
45,-45,
46,-46,
47,-47,
48,-48,
49,-49,
50,-50,
51,-51,
52,-52,
53,-53,
54,-54,
55,-55,
56,-56,
57,-57,
58,-58,
59,-59,
60,-60,
61,-61,
};

            foreach (Int64 testcase in testcasesInt64)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Int64 result = (Int64)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase > 0x3FFF && testcase <= 0x0fffffff)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Int64)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(Int64), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Int64), buffer.Length);
                }
            }

            foreach (Int64 testcase in testcasesInt64)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                Int64 result;
                try
                {
                    result = (Int64)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(Int64);
                }
                if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(Int64), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase > 0x3FFF && testcase <= 0x0fffffff)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + 0}");
                    Assert.AreEqual(default(Int64), result);
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Int64)}");
                    Assert.AreEqual(default(Int64), result);
                    Assert.AreEqual(1 + 2 + sizeof(Int64), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Int64), buffer.Length);
                }
            }
        }

        [TestMethod]
        public void UnsignedInts03Generic()
        {
            byte[] buffer;

            UInt16[] testcasesUInt16 = { 0, 1, 10, 2, 20, 0x3FFF, (0x3FFF+1), 25000,
                                           UInt16.MinValue, UInt16.MaxValue,
                                           0x07, 0x7F, 0x7F7F,
                                        0,
                                        1,
                                        2,
                                        3,
                                        4,
                                        5,
                                        6,
                                        7,
                                        8,
                                        9,
                                        10,
                                        11,
                                        12,
                                        13,
                                        14,
                                        15,
                                        16,
                                        17,
                                        18,
                                        19,
                                        20,
                                        21,
                                        22,
                                        23,
                                        24,
                                        25,
                                        26,
                                        27,
                                        28,
                                        29,
                                        30,
                                        31,
                                        32,
                                        33,
                                        34,
                                        35,
                                        36,
                                        37,
                                        38,
                                        39,
                                        40,
                                        41,
                                        42,
                                        43,
                                        44,
                                        45,
                                        46,
                                        47,
                                        48,
                                        49,
                                        50,
                                        51,
                                        52,
                                        53,
                                        54,
                                        55,
                                        56,
                                        57,
                                        58,
                                        59,
                                        60,
                                        61
                                       };

            foreach (UInt16 testcase in testcasesUInt16)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                UInt16 result = (UInt16)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(UInt16)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(UInt16), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(UInt16), buffer.Length);
                }
            }

            foreach (UInt16 testcase in testcasesUInt16)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                UInt16 result;
                try
                {
                    result = (UInt16)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(UInt16);
                }
                if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(UInt16), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(UInt16)}");
                    Assert.AreEqual(default(UInt16), result);
                    Assert.AreEqual(1 + 2 + sizeof(UInt16), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(UInt16), buffer.Length);
                }
            }

            UInt32[] testcasesUInt32 = { 0, 1, 10, 2, 20, 0x3FFF, (0x3FFF+1), 25000,
                                            UInt16.MinValue, UInt16.MaxValue,
                                            UInt32.MinValue, UInt32.MaxValue,
                                            0x07, 0x7F, 0x7F7F, 0x7F7F7F, 0x7F7F7F7F, 
                                       };
            foreach (UInt32 testcase in testcasesUInt32)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                UInt32 result = (UInt32)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= 60)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(UInt32)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(UInt32), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(UInt32), buffer.Length);
                }
            }

            foreach (UInt32 testcase in testcasesUInt32)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                UInt32 result;
                try
                {
                    result = (UInt32)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(UInt32);
                }
                if (testcase >= 0 && testcase <= 60)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(default(UInt32), result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(UInt32), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(UInt32)}");
                    Assert.AreEqual(default(UInt32), result);
                    Assert.AreEqual(1 + 2 + sizeof(UInt32), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(UInt32), buffer.Length);
                }
            }

            UInt64[] testcasesUInt64 = { 0, 1, 10, 2, 20, 0x3FFF, (0x3FFF+1), 25000,
                                            (UInt64)FieldSerialization03.ENCODED16_VALUE_MAX - 1, (UInt64)FieldSerialization03.ENCODED16_VALUE_MAX, (UInt64)FieldSerialization03.ENCODED16_VALUE_MAX + 1,
                                            (UInt64)FieldSerialization03.ENCODED32_VALUE_MAX - 1, (UInt64)FieldSerialization03.ENCODED32_VALUE_MAX, (UInt64)FieldSerialization03.ENCODED32_VALUE_MAX + 1,
                                            (UInt64)Int16.MaxValue, Int32.MaxValue, Int64.MaxValue,
                                            UInt16.MinValue, UInt16.MaxValue,
                                            UInt32.MinValue, UInt32.MaxValue,
                                            UInt64.MinValue, UInt64.MaxValue,
                                            0x07, 0x7F, 0x7F7F, 0x7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F7F, 0x7F7F7F7F7F7F, 0x7F7F7F7F7F7F7F, 0x7F7F7F7F7F7F7F7F,
                                        0,
                                        1,
                                        2,
                                        3,
                                        4,
                                        5,
                                        6,
                                        7,
                                        8,
                                        9,
                                        10,
                                        11,
                                        12,
                                        13,
                                        14,
                                        15,
                                        16,
                                        17,
                                        18,
                                        19,
                                        20,
                                        21,
                                        22,
                                        23,
                                        24,
                                        25,
                                        26,
                                        27,
                                        28,
                                        29,
                                        30,
                                        31,
                                        32,
                                        33,
                                        34,
                                        35,
                                        36,
                                        37,
                                        38,
                                        39,
                                        40,
                                        41,
                                        42,
                                        43,
                                        44,
                                        45,
                                        46,
                                        47,
                                        48,
                                        49,
                                        50,
                                        51,
                                        52,
                                        53,
                                        54,
                                        55,
                                        56,
                                        57,
                                        58,
                                        59,
                                        60,
                                        61
                                       };

            foreach (UInt64 testcase in testcasesUInt64)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                UInt64 result = (UInt64)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && testcase <= 60)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase > 0x3FFF && testcase <= 0x0fffffff)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(UInt64)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(UInt64), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(UInt64), buffer.Length);
                }
            }

            foreach (UInt64 testcase in testcasesUInt64)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                UInt64 result;
                try
                {
                    result = (UInt64)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(UInt64);
                }
                if (testcase >= 0 && testcase <= 60)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                    Assert.AreEqual(default(UInt64), result);
                    Assert.AreEqual(1, bufferOffset);
                    Assert.AreEqual(1, buffer.Length);
                }
                else if (testcase >= 0 && testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(default(UInt64), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase > 0x3FFF && testcase <= 0x0fffffff)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + 0}");
                    Assert.AreEqual(default(UInt64), result);
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(UInt64)}");
                    Assert.AreEqual(default(UInt64), result);
                    Assert.AreEqual(1 + 2 + sizeof(UInt64), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(UInt64), buffer.Length);
                }
            }
        }

        [TestMethod]
        public void Addresses03Generic()
        {
            byte[] buffer;

            Address[] testcasesAddress = { /* null, */ new Address(),
                new Address("`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./ "),
                new Address(null), new Address(String.Empty), new Address(""),
                new Address("1"), new Address("0123456789"),
                new Address("mrTNM1QJZ8HS6ZmCsjg8tPpkTZxmEh6vCN"), new Address("muZUbfUzcDQ6s7ivNGb2b3BcKRNzmioMym") };

            foreach (Address testcase in testcasesAddress)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Address result = (Address)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase.Value == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value (null)\t{Helpers.ToHex(buffer)}\t'{result.Value}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0 * 2}");
                    Assert.IsNull(result.Value);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase == testcasesAddress[1])
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value '{testcase.Value}'\t{Helpers.ToHex(buffer)}\t'{result.Value}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Value.Length}");
                    Assert.AreEqual("?????????????????????????????????", result.Value);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value '{testcase.Value}'\t{Helpers.ToHex(buffer)}\t'{result.Value}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Value.Length}");
                    Assert.AreEqual(testcase.Value, result.Value);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, buffer.Length);
                }
            }

            foreach (Address testcase in testcasesAddress)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                Address result = (Address)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase.Value == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value-U (null)\t{Helpers.ToHex(buffer)}\t'(null)'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0 * 2}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value '{testcase.Value}'\t{Helpers.ToHex(buffer)}\t'(null)'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Value.Length}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void Strings03Generic()
        {
            byte[] buffer;

            String[] testcasesString = { null, String.Empty, "", "1", "0123456789",
                "a", "安",
                "The quick brown fox jumps over the lazy dog", "`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./ ",
                "安全审计公司Red4Sec近期在一些NEP-5的合约代码中发现了一种存储注入漏洞，攻击者可利用该漏洞进行攻击" };

            foreach (String testcase in testcasesString)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                String result = (String)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} (null)\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0 }");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} '{testcase}'\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length * 2}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, buffer.Length);
                }
            }

            foreach (String testcase in testcasesString)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                String result = (String)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U (null)\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0 }");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U '{testcase}'\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length * 2}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void StringLengths03Generic()
        {
            byte[] buffer;

            int[] testcasestringsizes = { 1, 2, 3, 4, 5,
                                        FieldSerialization03.ENCODED16_VALUE_MAX-1, FieldSerialization03.ENCODED16_VALUE_MAX, FieldSerialization03.ENCODED16_VALUE_MAX+1,
                                        (FieldSerialization03.ENCODED16_VALUE_MAX/2)-1, (FieldSerialization03.ENCODED16_VALUE_MAX/2), (FieldSerialization03.ENCODED16_VALUE_MAX/2)+1,
                                        FieldSerialization03.ENCODED32_VALUE_MAX-1, FieldSerialization03.ENCODED32_VALUE_MAX, FieldSerialization03.ENCODED32_VALUE_MAX+1,
                                        (FieldSerialization03.ENCODED32_VALUE_MAX/2)-1, (FieldSerialization03.ENCODED32_VALUE_MAX/2), (FieldSerialization03.ENCODED32_VALUE_MAX/2)+1,
                                        100, 1*1000, 10*1000, 100*1000,
                                        1*1000000, 10*1000000, 100*1000000, 1000*1000000,
                                        Int16.MaxValue-1, Int16.MaxValue, Int16.MaxValue+1,
                                        UInt16.MaxValue-1, UInt16.MaxValue, UInt16.MaxValue+1,
                                        /* Int32.MaxValue-1, Int32.MaxValue */ };

            foreach (int stringsize in testcasestringsizes)
            {
                char[] testcasechar = new char[stringsize];
                Array.Fill<char>(testcasechar, '安');
                string testcase = new String(testcasechar);
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                String result = (String)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'(null)'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 1)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length * 2}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, buffer.Length);
                }
                else if (testcase.Length == 2)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length * 2}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, buffer.Length);
                }
                else if (testcase.Length == 3)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length * 2}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, buffer.Length);
                }
                else if (testcase.Length >= 4 && testcase.Length * 2 <= FieldSerialization03.ENCODED16_VALUE_MAX)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{testcase.Length}'\t\t''\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length * 2, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{testcase.Length}'\t\t''\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + testcase.Length}");
                    Assert.AreEqual("", Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void ASCIIStrings03Generic()
        {
            byte[] buffer;

            String[] testcasesASCIIString = { null, String.Empty, "", "1", "0123456789",
                "a", 
                "The quick brown fox jumps over the lazy dog", "`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./ ",
                "安",
                "安全审计公司Red4Sec近期在一些NEP-5的合约代码中发现了一种存储注入漏洞，攻击者可利用该漏洞进行攻击" };

            foreach (String testcase in testcasesASCIIString)
            {
                buffer = FieldSerialization03.Serialize(testcase, false);
                int bufferOffset = 0;
                String result = (String)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} (null)\t{Helpers.ToHex(testcase)}\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase == testcasesASCIIString[testcasesASCIIString.Length - 1])
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} '{testcase}'\t{Helpers.ToHex(testcase)}\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual("??????Red4Sec?????NEP-5???????????????????????????????", result);
                    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                }
                else if (testcase == testcasesASCIIString[testcasesASCIIString.Length - 2])
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} '{testcase}'\t{Helpers.ToHex(testcase)}\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual("?", result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 1)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} '{testcase}'\t{Helpers.ToHex(testcase)}\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} '{testcase}'\t{Helpers.ToHex(testcase)}\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                }
            }

            foreach (String testcase in testcasesASCIIString)
            {
                buffer = FieldSerialization03.Serialize(testcase, false);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                String result = (String)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U (null)\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                //else if (testcase == testcasesASCIIString[7])
                //{
                //    Debug.WriteLine($"{FieldSerialization03.GetFieldType(buffer, 0)}-U '{testcase}'\t{FieldSerializer.ToHexString(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                //    Assert.AreEqual("??????Red4Sec?????NEP-5???????????????????????????????", result);
                //    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                //    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                //}
                else if (testcase.Length == 1)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U '{testcase}'\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U '{testcase}'\t{Helpers.ToHex(buffer)}\t'{result}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void ByteArrays03Generic()
        {
            byte[] buffer;

            byte[][] testcasesByteArray = { null, Array.Empty<byte>(),
                                            new byte[] { 0x0 }, new byte[] { 0x1 }, new byte[] { 0xff },
                                            new byte[] { 0 }, new byte[] { 1 }, new byte[] { 255 },
                                            new byte[] { byte.MinValue }, new byte[] { byte.MaxValue },
                                            new byte[] { 0x1, 0x2 }, new byte[] { 0x1, 0x2, 0x3 }, new byte[] { 0x1, 0x2, 0x3, 0x4 }, new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5 },
                                            BitConverter.GetBytes(7), BitConverter.GetBytes(16),  BitConverter.GetBytes(1000) };

            foreach (byte[] testcase in testcasesByteArray)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                byte[] result = (byte[])FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.a\t'(null)'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 0)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.b\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 1)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.c\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 2 || testcase.Length == 3)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.c\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + 0}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.d\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                }
            }

            foreach (byte[] testcase in testcasesByteArray)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                byte[] result = (byte[])FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U '(null)'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 1)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U '{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 2 || testcase.Length == 3)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.c\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U '{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void ByteArrayLengths03Generic()
        {
            byte[] buffer;

            int[] testcasebytesizes = { 1, 2, 3, 4, 5, 
                                        FieldSerialization03.ENCODED16_VALUE_MAX-1, FieldSerialization03.ENCODED16_VALUE_MAX, FieldSerialization03.ENCODED16_VALUE_MAX+1,
                                        FieldSerialization03.ENCODED32_VALUE_MAX-1, FieldSerialization03.ENCODED32_VALUE_MAX, FieldSerialization03.ENCODED32_VALUE_MAX+1,
                                        100, 1*1000, 10*1000, 100*1000,
                                        1*1000000, 10*1000000, 100*1000000, 1000*1000000,
                                        Int16.MaxValue-1, Int16.MaxValue, Int16.MaxValue+1,
                                        UInt16.MaxValue-1, UInt16.MaxValue, UInt16.MaxValue+1,
                                        /* Int32.MaxValue-1, Int32.MaxValue */ };

            foreach (int bytesize in testcasebytesizes)
            {
                byte[] testcase = new byte[bytesize];
                Array.Fill<byte>(testcase, 0x7f);
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                byte[] result = (byte[])FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'(null)'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.IsNull(result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 1)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else if (testcase.Length == 2)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else if (testcase.Length == 3)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{Helpers.ToHex(testcase)}'\t{Helpers.ToHex(buffer)}\t'{Helpers.ToHex(result)}'\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 4 + 0, bufferOffset);
                    Assert.AreEqual(1 + 4 + 0, buffer.Length);
                }
                else if (testcase.Length >= 4 && testcase.Length <= FieldSerialization03.ENCODED16_VALUE_MAX)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{testcase.Length}'\t\t''\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 2 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Length, buffer.Length);
                }
                else if(testcase.Length > FieldSerialization03.ENCODED16_VALUE_MAX && testcase.Length <= FieldSerialization03.ENCODED32_VALUE_MAX)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{testcase.Length}'\t\t''\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + testcase.Length}");
                    Assert.AreEqual(Helpers.ToHex(testcase), Helpers.ToHex(result));
                    Assert.AreEqual(1 + 4 + testcase.Length, bufferOffset);
                    Assert.AreEqual(1 + 4 + testcase.Length, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}\t'{testcase.Length}'\t\t''\t{bufferOffset}\t{buffer.Length}\t{1 + 4 + testcase.Length}");
                    Assert.AreEqual(null, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void Enums03Generic()
        {
            byte[] buffer;

            TestEnum[] testcasesEnum = { TestEnum.red, TestEnum.red,
                                         TestEnum.green, TestEnum.green,
                                         TestEnum.blue, TestEnum.blue
                                       };

            foreach (TestEnum testcase in testcasesEnum)
            {
                buffer = FieldSerialization03.Serialize((Int16)testcase, true);
                int bufferOffset = 0;
                TestEnum result = (TestEnum)(Int16)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                if (testcase >= 0 && (Int16)testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Byte)}");
                    Assert.AreEqual(testcase, result);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), buffer.Length);
                }
            }

            foreach (TestEnum testcase in testcasesEnum)
            {
                buffer = FieldSerialization03.Serialize((Int16)testcase, true);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                TestEnum result;
                try
                {
                    result = (TestEnum)(Int16)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = (TestEnum)default(Int16);
                }
                if (testcase >= 0 && (Int16)testcase <= 0x3FFF)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0}");
                    Assert.AreEqual((TestEnum)default(Int16), result);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(Byte)}");
                    Assert.AreEqual((TestEnum)default(Int16), result);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), bufferOffset);
                    Assert.AreEqual(1 + 2 + sizeof(Byte), buffer.Length);
                }
            }
        }

        [TestMethod]
        public void Guid03Generic()
        {
            byte[] buffer;

            byte[] zero16Bytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                              0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, };
            byte[] BB16Bytes = { 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB,
                                      0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, };
            Guid newGuid = Guid.NewGuid();
            Guid zeroGuid = new Guid(zero16Bytes);
            Guid sevenSevenGuid = new Guid(BB16Bytes);

            Guid[] testcasesGuid = { new Guid(), Guid.Empty, newGuid, zeroGuid, sevenSevenGuid };
            foreach (Guid testcase in testcasesGuid)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Guid result = (Guid)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 16}");
                Assert.AreEqual(testcase, result);
                Assert.AreEqual(1 + 2 + 16, bufferOffset);
                Assert.AreEqual(1 + 2 + 16, buffer.Length);
            }

            foreach (Guid testcase in testcasesGuid)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                Guid result;
                try
                {
                    result = (Guid)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = default(Guid);
                }
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 16}");
                Assert.AreEqual(default(Guid), result);
                Assert.AreEqual(1 + 2 + 16, bufferOffset);
                Assert.AreEqual(1 + 2 + 16, buffer.Length);
            }
        }

        [TestMethod]
        public void Booleans03Generic()
        {
            byte[] buffer;

            Boolean[] testcasesBoolean = { 0 == 0, 0 == 1, true, false };
            foreach (Boolean testcase in testcasesBoolean)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Boolean result = (Boolean)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)} {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                Assert.AreEqual(testcase, result);
                Assert.AreEqual(1, bufferOffset);
                Assert.AreEqual(1, buffer.Length);
            }

            foreach (Boolean testcase in testcasesBoolean)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                buffer[0] = (byte)FieldSerialization03.FieldEncodingType.Unknown;
                int bufferOffset = 0;
                Boolean result;
                try
                {
                    result = (Boolean)FieldSerialization03.Deserialize(buffer, ref bufferOffset);
                }
                catch
                {
                    result = false;
                }
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                Assert.IsFalse(result);
                Assert.AreEqual(1, bufferOffset);
                Assert.AreEqual(1, buffer.Length);
            }
        }
    }
}
