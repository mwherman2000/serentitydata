using Parallelspace.SerentityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parallelspace.SerentityData.Ledgers
{
    public struct UserLedgerEntry01 : IGenericLedgerEntry01<UserLedgerEntry01>
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Ledgers" + "." + "UserLedgerEntry" + " " + "v0.1";
        //public static readonly byte[] ENTITY_TYPE = SHA256Managed.Create().ComputeHash(Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME));
        public static readonly byte[] ENTITY_TYPE = Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME);

        // Entity Header fields
        private byte ___entityserializationsignature;
        private byte ___entityserializationversion;
        private byte ___fieldserializationversion;
        private EntitySerialization01.EntityState ___entitystate;
        private byte ___nfields;

        public bool CheckEntitySerializationSignature() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationsignature == EntitySerialization01.ENTITYSERIALIZATION_SIGNATURE; }
        public bool CheckEntitySerializationVersion() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationversion == EntitySerialization01.ENTITYSERIALIZATION_VERSION; }
        public bool CheckFieldSerializationVersion() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return ___fieldserializationversion == FieldSerialization01.FIELDSERIALIZATION_VERSION; }

        // Entity System fields
        private byte[] __entitytypehash;
        private Int64 __created;
        private Int64 __modified;
        private Int64 __changeindex;

        public byte[] GetEntityTypeHash() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return __entitytypehash; }
        public Int64 GetCreated() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return __created; }
        public Int64 GetModified() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return __modified; }
        public Int64 GetChangeIndex() { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return __changeindex; }

        // Entity Data fields
        private const int __NENTITYFIELDS = 3;
        private Int32 _id;
        private string _username;
        private string _passphrase;

        public int Id
        {
            get { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return _id; }
            set { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); _id = value; OnChangeFieldValue(EntitySerialization01.FieldIndices.ENTITYFIELD0); }
        }
        public string Username
        {
            get { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return _username; }
            set { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); _username = value; OnChangeFieldValue(EntitySerialization01.FieldIndices.ENTITYFIELD1); }
        }
        public string Passphrase
        {
            get { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); return _passphrase; }
            set { if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize(); _passphrase = value; OnChangeFieldValue(EntitySerialization01.FieldIndices.ENTITYFIELD2); }
        }

        public UserLedgerEntry01(int id, string username, string passphrase)
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization01.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization01.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization01.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization01.EntityState.INITIALIZED;
            ___nfields = EntitySerialization01.NSYSTEMFIELDS + __NENTITYFIELDS;

            // Entity System fields
            __entitytypehash = ENTITY_TYPE;
            __created = DateTime.UtcNow.Ticks;
            __modified = 0;
            __changeindex = 0;

            // Entity Data fields
            _id = id;
            _username = username;
            _passphrase = passphrase;
        }

        private EntitySerialization01.EntityState OnChangeState(EntitySerialization01.EntityState newState)
        {
            EntitySerialization01.EntityState prevState = ___entitystate;
            OnChangeFieldValue(EntitySerialization01.FieldIndices.HEADERFIELDS, newState);
            return prevState;
        }

        private EntitySerialization01.EntityState OnChangeFieldValue(EntitySerialization01.FieldIndices eField, EntitySerialization01.EntityState newState = EntitySerialization01.EntityState.SET)
        {
            EntitySerialization01.EntityState prevState = ___entitystate;
            if (newState != EntitySerialization01.EntityState.DONTCHANGESTATE) ___entitystate = newState;
            __modified = DateTime.UtcNow.Ticks;
            __changeindex++;
            return prevState;
        }

        private EntitySerialization01.EntityState OnChangeAllFieldValues(EntitySerialization01.EntityState newState = EntitySerialization01.EntityState.SET)
        {
            EntitySerialization01.EntityState prevState = ___entitystate;
            for (int fi = (int)EntitySerialization01.FieldIndices.HEADERFIELDS; fi < ___nfields; fi++)
                OnChangeFieldValue((EntitySerialization01.FieldIndices)fi, newState);
            return prevState;
        }

        public static UserLedgerEntry01 New()
        {
            UserLedgerEntry01 e = new UserLedgerEntry01();
            e.Initialize();
            return e;
        }

        private void Initialize()
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization01.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization01.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization01.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization01.EntityState.INITIALIZED;
            ___nfields = EntitySerialization01.NSYSTEMFIELDS + __NENTITYFIELDS;

            // Entity System fields
            __entitytypehash = ENTITY_TYPE;
            __created = DateTime.UtcNow.Ticks;
            __modified = 0;
            __changeindex = 0;

            // Entity Data fields
            _id = 0;
            _username = String.Empty;
            _passphrase = String.Empty;
        }

        public void Set(int id, string username, string passphrase)
        {
            if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize();

            _id = id;
            _username = username;
            _passphrase = passphrase;

            for (int fi = (int)EntitySerialization01.FieldIndices.ENTITYFIELD0; fi < (int)EntitySerialization01.FieldIndices.ENTITYFIELD0 + __NENTITYFIELDS; fi++)
                OnChangeFieldValue((EntitySerialization01.FieldIndices)fi, EntitySerialization01.EntityState.SET);
        }

        public bool IsNull() => (___entitystate == EntitySerialization01.EntityState.NULL);
        public bool IsInitialized() => (___entitystate == EntitySerialization01.EntityState.INITIALIZED);
        public bool IsSet() => (___entitystate == EntitySerialization01.EntityState.SET);
        public bool IsMissing() => (___entitystate == EntitySerialization01.EntityState.MISSING);

        public bool InErrorState() => (___entitystate == EntitySerialization01.EntityState.ERROR);
        public bool InExceptionState() => (InExceptionOnlyState() || InSerializationExceptionState() || InDeserializationExceptionState());
        public bool InExceptionOnlyState() => (___entitystate == EntitySerialization01.EntityState.EXCEPTION);
        public bool InSerializationExceptionState() => (___entitystate == EntitySerialization01.EntityState.EXCEPTION_SERIALIZATION);
        public bool InDeserializationExceptionState() => (___entitystate == EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION ||
                                                          ___entitystate == EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE ||
                                                          ___entitystate == EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION ||
                                                          ___entitystate == EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION);

        public byte[] Serialize()
        {
            if (___entitystate == EntitySerialization01.EntityState.UNINITIALIZED) Initialize();

            EntitySerialization01.EntityState oldState = OnChangeState(EntitySerialization01.EntityState.SERIALIZED);

            byte[][] fieldBuffer = new byte[this.___nfields][];

            // Entity System fields
            fieldBuffer[0] = FieldSerialization01.GetFieldBuffer(this.__entitytypehash);
            fieldBuffer[1] = FieldSerialization01.GetFieldBuffer(this.__created);
            fieldBuffer[2] = FieldSerialization01.GetFieldBuffer(this.__modified);
            fieldBuffer[3] = FieldSerialization01.GetFieldBuffer(this.__changeindex);

            // Entity Data fields
            fieldBuffer[3] = FieldSerialization01.GetFieldBuffer(this._id);
            fieldBuffer[4] = FieldSerialization01.GetFieldBuffer(this._username);
            fieldBuffer[5] = FieldSerialization01.GetFieldBuffer(this._passphrase);

            int lBuffer = EntitySerialization01.NHEADERFIELDS * sizeof(byte);
            for (int fi = 0; fi < ___nfields; fi++) lBuffer += fieldBuffer[fi].Length; // Entity System fields plus Entity data fields

            byte[] buffer = new byte[lBuffer];
            int bufferBase = 0;

            // Entity Header fields
            buffer[bufferBase++] = ___entityserializationsignature;
            buffer[bufferBase++] = ___entityserializationversion;
            buffer[bufferBase++] = ___fieldserializationversion;
            buffer[bufferBase++] = (byte)___entitystate;
            buffer[bufferBase++] = ___nfields;

            // Entity System fields plus Entity data fields
            for (int fi = 0; fi < ___nfields; fi++)
            {
                if (bufferBase + fieldBuffer[fi].Length > lBuffer)
                {
                    OnChangeState(EntitySerialization01.EntityState.EXCEPTION_SERIALIZATION);
                    return Array.Empty<byte>();
                }
                fieldBuffer[fi].CopyTo(buffer, bufferBase);
                bufferBase += fieldBuffer[fi].Length;
            }

            ___entitystate = oldState;

            return buffer;
        }

        public static UserLedgerEntry01 Deserialize(byte[] buffer)
        {
            UserLedgerEntry01 e = UserLedgerEntry01.New();

            int bufferBase = 0;

            // Entity Header fields
            e.___entityserializationsignature = buffer[bufferBase++];
            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            e.___entityserializationversion = buffer[bufferBase++];
            if (!e.CheckEntitySerializationVersion()) { e.OnChangeState(EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            e.___fieldserializationversion = buffer[bufferBase++];
            if (!e.CheckFieldSerializationVersion()) { e.OnChangeState(EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }


            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            if (!e.CheckEntitySerializationVersion())   { e.OnChangeState(EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            if (!e.CheckFieldSerializationVersion())    { e.OnChangeState(EntitySerialization01.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }

            e.___entitystate = (EntitySerialization01.EntityState)buffer[bufferBase++];
            e.___nfields = buffer[bufferBase++];

            // Entity System fields
            e.__entitytypehash = FieldSerialization01.GetByteArray(buffer, ref bufferBase);
            e.__created = FieldSerialization01.GetInt64(buffer, ref bufferBase);
            e.__modified = FieldSerialization01.GetInt64(buffer, ref bufferBase);
            e.__changeindex = FieldSerialization01.GetInt64(buffer, ref bufferBase);

            // Entity Data fields
            e._id = FieldSerialization01.GetInt32(buffer, ref bufferBase);
            e._username = FieldSerialization01.GetString(buffer, ref bufferBase);
            e._passphrase = FieldSerialization01.GetString(buffer, ref bufferBase);

            e.OnChangeAllFieldValues(EntitySerialization01.EntityState.DESERIALIZED);

            return e;
        }

        public void Put(IPersistentState ctx, string key)
        {
            byte[] buffer = Serialize();
            ctx.SetByteArray(key, buffer);
        }

        public static UserLedgerEntry01 Get(IPersistentState ctx, string key)
        {
            UserLedgerEntry01 e;

            byte[] buffer = ctx.GetByteArray(key);
            if (buffer == Array.Empty<byte>())
            {
                e = new UserLedgerEntry01();
                e.Initialize();
                e.___entitystate = EntitySerialization01.EntityState.MISSING;
            }
            else
            {
                e = Deserialize(buffer);
            }

            return e;
        }
    }
}
