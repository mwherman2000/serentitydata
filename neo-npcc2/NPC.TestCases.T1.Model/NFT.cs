using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC.TestCases.T1.Model
{
    public class NFT : NPCLevel0Basic,
                        NPCLevel1Managed,
                        NPCLevel2Persistable,
                        NPCLevel3Deletable,
                        NPCLevel4Collectible,
                        NPCLevel4CollectibleExt
    {
        readonly string Uri;
        string FirstName;
        string LastName;
    }
}
