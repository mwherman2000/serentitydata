using System;
using System.Numerics;
using NPC.mwherman2000.NeoDraw.Model;

/// <summary>
/// #NAMESPACE#.#CLASSNAME# Custom Methods
///
/// Processed:       #NOWDATETIME# by #PROGRAMNAME# v#PROGRAMVERSION#
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoDraw.Model
{
    public partial class NeoCounter:    NPCLevel4CustomMethods
    {
        public enum NeoCounters
        {
            UserCounter,
            PointCounter
        }

        public static void TakeNextNumber(NeoCounter e, NeoCounters counter)
        {
            throw new NotImplementedException();
        }

        public static BigInteger GetLastNumber(NeoCounter e, NeoCounters counter)
        {
            throw new NotImplementedException();
        }
    }
}
