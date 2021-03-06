﻿namespace NPC.mwherman2000.NeoDraw.Model
{
    public interface NPCLevel0Basic { }
    public interface NPCLevel1Managed { }
    public interface NPCLevel2Persistable { }
    public interface NPCLevel3Deletable { }
    public interface NPCLevel4Collectible { }
    public interface NPCLevel4CollectibleExt { }

    public interface NPCLevel0CustomMethods { }
    public interface NPCLevel1CustomMethods { }
    public interface NPCLevel2CustomMethods { }
    public interface NPCLevel3CustomMethods { }
    public interface NPCLevel4CustomMethods { }

    public partial class UserCredentials :   NPCLevel0Basic,
                                             NPCLevel1Managed,
                                             NPCLevel2Persistable,
                                             NPCLevel3Deletable,
                                             NPCLevel4Collectible,
                                             NPCLevel4CollectibleExt
    {
        public byte[] encodedUsername;
        public byte[] encodedPassword;
    }
}
