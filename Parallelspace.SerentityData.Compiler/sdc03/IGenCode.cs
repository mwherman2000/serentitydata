using System.Collections.Generic;

namespace sdc03
{
    public interface IGenCode
    {
        bool GenerateCodeCustomMethods(NPCCompilerContext ctx, int classIndex, List<NPCClassInterfaceInfo> listClassInterfaces);
        bool GenerateCodeLevel0Basic(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel1Managed(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel2Persistable(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel3Deletable(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel4Collectible(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel4CollectibleExt0(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel4CollectibleExt1(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel4CollectibleExt2(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel4CollectibleExt3(NPCCompilerContext ctx, int classIndex);
        bool GenerateCodeLevel4CollectibleExt4(NPCCompilerContext ctx, int classIndex);
    }
}