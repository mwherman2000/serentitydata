using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Parallelspace.SerentityData
{
    public interface IPersistentState
    {
        byte[] GetByteArray(string key);
        void SetByteArray(string key, byte[] value);
    }

    public class Address
    {
        public Address()
        {
            Value = null;
        }

        public Address(string value)
        {
            this.Value = value;
        }

        public string Value;
    }
}
