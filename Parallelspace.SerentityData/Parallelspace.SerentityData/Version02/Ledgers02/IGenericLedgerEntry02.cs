using System;

namespace Parallelspace.SerentityData.Ledgers
{
    public interface IGenericLedgerEntry02<T>
    {
        byte[] GetEntityTypeHash();
        Int64 GetCreated();
        Int64 GetChangeIndex();
        Int64 GetModified();

        bool IsInitialized();
        bool IsMissing();
        bool IsNull();
        bool IsSet();

        bool InErrorState();
        bool InExceptionState();
        bool InSerializationExceptionState();
        bool InDeserializationExceptionState();

        byte[] Serialize();
        // T Deserialize();

        void Put(IPersistentState ctx, string key);
        // T Get(IPersistentState ctx, string key);
    }
}