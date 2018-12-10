using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.TestCases.T1.Contract.Line - Level 2 Persistable
///
/// Processed:       2018-04-06 1:24:04 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.24661
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.TestCases.T1.Contract
{
    public partial class Line : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "Line";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sBKeyP1 = "BKeyP1"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bBKeyP1 = Helper.AsByteArray(_sBKeyP1);
        private const string _sBKeyP2 = "BKeyP2"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bBKeyP2 = Helper.AsByteArray(_sBKeyP2);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(Line e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static Line Missing()
        {
            Line e = new Line();
            e._bKeyP1 = NeoEntityModel.NullByteArray; e._bKeyP2 = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().Line", e);
            return e;
        }

        public static bool Put(Line e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            // no readonly fields byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            // no readonly fields if (NeoTrace.RUNTIME) TraceRuntime("Put(bkey).bsta", bsta.Length, bsta);
            // no readonly fields bool isMissing = false; if (bsta.Length == 0) isMissing = true;

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bBKeyP1), e._bKeyP1); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bBKeyP2), e._bKeyP2); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).Line", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(Line e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).Line", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            // no readonly fields byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            // no readonly fields if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bsta", bsta.Length, bsta);
            // no readonly fields bool isMissing = false; if (bsta.Length == 0) isMissing = true;

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sBKeyP1, e._bKeyP1); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sBKeyP2, e._bKeyP2); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).Line", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static Line Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            Line e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = Line.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new Line();

                byte[] BKeyP1 = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bBKeyP1)); //NPCLevel2GGet_cs.txt
                byte[] BKeyP2 = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bBKeyP2)); //NPCLevel2GGet_cs.txt
                e._bKeyP1 = BKeyP1; e._bKeyP2 = BKeyP2;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).Line", e);
            return e;
        }

        public static Line Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            Line e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).Line.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = Line.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new Line();

                byte[] BKeyP1 = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sBKeyP1); //NPCLevel2IGet_cs.txt
                byte[] BKeyP2 = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sBKeyP2); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._bKeyP1, e._bKeyP2", e._bKeyP1, e._bKeyP2); // Template: NPCLevel2Part2_cs.txt
                e._bKeyP1 = BKeyP1; e._bKeyP2 = BKeyP2; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).Line", e);
            return e;
        }
    }
}