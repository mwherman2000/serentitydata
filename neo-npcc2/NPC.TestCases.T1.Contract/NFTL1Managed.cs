using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.TestCases.T1.Contract.NFT - Level 1 Managed
///
/// Processed:       2018-04-06 1:24:04 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.24661
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.TestCases.T1.Contract
{
    public partial class NFT : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NFT()
        {
        }

        // Accessors

        // readonly public static void SetUri(NFT e, string value) // Template: NPCLevel1SetXGetX_cs.txt
        // readonly                        { e._uri = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetUri(NFT e) { return e._uri; }
        public static void SetFirstName(NFT e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._firstName = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetFirstName(NFT e) { return e._firstName; }
        public static void SetLastName(NFT e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._lastName = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetLastName(NFT e) { return e._lastName; }
        public static void Set(NFT e, string Uri, string FirstName, string LastName) // Template: NPCLevel1Set_cs.txt
                                { if (e._state != NeoEntityModel.EntityState.NULL) {e._uri = Uri; e._firstName = FirstName; e._lastName = LastName;  e._state = NeoEntityModel.EntityState.SET;} }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NFT _Initialize(NFT e)
        {
            e._uri = ""; e._firstName = ""; e._lastName = ""; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NFT", e);
            return e;
        }
        public static NFT New()
        {
            NFT e = new NFT();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NFT", e);
            return e;
        }
        public static NFT New(string Uri, string FirstName, string LastName)
        {
            NFT e = new NFT();
            e._uri = Uri; e._firstName = FirstName; e._lastName = LastName; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NFT", e);
            return e;
        }
        public static NFT Null()
        {
            NFT e = new NFT();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NFT", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NFT e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NFT e)
        {
            TraceRuntime(label, e._uri, e._firstName, e._lastName);
        }
        public static void LogExt(string label, NFT e)
        {
            TraceRuntime(label, e._uri, e._firstName, e._lastName, e._state);
        }
    }
}