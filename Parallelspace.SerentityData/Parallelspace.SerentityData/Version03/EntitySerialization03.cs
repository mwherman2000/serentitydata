﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Parallelspace.SerentityData.FieldSerialization02;

namespace Parallelspace.SerentityData
{
    public struct EntitySerialization03
    {
        public const byte ENTITYSERIALIZATION_SIGNATURE = 0xBB; // Version 0x03 = 0xBB
        public const byte ENTITYSERIALIZATION_VERSION = 0x03;   // Version 0x03
        public static readonly byte[] SHA256_DUMMY_HASH = // SHA256 of "" (null string) = new byte[0]
            { 0xE3, 0xB0, 0xC4, 0x42, 0x98, 0xFC, 0x1C, 0x14,
              0x9A, 0xFB, 0xF4, 0xC8, 0x99, 0x6F, 0xB9, 0x24,
              0x27, 0xAE, 0x41, 0xE4, 0x64, 0x9B, 0x93, 0x4C,
              0xA4, 0x95, 0x99, 0x1B, 0x78, 0x52, 0xB8, 0x55 };
        //public const string TX_DUMMY_HASH_HEX = "0x22d44c3b82da8edf74fa7f2ae0f82836b432f67ede3b54646e12e9275b6699bb"; // ONT SC
        public const string TX_ZEROS_HASH_HEX = "0x0000000000000000000000000000000000000000000000000000000000000000"; 

        public static bool CheckEntitySerialization(byte[] buffer) {
            return CheckEntitySerializationSignature(buffer) && CheckEntitySerializationVersion(buffer) && CheckFieldSerializationVersion(buffer); 
        }
        public static bool CheckEntitySerializationSignature(byte[] buffer) { return buffer[0] == EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE; }
        public static bool CheckEntitySerializationVersion(byte[] buffer)   { return buffer[1] == EntitySerialization03.ENTITYSERIALIZATION_VERSION; }
        public static bool CheckFieldSerializationVersion(byte[] buffer)    { return buffer[2] == FieldSerialization03.FIELDSERIALIZATION_VERSION; }

        public enum EntityState
        {
            UNINITIALIZED, NULL, INITIALIZED, SET, MISSING, TOMBSTONED, NOTAUHTORIZED, DESERIALIZED, SERIALIZED,
            DONTCHANGESTATE, ERROR, EXCEPTION, EXCEPTION_SERIALIZATION,
            EXCEPTION_DESERIALIZATION,
            EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE, EXCEPTION_DESERIALIZATION_ENTITYVERSION,
            EXCEPTION_DESERIALIZATION_FIELDVERSION
        }

        public const int NHEADERFIELDS = 5; // __serializationsignature, __serializationversion, __converterversion, __entitystate, __nfields
        public const int NSYSTEMFIELDS = 4; // __entitytypehash, __created, __modified, __changeindex
        public const int MAXENTITYFIELDS = Byte.MaxValue - EntitySerialization03.NSYSTEMFIELDS; // 251 fields: ENTITYFIELD0 ... ENTITYFIELD250

        public enum FieldIndices
        {
            // Entity Header fields   
            HEADERFIELDS,           // virtual index representing all Header data fields

            // Entity System fields
            ENTITYTYPEHASH,
            CREATED,
            MODIFIED,
            CHANGEINDEX,

