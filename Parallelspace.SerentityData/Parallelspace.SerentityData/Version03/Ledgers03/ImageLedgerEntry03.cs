using Parallelspace.SerentityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parallelspace.SerentityData.Ledgers
{
    public struct ImageLedgerEntry03 : IGenericLedgerEntry03<ImageLedgerEntry03>
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Ledgers" + "." + "ImageLedgerEntry03" + " " + "v0.3";
        public static readonly byte[] ENTITY_TYPE = SHA256Managed.Create().ComputeHash(Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME));

        // Entity Header fields
        private byte ___entityserializationsignature;
        private byte ___entityserializationversion;
        private byte ___fieldserializationversion;
        private EntitySerialization03.EntityState ___entitystate;
        private byte ___nfields;

        public byte[] GetEntityTypeHash() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __entitytypehash; }
        public bool CheckEntitySerializationSignature() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationsignature == EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE; }
        public bool CheckEntitySerializationVersion() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();   return ___entityserializationversion == EntitySerialization03.ENTITYSERIALIZATION_VERSION; }
        public bool CheckFieldSerializationVersion() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();    return ___fieldserializationversion == FieldSerialization03.FIELDSERIALIZATION_VERSION; }
        
        // Entity System fields
        private byte[] __entitytypehash;
        private Int64 __created;
        private Int64 __modified;
        private Int64 __changeindex;

        public Int64 GetCreated() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __created; }
        public Int64 GetModified() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __modified; }
        public Int64 GetChangeIndex() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __changeindex; }

        // Entity Data fields
        private const int __NENTITYFIELDS = 3;

        private Int32 _imageVersion;
        public int ImageVersion
        {
            get { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return _imageVersion; }
            set { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); _imageVersion = value; OnChangeFieldValue(EntitySerialization03.FieldIndices.ENTITYFIELD0); }
        }

        private string _imageName;
        public string ImageName
        {
            get { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return _imageName; }
            set { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); _imageName = value; OnChangeFieldValue(EntitySerialization03.FieldIndices.ENTITYFIELD1); }
        }

        private byte[] _imageContent;
        public byte[] ImageContent
        {
            get { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return _imageContent; }
            set { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); _imageContent = value; OnChangeFieldValue(EntitySerialization03.FieldIndices.ENTITYFIELD2); }
        }

        public ImageLedgerEntry03(int imageVersion, string imageName, byte[] imageContent)
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization03.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization03.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization03.EntityState.INITIALIZED;
            ___nfields = EntitySerialization03.NSYSTEMFIELDS + __NENTITYFIELDS;

            // Entity System fields
            __entitytypehash = ENTITY_TYPE;
            __created = DateTime.UtcNow.Ticks;
            __modified = 0;
            __changeindex = 0;

            // Entity Data fields
            _imageVersion = imageVersion;
            _imageName = imageName;
            _imageContent = imageContent;
        }

        private EntitySerialization03.EntityState OnChangeState(EntitySerialization03.EntityState newState)
        {
            EntitySerialization03.EntityState prevState = ___entitystate;
            OnChangeFieldValue(EntitySerialization03.FieldIndices.HEADERFIELDS, newState);
            return prevState;
        }

        private EntitySerialization03.EntityState OnChangeFieldValue(EntitySerialization03.FieldIndices eField, EntitySerialization03.EntityState newState = EntitySerialization03.EntityState.SET)
        {
            EntitySerialization03.EntityState prevState = ___entitystate;
            if (newState != EntitySerialization03.EntityState.DONTCHANGESTATE) ___entitystate = newState;
            __modified = DateTime.UtcNow.Ticks;
            __changeindex++;
            return prevState;
        }

        private EntitySerialization03.EntityState OnChangeAllFieldValues(EntitySerialization03.EntityState newState = EntitySerialization03.EntityState.SET)
        {
            EntitySerialization03.EntityState prevState = ___entitystate;
            for (int fi = (int)EntitySerialization03.FieldIndices.HEADERFIELDS; fi < ___nfields; fi++)
                OnChangeFieldValue((EntitySerialization03.FieldIndices)fi, newState);
            return prevState;
        }

        public static ImageLedgerEntry03 New()
        {
            ImageLedgerEntry03 e = new ImageLedgerEntry03();
            e.Initialize();
            return e;
        }

        private void Initialize()
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization03.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization03.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization03.EntityState.INITIALIZED;
            ___nfields = EntitySerialization03.NSYSTEMFIELDS + __NENTITYFIELDS;

            // Entity System fields
            __entitytypehash = ENTITY_TYPE;
            __created = DateTime.UtcNow.Ticks;
            __modified = 0;
            __changeindex = 0;

            // Entity Data fields
            _imageVersion = 0;
            _imageName = String.Empty;
            _imageContent = Array.Empty<byte>();
        }

        public void Set(int imageVersion, string imageName, byte[] imageContent)
        {
            if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();

            // Entity Data fields
            _imageVersion = imageVersion;
            _imageName = imageName;
            _imageContent = imageContent;

            for (int fi = (int)EntitySerialization03.FieldIndices.ENTITYFIELD0; fi < (int)EntitySerialization03.FieldIndices.ENTITYFIELD0 + __NENTITYFIELDS; fi++)
                OnChangeFieldValue((EntitySerialization03.FieldIndices)fi, EntitySerialization03.EntityState.SET);
        }

        public bool IsNull() => (___entitystate == EntitySerialization03.EntityState.NULL);
        public bool IsInitialized() => (___entitystate == EntitySerialization03.EntityState.INITIALIZED);
        public bool IsSet() => (___entitystate == EntitySerialization03.EntityState.SET);
        public bool IsMissing() => (___entitystate == EntitySerialization03.EntityState.MISSING);
        public bool IsSerialized() => (___entitystate == EntitySerialization03.EntityState.SERIALIZED);
        public bool IsDeserialized() => (___entitystate == EntitySerialization03.EntityState.DESERIALIZED);
        public bool IsBuried() => (___entitystate == EntitySerialization03.EntityState.TOMBSTONED);

        public bool InErrorState() => (___entitystate == EntitySerialization03.EntityState.ERROR);
        public bool InExceptionOnlyState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION);
        public bool InSerializationExceptionState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION_SERIALIZATION);
        public bool InExceptionState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION ||
                                           InSerializationExceptionState() || InDeserializationExceptionState());
        public bool InDeserializationExceptionState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION ||
                                                          ___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE ||
                                                          ___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION ||
                                                          ___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION);

        public byte[] Serialize()
        {
            int bufferBase;

            if (this.___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();

            EntitySerialization03.EntityState oldState = OnChangeState(EntitySerialization03.EntityState.SERIALIZED);

            byte[][] fieldBuffers = new byte[this.___nfields][];

            // Entity System fields
            bufferBase = 0;
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this.__entitytypehash); bufferBase++;
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this.__created); bufferBase++;
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this.__modified); bufferBase++;
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this.__changeindex); bufferBase++;

            // Entity Data fields
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this._imageVersion); bufferBase++;
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this._imageName); bufferBase++;
            fieldBuffers[bufferBase] = FieldSerialization03.Serialize(this._imageContent); bufferBase++;

            byte[] buffer = EntitySerialization03.SerializeFieldBuffers(fieldBuffers,
                                                                        this.___entityserializationsignature, this.___entityserializationversion, this.___fieldserializationversion,
                                                                        (byte)this.___entitystate, this.___nfields);
            this.___entitystate = oldState;

            return buffer;
        }

        public static ImageLedgerEntry03 Deserialize(byte[] buffer)
        {
            ImageLedgerEntry03 e = ImageLedgerEntry03.New();

            int bufferBase = 0;

            // Entity Header fields
            e.___entityserializationsignature = buffer[bufferBase++];
            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            e.___entityserializationversion = buffer[bufferBase++];
            if (!e.CheckEntitySerializationVersion()) { e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            e.___fieldserializationversion = buffer[bufferBase++];
            if (!e.CheckFieldSerializationVersion())    { e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }
            e.___entitystate = (EntitySerialization03.EntityState)buffer[bufferBase++];
            e.___nfields = buffer[bufferBase++];

            // Entity System fields
            e.__entitytypehash = FieldSerialization03.DeserializeByteArray(buffer, ref bufferBase);
            e.__created = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);
            e.__modified = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);
            e.__changeindex = FieldSerialization03.DeserializeInt64(buffer, ref bufferBase);

            // Entity Data fields
            e._imageVersion = FieldSerialization03.DeserializeInt32(buffer, ref bufferBase);
            e._imageName = FieldSerialization03.DeserializeString(buffer, ref bufferBase);
            e._imageContent = FieldSerialization03.DeserializeByteArray(buffer, ref bufferBase);

            e.OnChangeAllFieldValues(EntitySerialization03.EntityState.DESERIALIZED);

            return e;
        }

        //public void Put(IPersistentState ctx, string key)
        //{
        //    byte[] buffer = Serialize();
        //    ctx.SetByteArray(key, buffer);
        //}

        //public static ImageLedgerEntry03 Get(IPersistentState ctx, string key)
        //{
        //    ImageLedgerEntry03 e;

        //    byte[] buffer = ctx.GetByteArray(key);
        //    if (buffer == Array.Empty<byte>())
        //    {
        //        e = new ImageLedgerEntry03();
        //        e.Initialize();
        //        e.OnChangeState(EntitySerialization03.EntityState.MISSING);
        //    }
        //    else
        //    {
        //        e = Deserialize(buffer);
        //    }

        //    return e;
        //}
    }
}
