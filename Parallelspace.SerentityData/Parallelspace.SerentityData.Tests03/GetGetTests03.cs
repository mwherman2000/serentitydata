﻿using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

using Parallelspace.SerentityData;

namespace Parallelspace.SerentityData.Tests03
{
    public enum TestEnum { red, green, blue }

    public class AllFieldsClass
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Tests" + "." + "AllFieldsClass" + " " + "v1.0";
        public static readonly byte[] ENTITY_TYPE = SHA256Managed.Create().ComputeHash(Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME));

        // Header data fields
        public byte __serializationsignature;
        public byte __serializationversion;
        public byte __converterversion;
        public EntitySerialization03.EntityState __entitystate;
        public byte __nfields;

        // System data fields
        public byte[] __entitytypehash;
        public Int64 __created;
        public Int64 __modified;
        public Int64 __changeindex;

        // Entity data fields
        public const int __NENTITYFIELDS = 15;
        public char ch1 = 'c';
        public bool f1 = true;
        public byte b1 = byte.MinValue;
        public sbyte sb1 = sbyte.MinValue;
        public short s1 = short.MinValue;
        public int i1 = int.MinValue;
        public long l1 = long.MinValue;
        public ushort us1 = ushort.MaxValue;
        public uint ui1 = uint.MaxValue;
        public ulong ul1 = ulong.MaxValue;
        public string str1 = "Hello world!";
        public string asciistr1 = "Hello world!";
        public byte[] ba1 = { 0x1, 0x2, 0x3, 0x1, 0x2, 0x3, 0x1, 0x2, 0x3 };
        public Address a1 = new Address("mrTNM1QJZ8HS6ZmCsjg8tPpkTZxmEh6vCN");
        public TestEnum e1 = TestEnum.blue;

        public EntitySerialization03.EntityState OnChangeState(EntitySerialization03.EntityState newState)
        {
            EntitySerialization03.EntityState prevState = __entitystate;
            OnChangeFieldValue(EntitySerialization03.FieldIndices.HEADERFIELDS, newState);
            return prevState;
        }

        public EntitySerialization03.EntityState OnChangeFieldValue(EntitySerialization03.FieldIndices eField, EntitySerialization03.EntityState newState = EntitySerialization03.EntityState.SET)
        {
            EntitySerialization03.EntityState prevState = __entitystate;
            if (newState != EntitySerialization03.EntityState.DONTCHANGESTATE) __entitystate = newState;
            __modified = DateTime.UtcNow.Ticks;
            __changeindex++;
            return prevState;
        }

        public EntitySerialization03.EntityState OnChangeAllFieldValues(EntitySerialization03.EntityState newState = EntitySerialization03.EntityState.SET)
        {
            EntitySerialization03.EntityState prevState = __entitystate;
            for (int fi = (int)EntitySerialization03.FieldIndices.HEADERFIELDS; fi < __nfields; fi++)
                OnChangeFieldValue((EntitySerialization03.FieldIndices)fi, newState);
            return prevState;
        }
    }

    [TestClass]
    public class GetGetTests03
    {
        public AllFieldsClass e1 = null;

        public byte[] SerializeAllFields(AllFieldsClass e, out int bufferLength)
        {
            AllFieldsDump(e);

            int __entitytypehashFieldBufferLength = FieldSerialization03.Serialize(e.__entitytypehash).Length;
            int __createdFieldBufferLength = FieldSerialization03.Serialize(e.__created).Length;
            int __modifiedFieldBufferLength = FieldSerialization03.Serialize(e.__modified).Length;
            int __changeindexFieldBufferLength = FieldSerialization03.Serialize(e.__changeindex).Length;

            int a1FieldBufferLength = FieldSerialization03.Serialize(e.a1).Length;
            int b1FieldBufferLength = FieldSerialization03.Serialize(e.b1).Length;
            int ba1FieldBufferLength = FieldSerialization03.Serialize(e.ba1).Length;
            int ch1FieldBufferLength = FieldSerialization03.Serialize(e.ch1).Length;
            int e1FieldBufferLength = FieldSerialization03.Serialize((Int16)e.e1, true).Length;
            int f1FieldBufferLength = FieldSerialization03.Serialize(e.f1).Length;
            int i1FieldBufferLength = FieldSerialization03.Serialize(e.i1).Length;
            int l1FieldBufferLength = FieldSerialization03.Serialize(e.l1).Length;
            int s1FieldBufferLength = FieldSerialization03.Serialize(e.s1).Length;
            int sb1FieldBufferLength = FieldSerialization03.Serialize(e.sb1).Length;
            int str1FieldBufferLength = FieldSerialization03.Serialize(e.str1).Length;
            int asciistr1FieldBufferLength = FieldSerialization03.Serialize(e.asciistr1, false).Length;
            int ui1FieldBufferLength = FieldSerialization03.Serialize(e.ui1).Length;
            int ul1FieldBufferLength = FieldSerialization03.Serialize(e.ul1).Length;
            int us1FieldBufferLength = FieldSerialization03.Serialize(e.us1).Length;

            Debug.WriteLine($"__entitytypehashFieldBufferLength:\t{__entitytypehashFieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.__entitytypehash))}");
            Debug.WriteLine($"__createdFieldBufferLength:\t{__createdFieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.__created))}");
            Debug.WriteLine($"__modifiedFieldBufferLength:\t{__modifiedFieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.__modified))}");
            Debug.WriteLine($"__changeindexFieldBufferLength:\t{__changeindexFieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.__changeindex))}");

            Debug.WriteLine($"a1FieldBufferLength:\t{a1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.a1))}");
            Debug.WriteLine($"b1FieldBufferLength:\t{b1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.b1))}");
            Debug.WriteLine($"ba1FieldBufferLength:\t{ba1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.ba1))}");
            Debug.WriteLine($"ch1FieldBufferLength:\t{ch1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.ch1))}");
            Debug.WriteLine($"e1FieldBufferLength:\t{e1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize((Int16)e1.e1,true))}");
            Debug.WriteLine($"f1FieldBufferLength:\t{f1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.f1))}");
            Debug.WriteLine($"i1FieldBufferLength:\t{i1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.i1))}");
            Debug.WriteLine($"l1FieldBufferLength:\t{l1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.l1))}");
            Debug.WriteLine($"s1FieldBufferLength:\t{s1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.s1))}");
            Debug.WriteLine($"sb1FieldBufferLength:\t{sb1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.sb1))}");
            Debug.WriteLine($"str1FieldBufferLength:\t{str1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.str1))}");
            Debug.WriteLine($"asciistr1FieldBufferLength:\t{asciistr1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.asciistr1,false))}");
            Debug.WriteLine($"ui1FieldBufferLength:\t{ui1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.ui1))}");
            Debug.WriteLine($"ul1FieldBufferLength:\t{ul1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.ul1))}");
            Debug.WriteLine($"us1FieldBufferLength:\t{us1FieldBufferLength}\t{Helpers.ToHex(FieldSerialization03.Serialize(e1.us1))}");

            bufferLength = EntitySerialization03.NHEADERFIELDS * sizeof(byte)
                + __entitytypehashFieldBufferLength
                + __createdFieldBufferLength
                + __modifiedFieldBufferLength
                + __changeindexFieldBufferLength
                + a1FieldBufferLength
                + b1FieldBufferLength
                + ba1FieldBufferLength
                + ch1FieldBufferLength
                + e1FieldBufferLength
                + f1FieldBufferLength
                + i1FieldBufferLength
                + l1FieldBufferLength
                + s1FieldBufferLength
                + sb1FieldBufferLength
                + str1FieldBufferLength
                + asciistr1FieldBufferLength
                + ui1FieldBufferLength
                + ul1FieldBufferLength
                + us1FieldBufferLength;
            Debug.WriteLine($"bufferLength: {bufferLength}");

            byte[] buffer = new byte[bufferLength];
            int bufferBase = 0;

            // Header data fields
            buffer[bufferBase++] = e.__serializationsignature;
            buffer[bufferBase++] = e.__serializationversion;
            buffer[bufferBase++] = e.__converterversion;
            buffer[bufferBase++] = (byte)e.__entitystate;
            buffer[bufferBase++] = e.__nfields;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");

            byte[] fieldBuffer;

            (fieldBuffer = FieldSerialization03.Serialize(e.__entitytypehash)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.__created)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.__modified)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.__changeindex)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");

            (fieldBuffer = FieldSerialization03.Serialize(e.a1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.b1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.ba1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.ch1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize((Int16)e.e1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.f1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.i1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.l1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.s1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.sb1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.str1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.asciistr1, false)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.ui1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.ul1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            (fieldBuffer = FieldSerialization03.Serialize(e.us1)).CopyTo(buffer, bufferBase); bufferBase += fieldBuffer.Length;
            Debug.WriteLine($"bufferBase: {bufferBase}\t{Helpers.ToHex(buffer)}");
            Debug.WriteLine($"lBuffer, bufferBase: {bufferLength} {bufferBase}");

            return buffer;
        }

        private AllFieldsClass DeserializeAllFields(byte[] buffer, ref int bufferBase)
        {
            AllFieldsClass e = new AllFieldsClass();

            // Header data fields
            e.__serializationsignature = buffer[bufferBase++];
            e.__serializationversion = buffer[bufferBase++];
            e.__converterversion = buffer[bufferBase++];

            if (e.__serializationsignature != EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE ||
                e.__serializationversion != EntitySerialization03.ENTITYSERIALIZATION_VERSION ||
                e.__converterversion != FieldSerialization03.FIELDSERIALIZATION_VERSION)
            {
                e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION);
                return e;
            }

            e.__entitystate = (EntitySerialization03.EntityState)buffer[bufferBase++];
            e.__nfields = buffer[bufferBase++];

            // System data fields
            e.__entitytypehash = FieldSerialization03.DeserializeByteArray(buffer, ref bufferBase);
            e.__created = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);
            e.__modified = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);
            e.__changeindex = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);

            e.a1 = FieldSerialization03.DeserializeAddress(buffer, ref bufferBase);
            e.b1 = FieldSerialization03.DeserializeByte(buffer, ref bufferBase);
            e.ba1 = FieldSerialization03.DeserializeByteArray(buffer, ref bufferBase);
            e.ch1 = FieldSerialization03.DeserializeChar(buffer, ref bufferBase);
            e.e1 = (TestEnum)FieldSerialization03.DeserializeEnum(buffer, ref bufferBase);
            e.f1 = FieldSerialization03.DeserializeBoolean(buffer, ref bufferBase);
            e.i1 = FieldSerialization03.DeserializeInt32(buffer, ref bufferBase);
            e.l1 = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);
            e.s1 = FieldSerialization03.DeserializeInt16(buffer, ref bufferBase);
            e.sb1 = FieldSerialization03.DeserializeSByte(buffer, ref bufferBase);
            e.str1 = FieldSerialization03.DeserializeString(buffer, ref bufferBase);
            e.asciistr1 = FieldSerialization03.DeserializeASCIIString(buffer, ref bufferBase);
            e.ui1 = FieldSerialization03.DeserializeUInt32(buffer, ref bufferBase);
            e.ul1 = FieldSerialization03.DeserializeUInt64(buffer, ref bufferBase);
            e.us1 = FieldSerialization03.DeserializeUInt16(buffer, ref bufferBase);

            AllFieldsDump(e);

            return e;
        }

        public void AllFieldsDump(AllFieldsClass e)
        {
            Debug.WriteLine($"e.__serializationsignature: {e.__serializationsignature}");
            Debug.WriteLine($"e.__serializationversion: {e.__serializationversion}");
            Debug.WriteLine($"e.__converterversion: {e.__converterversion}");
            Debug.WriteLine($"e.__entitystate: {(EntitySerialization03.EntityState)e.__entitystate}");
            Debug.WriteLine($"e.__nfields: {e.__nfields}");

            Debug.WriteLine($"e.__entitytypehash: {Helpers.ToHex(e.__entitytypehash)}");
            Debug.WriteLine($"e.__created: {new DateTime(e.__created).ToString()}");
            Debug.WriteLine($"e.__modified: {new DateTime(e.__modified).ToString()}");

            Debug.WriteLine($"e.a1: {e.a1.Value}");
            Debug.WriteLine($"e.b1: {e.b1}");
            Debug.WriteLine($"e.ba1: {Helpers.ToHex(e.ba1)}");
            Debug.WriteLine($"e.ch1: {e.ch1}");
            Debug.WriteLine($"e.e1: {e.e1}");
            Debug.WriteLine($"e.f1: {e.f1}");
            Debug.WriteLine($"e.i1: {e.i1}");
            Debug.WriteLine($"e.l1: {e.l1}");
            Debug.WriteLine($"e.s1: {e.s1}");
            Debug.WriteLine($"e.sb1: {e.sb1}");
            Debug.WriteLine($"e.str1: {e.str1}");
            Debug.WriteLine($"e.asciistr1: {e.asciistr1}");
            Debug.WriteLine($"e.ui1: {e.ui1}");
            Debug.WriteLine($"e.ul1: {e.ul1}");
            Debug.WriteLine($"e.us1: {e.us1}");
        }

        [TestInitialize]
        public void Initialize03()
        {
            e1 = new AllFieldsClass
            {
                // Header data fields
                __serializationsignature = EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE,
                __serializationversion = EntitySerialization03.ENTITYSERIALIZATION_VERSION,
                __converterversion = FieldSerialization03.FIELDSERIALIZATION_VERSION,
                __entitystate = EntitySerialization03.EntityState.INITIALIZED,
                __nfields = EntitySerialization03.NSYSTEMFIELDS + AllFieldsClass.__NENTITYFIELDS,

                // System data fields
                __entitytypehash = AllFieldsClass.ENTITY_TYPE,
                __created = DateTime.UtcNow.Ticks,
                __modified = 0,
                __changeindex = 0,
        };

            e1.a1 = new Address("mrTNM1QJZ8HS6ZmCsjg8tPpkTZxmEh6vCN");
            e1.b1 = byte.MaxValue;
            e1.ba1 = new byte[] { 0x1, 0x2, 0x3, 0x1, 0x2, 0x3, 0x1, 0x2, 0x3 };
            e1.ch1 = 'c';
            e1.e1 = TestEnum.blue;
            e1.f1 = true;
            e1.i1 = int.MinValue;
            e1.l1 = long.MinValue;
            e1.s1 = short.MinValue;
            e1.sb1 = sbyte.MinValue;
            e1.str1 = "Hello world!";
            e1.asciistr1 = "Hello world!";
            e1.ui1 = uint.MaxValue;
            e1.ul1 = ulong.MaxValue;
            e1.us1 = ushort.MaxValue;
        }

        [TestMethod]
        public void SerializeAllFieldsTest03()
        {
            int lBuffer = 0;
            byte[] e = SerializeAllFields(e1, out lBuffer);
            Assert.AreEqual(lBuffer, e.Length);
        }

        [TestMethod]
        public void DeserializeAllFieldsTest03()
        {
            int lBuffer1 = 0;
            byte[] buffer1 = SerializeAllFields(e1, out lBuffer1);
            Assert.AreEqual(buffer1.Length, lBuffer1);

            int bufferBase = 0;
            AllFieldsClass e2 = DeserializeAllFields(buffer1, ref bufferBase);
            Assert.AreEqual(buffer1.Length, bufferBase);
            Assert.AreEqual(JsonConvert.SerializeObject(e1), JsonConvert.SerializeObject(e2));

            int lBuffer2 = 0;
            byte[] buffer2 = SerializeAllFields(e1, out lBuffer2);
            Assert.AreEqual(buffer1.Length, buffer2.Length);

            CollectionAssert.AreEqual(buffer1, buffer2);
        }

        [TestMethod]
        public void AssertExamples03()
        {
            Assert.AreEqual(1, 1);
            Assert.AreNotEqual(1, 0);
            Assert.IsFalse(false);
            Assert.IsTrue(true);
            Assert.IsNull(null);
            Assert.IsNotNull(new object());
        }

        [TestMethod]
        public void ToHex03()
        {
            string buffer;

            String[] testcasesString = { null, String.Empty, "", "1", "0123456789", "a", "aa", "aaa", "aaaa", "安" };

            String[] testcasesResultUnicode = { "", "0x", "0x", "0x0031", "0x0030003100320033003400350036003700380039", "0x0061", "0x00610061", "0x006100610061", "0x0061006100610061", "0x5B89" };
             for (int si = 0; si < testcasesString.Length; si++)
            {
                string testcase = testcasesString[si];
                string testcaseResult = testcasesResultUnicode[si];

                buffer = Helpers.ToHex(testcase,true);
                bool result = buffer.Equals(testcaseResult);
                if (testcase == null)
                {
                    Debug.WriteLine($"ToHex3.Unicode '(null)'\t'{buffer}'\t'{testcaseResult}'\t'{result}'\t{buffer.Length}\t{0 * 2}");
                    Assert.AreEqual(buffer, testcaseResult);
                    Assert.IsTrue(result);
                    Assert.AreEqual(buffer.Length, 0 * 4);
                }
                else
                {
                    Debug.WriteLine($"ToHex3.Unicode '{testcase}'\t'{buffer}'\t'{testcaseResult}'\t'{result}'\t{buffer.Length}\t{2 + testcase.Length * 4}");
                    Assert.AreEqual(buffer, testcaseResult);
                    Assert.IsTrue(result);
                    Assert.AreEqual(buffer.Length, 2 + testcase.Length * 4);
                }
            }

            String[] testcasesResultASCII = { "", "0x", "0x", "0x31", "0x30313233343536373839", "0x61", "0x6161", "0x616161", "0x61616161", "0x??" };
            for (int si = 0; si < testcasesString.Length; si++)
            {
                string testcase = testcasesString[si];
                string testcaseResult = testcasesResultASCII[si];

                buffer = Helpers.ToHex(testcase, false);
                bool result = buffer.Equals(testcaseResult);
                if (testcase == null)
                {
                    Debug.WriteLine($"ToHex3.ASCII '(null)'\t'{buffer}'\t'{testcaseResult}'\t'{result}'\t{buffer.Length}\t{0 * 1}");
                    Assert.AreEqual(buffer, testcaseResult);
                    Assert.IsTrue(result);
                    Assert.AreEqual(buffer.Length, 0 * 4);
                }
                else
                {
                    Debug.WriteLine($"ToHex3.ASCII '{testcase}'\t'{buffer}'\t'{testcaseResult}'\t'{result}'\t{buffer.Length}\t{2 + testcase.Length * 2}");
                    Assert.AreEqual(buffer, testcaseResult);
                    Assert.IsTrue(result);
                    Assert.AreEqual(buffer.Length, 2 + testcase.Length * 2);
                }
            }
        }

        [TestMethod]
        public void SignedBytes03()
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
                sbyte result = FieldSerialization03.DeserializeSByte(buffer, ref bufferOffset);
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
                sbyte result = FieldSerialization03.DeserializeSByte(buffer, ref bufferOffset);
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
        public void UnsignedBytes03()
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
                byte result = FieldSerialization03.DeserializeByte(buffer, ref bufferOffset);
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
                byte result = FieldSerialization03.DeserializeByte(buffer, ref bufferOffset);
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
        public void Chars03()
        {
            byte[] buffer;

            char[] testcasesChar = { '\0', 'a', 'A', '安',
                                     'X', '\x0058', (char)88, '\u0058' };
            foreach (char testcase in testcasesChar)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                char result = FieldSerialization03.DeserializeChar(buffer, ref bufferOffset);
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
                char result = FieldSerialization03.DeserializeChar(buffer, ref bufferOffset);
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + sizeof(char)}");
                Assert.AreEqual(default(char), result);
                Assert.AreEqual(1 + 2 + sizeof(char), bufferOffset);
                Assert.AreEqual(1 + 2 + sizeof(char), buffer.Length);
            }
        }

        [TestMethod]
        public void SignedInts03()
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
                Int16 result = FieldSerialization03.DeserializeInt16(buffer, ref bufferOffset);
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
                Int16 result = FieldSerialization03.DeserializeInt16(buffer, ref bufferOffset);
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
                Int32 result = FieldSerialization03.DeserializeInt32(buffer, ref bufferOffset);
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
                Int32 result = FieldSerialization03.DeserializeInt32(buffer, ref bufferOffset);
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
                Int64 result = FieldSerialization03.DeserializeInt64(buffer, ref bufferOffset);
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
                Int64 result = FieldSerialization03.DeserializeInt64(buffer, ref bufferOffset);
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
        public void UnsignedInts03()
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
                UInt16 result = FieldSerialization03.DeserializeUInt16(buffer, ref bufferOffset);
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
                UInt16 result = FieldSerialization03.DeserializeUInt16(buffer, ref bufferOffset);
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
                UInt32 result = FieldSerialization03.DeserializeUInt32(buffer, ref bufferOffset);
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
                UInt32 result = FieldSerialization03.DeserializeUInt32(buffer, ref bufferOffset);
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
                UInt64 result = FieldSerialization03.DeserializeUInt64(buffer, ref bufferOffset);
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
                UInt64 result = FieldSerialization03.DeserializeUInt64(buffer, ref bufferOffset);
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
        public void Addresses03()
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
                Address result = FieldSerialization03.DeserializeAddress(buffer, ref bufferOffset);
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
                Address result = FieldSerialization03.DeserializeAddress(buffer, ref bufferOffset);
                if (testcase.Value == null)
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value-U (null)\t{Helpers.ToHex(buffer)}\t'{result.Value}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 0 * 2}");
                    Assert.IsNull(result.Value);
                    Assert.AreEqual(1 + 2 + 0, bufferOffset);
                    Assert.AreEqual(1 + 2 + 0, buffer.Length);
                }
                else
                {
                    Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}.Value '{testcase.Value}'\t{Helpers.ToHex(buffer)}\t'{result.Value}'\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + testcase.Value.Length}");
                    Assert.IsNull(result.Value);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, bufferOffset);
                    Assert.AreEqual(1 + 2 + testcase.Value.Length, buffer.Length);
                }
            }
        }

        [TestMethod]
        public void Strings03()
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
                String result = FieldSerialization03.DeserializeString(buffer, ref bufferOffset);
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
                String result = FieldSerialization03.DeserializeString(buffer, ref bufferOffset);
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
        public void StringLengths03()
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
                String result = FieldSerialization03.DeserializeString(buffer, ref bufferOffset);
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
        public void ASCIIStrings03()
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
                String result = FieldSerialization03.DeserializeASCIIString(buffer, ref bufferOffset);
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
                String result = FieldSerialization03.DeserializeASCIIString(buffer, ref bufferOffset);
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
        public void ByteArrays03()
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
                byte[] result = FieldSerialization03.DeserializeByteArray(buffer, ref bufferOffset);
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
                byte[] result = FieldSerialization03.DeserializeByteArray(buffer, ref bufferOffset);
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
        public void ByteArrayLengths03()
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
                byte[] result = FieldSerialization03.DeserializeByteArray(buffer, ref bufferOffset);
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
        public void Enums03()
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
                TestEnum result = (TestEnum)FieldSerialization03.DeserializeEnum(buffer, ref bufferOffset);
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
                TestEnum result = (TestEnum)FieldSerialization03.DeserializeEnum(buffer, ref bufferOffset);
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
        public void Guid03()
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
                Guid result = FieldSerialization03.DeserializeGuid(buffer, ref bufferOffset);
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
                Guid result = FieldSerialization03.DeserializeGuid(buffer, ref bufferOffset);
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1 + 2 + 16}");
                Assert.AreEqual(testcase, result);
                Assert.AreEqual(1 + 2 + 16, bufferOffset);
                Assert.AreEqual(1 + 2 + 16, buffer.Length);
            }
        }

        [TestMethod]
        public void Booleans03()
        {
            byte[] buffer;

            Boolean[] testcasesBoolean = { 0 == 0, 0 == 1, true, false };
            foreach (Boolean testcase in testcasesBoolean)
            {
                buffer = FieldSerialization03.Serialize(testcase);
                int bufferOffset = 0;
                Boolean result = FieldSerialization03.DeserializeBoolean(buffer, ref bufferOffset);
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
                Boolean result = FieldSerialization03.DeserializeBoolean(buffer, ref bufferOffset);
                Debug.WriteLine($"{FieldSerialization03.GetFieldEncodingType(buffer, 0)}-U {testcase}\t{Helpers.ToHex(buffer)}\t{result}\t{bufferOffset}\t{buffer.Length}\t{1}");
                Assert.IsFalse(result);
                Assert.AreEqual(1, bufferOffset);
                Assert.AreEqual(1, buffer.Length);
            }
        }
    }
}
