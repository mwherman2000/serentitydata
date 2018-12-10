using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.TestCases.T1.Contract.NFT - Level 2 Persistable
///
/// Processed:       2018-04-06 1:24:04 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.24661
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.TestCases.T1.Contract
{
    public partial class NFT : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "NFT";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sUri = "Uri"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bUri = Helper.AsByteArray(_sUri);
        private const string _sFirstName = "FirstName"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bFirstName = Helper.AsByteArray(_sFirstName);
        private const string _sLastName = "LastName"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bLastName = Helper.AsByteArray(_sLastName);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(NFT e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static NFT Missing()
        {
            NFT e = new NFT();
            e._uri = ""; e._firstName = ""; e._lastName = ""; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().NFT", e);
            return e;
        }

        public static bool Put(NFT e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Put(bkey).bsta", bsta.Length, bsta);
            bool isMissing = false; if (bsta.Length == 0) isMissing = true;

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            if (isMissing) Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bUri), e._uri); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bFirstName), e._firstName); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bLastName), e._lastName); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).NFT", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(NFT e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NFT", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bsta", bsta.Length, bsta);
            bool isMissing = false; if (bsta.Length == 0) isMissing = true;

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            if (isMissing) Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sUri, e._uri); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sFirstName, e._firstName); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sLastName, e._lastName); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NFT", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static NFT Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            NFT e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NFT.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NFT();

                string Uri = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bUri)).AsString(); //NPCLevel2GGet_cs.txt
                string FirstName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bFirstName)).AsString(); //NPCLevel2GGet_cs.txt
                string LastName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bLastName)).AsString(); //NPCLevel2GGet_cs.txt
                e._uri = Uri; e._firstName = FirstName; e._lastName = LastName;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).NFT", e);
            return e;
        }

        public static NFT Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            NFT e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).NFT.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NFT.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NFT();

                string Uri = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sUri).AsString(); //NPCLevel2IGet_cs.txt
                string FirstName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sFirstName).AsString(); //NPCLevel2IGet_cs.txt
                string LastName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sLastName).AsString(); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._uri, e._firstName, e._lastName", e._uri, e._firstName, e._lastName); // Template: NPCLevel2Part2_cs.txt
                e._uri = Uri; e._firstName = FirstName; e._lastName = LastName; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).NFT", e);
            return e;
        }
    }
}