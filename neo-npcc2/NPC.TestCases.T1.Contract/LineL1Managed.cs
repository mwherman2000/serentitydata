using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.TestCases.T1.Contract.Line - Level 1 Managed
///
/// Processed:       2018-04-06 1:24:04 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.24661
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.TestCases.T1.Contract
{
    public partial class Line : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private Line()
        {
        }

        // Accessors

        public static void SetBKeyP1(Line e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._bKeyP1 = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetBKeyP1(Line e) { return e._bKeyP1; }
        public static void SetBKeyP2(Line e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._bKeyP2 = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetBKeyP2(Line e) { return e._bKeyP2; }
        public static void Set(Line e, byte[] BKeyP1, byte[] BKeyP2) // Template: NPCLevel1Set_cs.txt
                                { {e._bKeyP1 = BKeyP1; e._bKeyP2 = BKeyP2;  e._state = NeoEntityModel.EntityState.SET;} }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static Line _Initialize(Line e)
        {
            e._bKeyP1 = NeoEntityModel.NullByteArray; e._bKeyP2 = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).Line", e);
            return e;
        }
        public static Line New()
        {
            Line e = new Line();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().Line", e);
            return e;
        }
        public static Line New(byte[] BKeyP1, byte[] BKeyP2)
        {
            Line e = new Line();
            e._bKeyP1 = BKeyP1; e._bKeyP2 = BKeyP2; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).Line", e);
            return e;
        }
        public static Line Null()
        {
            Line e = new Line();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().Line", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(Line e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, Line e)
        {
            TraceRuntime(label, e._bKeyP1, e._bKeyP2);
        }
        public static void LogExt(string label, Line e)
        {
            TraceRuntime(label, e._bKeyP1, e._bKeyP2, e._state);
        }
    }
}