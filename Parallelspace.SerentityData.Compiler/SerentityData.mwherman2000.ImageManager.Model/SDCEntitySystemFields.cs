using Parallelspace.SerentityData;
using System;

namespace SerentityData.mwherman2000.ImageManager.Model
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

    public interface SDCEntitySystemFields { }

    public interface SDCEntityVersion01 { }
    public interface SDCEntityVersion02 { }
    public interface SDCEntityVersion03 { }
    public interface SDCEntityVersion04 { }

    public partial class ImageLedgerEntry : SDCEntitySystemFields, SDCEntityVersion03
    {
        private byte ___entityserializationsignature;
        private byte ___entityserializationversion;
        private byte ___fieldserializationversion;
        private EntitySerialization03.EntityState ___entitystate;
        private byte ___nfields;
    }
}
