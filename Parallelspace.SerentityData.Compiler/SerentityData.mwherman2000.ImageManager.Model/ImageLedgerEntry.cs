using System;

namespace SerentityData.mwherman2000.ImageManager.Model
{
    public partial class ImageLedgerEntry : NPCLevel0Basic,
                                            NPCLevel1Managed,
                                            NPCLevel2Persistable
    {
        public Int32 ImageVersion;
        public string ImageName;
        public byte[] ImageContent;
    }
}
