using System;

/// <summary>
/// SerentityData.mwherman2000.ImageManager.Prototype - Level 2 Persistable 
///
/// Processed:       2018-03-19 11:02:51 PM by SerentityData Compiler (SDC) 3.0 v1.0.0.0
/// SDC Project:     https://github.com/mwherman2000/serentitydata/blob/master/README.md
/// SDC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace Parallelspace.SerentityData.Ledgers
{
    public interface IGenericLedgerEntry03L2Persistable<T>
    {
        byte[] Serialize();
        // T Deserialize();

        //void Put(IPersistentState ctx, string key);
        //// T Get(IPersistentState ctx, string key);
    }
}