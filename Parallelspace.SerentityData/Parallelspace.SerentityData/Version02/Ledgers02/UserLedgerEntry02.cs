using Parallelspace.SerentityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parallelspace.SerentityData.Ledgers
{
    public struct UserLedgerEntry02 : IGenericLedgerEntry02<UserLedgerEntry02>
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Ledgers" + "." + "UserLedgerEntry" + " " + "v0.2";
        //public static readonly byte[] ENTITY_TYPE = SHA256Managed.Create().ComputeHash(Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME));
        public static readonly byte[] ENTITY_TYPE = Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME);

        // Entity Header fields
        private byte ___entityserializationsignature;
        private byte ___entityserializationversion;
        private byte ___fieldserializationversion;
        private EntitySerialization02.EntityState ___entitystate;
        private byte ___nfields;

        public bool CheckEntitySerializationSignature() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationsignature == EntitySerialization02.ENTITYSERIALIZATION_SIGNATURE; }
        public bool CheckEntitySerializationVersion() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationversion == EntitySerialization02.ENTITYSERIALIZATION_VERSION; }
        public bool CheckFieldSerializationVersion() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return ___fieldserializationversion == FieldSerialization02.FIELDSERIALIZATION_VERSION; }

        // Entity System fields
        private byte[] __entitytypehash;
        private Int64 __created;
        private Int64 __modified;
        private Int64 __changeindex;

        public byte[] GetEntityTypeHash() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __entitytypehash; }
        public Int64 GetCreated() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __created; }
        public Int64 GetModified() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __modified; }
        public Int64 GetChangeIndex() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __changeindex; }

        // Entity Data fields
        private const int __NENTITYFIELDS = 3;
        private Int32 _id;
        private string _username;
        private string _passphrase;

        public int Id
        {
            get { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return _id; }
            set { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); _id = value; OnChangeFieldValue(EntitySerialization02.FieldIndices.ENTITYFIELD0); }
        }
        public string Username
        {
            get { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return _username; }
            set { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); _username = value; OnChangeFieldValue(EntitySerialization02.FieldIndices.ENTITYFIELD1); }
        }
        public string Passphrase
        {
            get { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return _passphrase; }
            set { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); _passphrase = value; OnChangeFieldValue(EntitySerialization02.FieldIndices.ENTITYFIELD2); }
        }

        public UserLedgerEntry02(int id, string username, string passphrase)
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization02.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization02.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization02.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization02.EntityState.INITIALIZED;
            ___nfields = EntitySerialization02.NSYSTEMFIELDS + __NENTITYFIELDS;

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

        private EntitySerialization02.EntityState OnChangeState(EntitySerialization02.EntityState newState)
        {
            EntitySerialization02.EntityState prevState = ___entitystate;
            OnChangeFieldValue(EntitySerialization02.FieldIndices.HEADERFIELDS, newState);
            return prevState;
        }

        private EntitySerialization02.EntityState OnChangeFieldValue(EntitySerialization02.FieldIndices eField, EntitySerialization02.EntityState newState = EntitySerialization02.EntityState.SET)
        {
            EntitySerialization02.EntityState prevState = ___entitystate;
            if (newState != EntitySerialization02.EntityState.DONTCHANGESTATE) ___entitystate = newState;
            __modified = DateTime.UtcNow.Ticks;
            __changeindex++;
            return prevState;
        }

        private EntitySerialization02.EntityState OnChangeAllFieldValues(EntitySerialization02.EntityState newState = EntitySerialization02.EntityState.SET)
        {
            EntitySerialization02.EntityState prevState = ___entitystate;
            for (int fi = (int)EntitySerialization02.FieldIndices.HEADERFIELDS; fi < ___nfields; fi++)
                OnChangeFieldValue((EntitySerialization02.FieldIndices)fi, newState);
            return prevState;
        }

        public static UserLedgerEntry02 New()
        {
            UserLedgerEntry02 e = new UserLedgerEntry02();
            e.Initialize();
            return e;
        }

        private void Initialize()
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization02.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization02.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization02.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization02.EntityState.INITIALIZED;
            ___nfields = EntitySerialization02.NSYSTEMFIELDS + __NENTITYFIELDS;

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
            if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize();

            _id = id;
            _username = username;
            _passphrase = passphrase;

            for (int fi = (int)EntitySerialization02.FieldIndices.ENTITYFIELD0; fi < (int)EntitySerialization02.FieldIndices.ENTITYFIELD0 + __NENTITYFIELDS; fi++)
                OnChangeFieldValue((EntitySerialization02.FieldIndices)fi, EntitySerialization02.EntityState.SET);
        }

        public bool IsNull() => (___entitystate == EntitySerialization02.EntityState.NULL);
        public bool IsInitialized() => (___entitystate == EntitySerialization02.EntityState.INITIALIZED);
        public bool IsSet() => (___entitystate == EntitySerialization02.EntityState.SET);
        public bool IsMissing() => (___entitystate == EntitySerialization02.EntityState.MISSING);

        public bool InErrorState() => (___entitystate == EntitySerialization02.EntityState.ERROR);
        public bool InExceptionState() => (InExceptionOnlyState() || InSerializationExceptionState() || InDeserializationExceptionState());
        public bool InExceptionOnlyState() => (___entitystate == EntitySerialization02.EntityState.EXCEPTION);
        public bool InSerializationExceptionState() => (___entitystate == EntitySerialization02.EntityState.EXCEPTION_SERIALIZATION);
        public bool InDeserializationExceptionState() => (___entitystate == EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION ||
                                                          ___entitystate == EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE ||
                                                          ___entitystate == EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION ||
                                                          ___entitystate == EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION);

        public byte[] Serialize()
        {
            if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize();

            EntitySerialization02.EntityState oldState = OnChangeState(EntitySerialization02.EntityState.SERIALIZED);

            byte[][] fieldBuffer = new byte[this.___nfields][];

            // Entity System fields
            fieldBuffer[0] = FieldSerialization02.GetFieldBuffer(this.__entitytypehash);
            fieldBuffer[1] = FieldSerialization02.GetFieldBuffer(this.__created);
            fieldBuffer[2] = FieldSerialization02.GetFieldBuffer(this.__modified);
            fieldBuffer[3] = FieldSerialization02.GetFieldBuffer(this.__changeindex);

            // Entity Data fields
            fieldBuffer[3] = FieldSerialization02.GetFieldBuffer(this._id);
            fieldBuffer[4] = FieldSerialization02.GetFieldBuffer(this._username);
            fieldBuffer[5] = FieldSerialization02.GetFieldBuffer(this._passphrase);

            int lBuffer = EntitySerialization02.NHEADERFIELDS * sizeof(byte);
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
                    OnChangeState(EntitySerialization02.EntityState.EXCEPTION_SERIALIZATION);
                    return Array.Empty<byte>();
                }
                fieldBuffer[fi].CopyTo(buffer, bufferBase);
                bufferBase += fieldBuffer[fi].Length;
            }

            ___entitystate = oldState;

            return buffer;
        }

        public static UserLedgerEntry02 Deserialize(byte[] buffer)
        {
            UserLedgerEntry02 e = UserLedgerEntry02.New();

            int bufferBase = 0;

            // Entity Header fields
            e.___entityserializationsignature = buffer[bufferBase++];
            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            e.___entityserializationversion = buffer[bufferBase++];
            if (!e.CheckEntitySerializationVersion()) { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            e.___fieldserializationversion = buffer[bufferBase++];
            if (!e.CheckFieldSerializationVersion()) { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }


            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            if (!e.CheckEntitySerializationVersion())   { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            if (!e.CheckFieldSerializationVersion())    { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }

            e.___entitystate = (EntitySerialization02.EntityState)buffer[bufferBase++];
            e.___nfields = buffer[bufferBase++];

            // Entity System fields
            e.__entitytypehash = FieldSerialization02.GetByteArray(buffer, ref bufferBase);
            e.__created = FieldSerialization02.GetInt64(buffer, ref bufferBase);
            e.__modified = FieldSerialization02.GetInt64(buffer, ref bufferBase);
            e.__changeindex = FieldSerialization02.GetInt64(buffer, ref bufferBase);

            // Entity Data fields
            e._id = FieldSerialization02.GetInt32(buffer, ref bufferBase);
            e._username = FieldSerialization02.GetString(buffer, ref bufferBase);
            e._passphrase = FieldSerialization02.GetString(buffer, ref bufferBase);

            e.OnChangeAllFieldValues(EntitySerialization02.EntityState.DESERIALIZED);

            return e;
        }

        public void Put(IPersistentState ctx, string key)
        {
            byte[] buffer = Serialize();
            ctx.SetByteArray(key, buffer);
        }

        public static UserLedgerEntry02 Get(IPersistentState ctx, string key)
        {
            UserLedgerEntry02 e;

            byte[] buffer = ctx.GetByteArray(key);
            if (buffer == Array.Empty<byte>())
            {
                e = new UserLedgerEntry02();
                e.Initialize();
                e.___entitystate = EntitySerialization02.EntityState.MISSING;
            }
            else
            {
                e = Deserialize(buffer);
            }

            return e;
        }
    }
}