            // Entity Data fields
            ENTITYFIELD0,
            ENTITYFIELD1,
            ENTITYFIELD2,
            ENTITYFIELD3,
            ENTITYFIELD4,
            ENTITYFIELD5,
            ENTITYFIELD6,
            ENTITYFIELD7,
            ENTITYFIELD8,
            ENTITYFIELD9,
            ENTITYFIELD10,
            ENTITYFIELD11,
            ENTITYFIELD12,
            ENTITYFIELD13,
            ENTITYFIELD14,
            ENTITYFIELD15,
            ENTITYFIELD16,
            ENTITYFIELD17,
            ENTITYFIELD18,
            ENTITYFIELD19,
            ENTITYFIELD20,
            ENTITYFIELD21,
            ENTITYFIELD22,
            ENTITYFIELD23,
            ENTITYFIELD24,
            ENTITYFIELD25,
            ENTITYFIELD26,
            ENTITYFIELD27,
            ENTITYFIELD28,
            ENTITYFIELD29,
            ENTITYFIELD30,
            ENTITYFIELD31,
            ENTITYFIELD32,
            ENTITYFIELD33,
            ENTITYFIELD34,
            ENTITYFIELD35,
            ENTITYFIELD36,
            ENTITYFIELD37,
            ENTITYFIELD38,
            ENTITYFIELD39,
            ENTITYFIELD40,
            ENTITYFIELD41,
            ENTITYFIELD42,
            ENTITYFIELD43,
            ENTITYFIELD44,
            ENTITYFIELD45,
            ENTITYFIELD46,
            ENTITYFIELD47,
            ENTITYFIELD48,
            ENTITYFIELD49,
            ENTITYFIELD50,
            ENTITYFIELD51,
            ENTITYFIELD52,
            ENTITYFIELD53,
            ENTITYFIELD54,
            ENTITYFIELD55,
            ENTITYFIELD56,
            ENTITYFIELD57,
            ENTITYFIELD58,
            ENTITYFIELD59,
            ENTITYFIELD60,
            ENTITYFIELD61,
            ENTITYFIELD62,
            ENTITYFIELD63,
            ENTITYFIELD64,
            ENTITYFIELD65,
            ENTITYFIELD66,
            ENTITYFIELD67,
            ENTITYFIELD68,
            ENTITYFIELD69,
            ENTITYFIELD70,
            ENTITYFIELD71,
            ENTITYFIELD72,
            ENTITYFIELD73,
            ENTITYFIELD74,
            ENTITYFIELD75,
            ENTITYFIELD76,
            ENTITYFIELD77,
            ENTITYFIELD78,
            ENTITYFIELD79,
            ENTITYFIELD80,
            ENTITYFIELD81,
            ENTITYFIELD82,
            ENTITYFIELD83,
            ENTITYFIELD84,
            ENTITYFIELD85,
            ENTITYFIELD86,
            ENTITYFIELD87,
            ENTITYFIELD88,
            ENTITYFIELD89,
            ENTITYFIELD90,
            ENTITYFIELD91,
            ENTITYFIELD92,
            ENTITYFIELD93,
            ENTITYFIELD94,
            ENTITYFIELD95,
            ENTITYFIELD96,
            ENTITYFIELD97,
            ENTITYFIELD98,
            ENTITYFIELD99,
            ENTITYFIELD100,
            ENTITYFIELD101,
            ENTITYFIELD102,
            ENTITYFIELD103,
            ENTITYFIELD104,
            ENTITYFIELD105,
            ENTITYFIELD106,
            ENTITYFIELD107,
            ENTITYFIELD108,
            ENTITYFIELD109,
            ENTITYFIELD110,
            ENTITYFIELD111,
            ENTITYFIELD112,
            ENTITYFIELD113,
            ENTITYFIELD114,
            ENTITYFIELD115,
            ENTITYFIELD116,
            ENTITYFIELD117,
            ENTITYFIELD118,
            ENTITYFIELD119,
            ENTITYFIELD120,
            ENTITYFIELD121,
            ENTITYFIELD122,
            ENTITYFIELD123,
            ENTITYFIELD124,
            ENTITYFIELD125,
            ENTITYFIELD126,
            ENTITYFIELD127,
            ENTITYFIELD128,
            ENTITYFIELD129,
            ENTITYFIELD130,
            ENTITYFIELD131,
            ENTITYFIELD132,
            ENTITYFIELD133,
            ENTITYFIELD134,
            ENTITYFIELD135,
            ENTITYFIELD136,
            ENTITYFIELD137,
            ENTITYFIELD138,
            ENTITYFIELD139,
            ENTITYFIELD140,
            ENTITYFIELD141,
            ENTITYFIELD142,
            ENTITYFIELD143,
            ENTITYFIELD144,
            ENTITYFIELD145,
            ENTITYFIELD146,
            ENTITYFIELD147,
            ENTITYFIELD148,
            ENTITYFIELD149,
            ENTITYFIELD150,
            ENTITYFIELD151,
            ENTITYFIELD152,
            ENTITYFIELD153,
            ENTITYFIELD154,
            ENTITYFIELD155,
            ENTITYFIELD156,
            ENTITYFIELD157,
            ENTITYFIELD158,
            ENTITYFIELD159,
            ENTITYFIELD160,
            ENTITYFIELD161,
            ENTITYFIELD162,
            ENTITYFIELD163,
            ENTITYFIELD164,
            ENTITYFIELD165,
            ENTITYFIELD166,
            ENTITYFIELD167,
            ENTITYFIELD168,
            ENTITYFIELD169,
            ENTITYFIELD170,
            ENTITYFIELD171,
            ENTITYFIELD172,
            ENTITYFIELD173,
            ENTITYFIELD174,
            ENTITYFIELD175,
            ENTITYFIELD176,
            ENTITYFIELD177,
            ENTITYFIELD178,
            ENTITYFIELD179,
            ENTITYFIELD180,
            ENTITYFIELD181,
            ENTITYFIELD182,
            ENTITYFIELD183,
            ENTITYFIELD184,
            ENTITYFIELD185,
            ENTITYFIELD186,
            ENTITYFIELD187,
            ENTITYFIELD188,
            ENTITYFIELD189,
            ENTITYFIELD190,
            ENTITYFIELD191,
            ENTITYFIELD192,
            ENTITYFIELD193,
            ENTITYFIELD194,
            ENTITYFIELD195,
            ENTITYFIELD196,
            ENTITYFIELD197,
            ENTITYFIELD198,
            ENTITYFIELD199,
            ENTITYFIELD200,
            ENTITYFIELD201,
            ENTITYFIELD202,
            ENTITYFIELD203,
            ENTITYFIELD204,
            ENTITYFIELD205,
            ENTITYFIELD206,
            ENTITYFIELD207,
            ENTITYFIELD208,
            ENTITYFIELD209,
            ENTITYFIELD210,
            ENTITYFIELD211,
            ENTITYFIELD212,
            ENTITYFIELD213,
            ENTITYFIELD214,
            ENTITYFIELD215,
            ENTITYFIELD216,
            ENTITYFIELD217,
            ENTITYFIELD218,
            ENTITYFIELD219,
            ENTITYFIELD220,
            ENTITYFIELD221,
            ENTITYFIELD222,
            ENTITYFIELD223,
            ENTITYFIELD224,
            ENTITYFIELD225,
            ENTITYFIELD226,
            ENTITYFIELD227,
            ENTITYFIELD228,
            ENTITYFIELD229,
            ENTITYFIELD230,
            ENTITYFIELD231,
            ENTITYFIELD232,
            ENTITYFIELD233,
            ENTITYFIELD234,
            ENTITYFIELD235,
            ENTITYFIELD236,
            ENTITYFIELD237,
            ENTITYFIELD238,
            ENTITYFIELD239,
            ENTITYFIELD240,
            ENTITYFIELD241,
            ENTITYFIELD242,
            ENTITYFIELD243,
            ENTITYFIELD244,
            ENTITYFIELD245,
            ENTITYFIELD246,
            ENTITYFIELD247,
            ENTITYFIELD248,
            ENTITYFIELD249,
            ENTITYFIELD250,
        }

        public static byte[] SerializeFieldBuffers(byte[][] fieldBuffers,
                                            byte entitySerializationSignature, byte entitySerializationVersion, byte fieldSerializationVersion,
                                            byte entityState, byte nfields)
        {
            int lBuffer = NHEADERFIELDS * sizeof(byte);
            for (int fi = 0; fi < nfields; fi++) lBuffer += fieldBuffers[fi].Length; // Entity System fields plus Entity data fields

            byte[] buffer = new byte[lBuffer];
            int bufferBase = 0;

            // Entity Header fields
            buffer[bufferBase++] = entitySerializationSignature;
            buffer[bufferBase++] = entitySerializationVersion;
            buffer[bufferBase++] = fieldSerializationVersion;
            buffer[bufferBase++] = entityState;
            buffer[bufferBase++] = nfields;

            // Entity System fields plus Entity data fields
            for (int fi = 0; fi < nfields; fi++)
            {
                fieldBuffers[fi].CopyTo(buffer, bufferBase);
                bufferBase += fieldBuffers[fi].Length;
            }

            return buffer;
        }
    }
}
