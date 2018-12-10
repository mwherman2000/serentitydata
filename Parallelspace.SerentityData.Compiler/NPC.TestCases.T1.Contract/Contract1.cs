using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using NPC.TestCases.T1.Contract;
using System;
using System.Numerics;

namespace NPCPointdApp
{
    public class Contract1 : SmartContract
    {
        public static void Main()
        {
            Storage.Put(Storage.CurrentContext, "Hello", "World");

            NFT e = NFT.New();
        }
    }
}
