using System;

/// <summary>
/// SParallelspace.SerentityData.Ledgers - Level 1 Managed
///
/// Processed:       2018-03-19 11:02:51 PM by SerentityData Compiler (SDC) 3.0 v1.0.0.0
/// SDC Project:     https://github.com/mwherman2000/serentitydata/blob/master/README.md
/// SDC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace Parallelspace.SerentityData.Ledgers
{
    public interface IGenericLedgerEntry03L1Managed<T>
    {
        byte[] GetEntityTypeHash();
        Int64 GetCreated();
        Int64 GetChangeIndex();
        Int64 GetModified();

        bool IsInitialized();
        bool IsMissing();
        bool IsNull();
        bool IsSet();
        bool IsSerialized();
        bool IsDeserialized();
        bool IsBuried();

        bool InErrorState();
        bool InExceptionState();
        bool InExceptionOnlyState();
        bool InSerializationExceptionState();
        bool InDeserializationExceptionState();
    }
}