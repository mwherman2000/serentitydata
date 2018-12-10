using System.Numerics;

namespace NPC.mwherman2000.NeoDraw.Model
{
    public partial class UserPoint : NPCLevel0Basic, 
                                     NPCLevel1Managed, 
                                     NPCLevel2Persistable, 
                                     NPCLevel3Deletable,  
                                     NPCLevel4Collectible,
                                     NPCLevel4CollectibleExt
    {
        public BigInteger x;
        public BigInteger y;
        //public byte[] encodedUsername;
    }
}
