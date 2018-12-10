using Parallelspace.SerentityData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parallelspace.SerentityData.Ledgers
{
    public struct FileInfoLedgerEntry03 : IGenericLedgerEntry03<FileInfoLedgerEntry03>
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Ledgers" + "." + "FileInfoLedgerEntry03" + " " + "v0.3";
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
        private string _imageName;
        private byte[] _imageContent;

        // Blockchain data fields
        private const int __NBLOCKCHAINFIELDS = 5;
        private uint   __previousentityBlockindex;
        private string __previousentityTxhash;
        private byte[] __previousentityContentHash;
        private uint   __thisentityRecentBlockIndex; // an estimate
        private byte[] __thisentityContentHash; // Set in Serialize()


        public int ImageVersion
        {
            get { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return _imageVersion; }
            set { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); _imageVersion = value; OnChangeFieldValue(EntitySerialization03.FieldIndices.ENTITYFIELD0); }
        }
        public string ImageName
        {
            get { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return _imageName; }
            set { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); _imageName = value; OnChangeFieldValue(EntitySerialization03.FieldIndices.ENTITYFIELD1); }
        }
        public byte[] ImageContent
        {
            get { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return _imageContent; }
            set { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); _imageContent = value; OnChangeFieldValue(EntitySerialization03.FieldIndices.ENTITYFIELD2); }
        }

        public FileInfoLedgerEntry03(int imageversion, string imagename, byte[] imagecontent)
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization03.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization03.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization03.EntityState.INITIALIZED;
            ___nfields = EntitySerialization03.NSYSTEMFIELDS + __NENTITYFIELDS + __NBLOCKCHAINFIELDS;

            // Entity System fields
            __entitytypehash = ENTITY_TYPE;
            __created = DateTime.UtcNow.Ticks;
            __modified = 0;
            __changeindex = 0;

            // Entity Data fields
            _imageVersion = imageversion;
            _imageName = imagename;
            _imageContent = imagecontent;

            // Blockchain data fields
            __previousentityBlockindex = 0;
            __previousentityTxhash = EntitySerialization03.TX_ZEROS_HASH_HEX;
            __previousentityContentHash = EntitySerialization03.SHA256_DUMMY_HASH;
            __thisentityRecentBlockIndex = 0;
            __thisentityContentHash = EntitySerialization03.SHA256_DUMMY_HASH; // Set in Serialize()
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

        public static FileInfoLedgerEntry03 New()
        {
            FileInfoLedgerEntry03 e = new FileInfoLedgerEntry03();
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
            ___nfields = EntitySerialization03.NSYSTEMFIELDS + __NENTITYFIELDS + __NBLOCKCHAINFIELDS;

            // Entity System fields
            __entitytypehash = ENTITY_TYPE;
            __created = DateTime.UtcNow.Ticks;
            __modified = 0;
            __changeindex = 0;

            // Entity Data fields
            _imageVersion = 0;
            _imageName = String.Empty;
            _imageContent = Array.Empty<byte>();

            // Blockchain data fields
            __previousentityBlockindex = 0;
            __previousentityTxhash = EntitySerialization03.TX_ZEROS_HASH_HEX;
            __previousentityContentHash = EntitySerialization03.SHA256_DUMMY_HASH;
            __thisentityRecentBlockIndex = 0;
            __thisentityContentHash = EntitySerialization03.SHA256_DUMMY_HASH; // Set in Serialize()
        }

        public void Set(FileSystemInfo fsi)
        {
            // TODO
        }

        public void Set(int imageversion, string imagename, byte[] imagecontent)
        {
            if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();

            // Entity Data fields
            _imageVersion = imageversion;
            _imageName = imagename;
            _imageContent = imagecontent;

            for (int fi = (int)EntitySerialization03.FieldIndices.ENTITYFIELD0; fi < (int)EntitySerialization03.FieldIndices.ENTITYFIELD0 + __NENTITYFIELDS; fi++)
                OnChangeFieldValue((EntitySerialization03.FieldIndices)fi, EntitySerialization03.EntityState.SET);
        }

        public void SetBlockchainFields(FileInfoLedgerEntry03 previousEntity, uint thisentityRecentBlockIndex)
        {
            SetBlockchainFields(previousEntity.__previousentityBlockindex, previousEntity.__previousentityTxhash, previousEntity.__previousentityContentHash, thisentityRecentBlockIndex);
        }

        public void SetBlockchainFields( uint previousentityBlockindex, string previousentityTxhash, byte[] previousentityContentHash, uint thisentityRecentBlockIndex)
        {
            // Blockchain data fields
            __previousentityBlockindex = previousentityBlockindex;
            __previousentityTxhash = previousentityTxhash;
            __previousentityContentHash = previousentityContentHash;
            __thisentityRecentBlockIndex = thisentityRecentBlockIndex;
            __thisentityContentHash = EntitySerialization03.SHA256_DUMMY_HASH; // Set in Serialize()
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
        public bool InExceptionState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION ||
                                           InSerializationExceptionState() ||
                                           InDeserializationExceptionState());
        public bool InSerializationExceptionState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION_SERIALIZATION);
        public bool InDeserializationExceptionState() => (___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION ||
                                                          ___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE ||
                                                          ___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION ||
                                                          ___entitystate == EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION);

        public byte[] Serialize()
        {
            int fieldBufferBase;

            if (this.___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();

            EntitySerialization03.EntityState oldState = OnChangeState(EntitySerialization03.EntityState.SERIALIZED);

            byte[][] fieldBuffer = new byte[this.___nfields][];
            fieldBufferBase = 0;

            // Entity System fields
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__entitytypehash); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__created); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__modified); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__changeindex); fieldBufferBase++;

            // Entity Data fields
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this._imageVersion); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this._imageName); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this._imageContent); fieldBufferBase++;

            // Blockchain data fields
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__previousentityBlockindex); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__previousentityTxhash, false); fieldBufferBase++; // FieldEncoding.ASCIIString
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__previousentityContentHash); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__thisentityRecentBlockIndex); fieldBufferBase++;
            fieldBuffer[fieldBufferBase] = FieldSerialization03.Serialize(this.__thisentityContentHash); fieldBufferBase++;

            int lBuffer = EntitySerialization03.NHEADERFIELDS * sizeof(byte);
            for (int fi = 0; fi < this.___nfields; fi++) lBuffer += fieldBuffer[fi].Length; // System + Entity + Blockchain data fields

            byte[] buffer = new byte[lBuffer];
            fieldBufferBase = 0;

            // Entity Header fields
            buffer[fieldBufferBase++] = this.___entityserializationsignature;
            buffer[fieldBufferBase++] = this.___entityserializationversion;
            buffer[fieldBufferBase++] = this.___fieldserializationversion;
            buffer[fieldBufferBase++] = (byte)this.___entitystate;
            buffer[fieldBufferBase++] = this.___nfields;

            // System + Entity + Blockchain data fields - copy all fields except __thisentityContentHash
            for (int fi = 0; fi < this.___nfields -1; fi++)
            {
                if (fieldBufferBase + fieldBuffer[fi].Length > lBuffer)
                {
                    OnChangeState(EntitySerialization03.EntityState.EXCEPTION_SERIALIZATION);
                    return Array.Empty<byte>();
                }

                fieldBuffer[fi].CopyTo(buffer, fieldBufferBase);
                fieldBufferBase += fieldBuffer[fi].Length;
            }

            // Set __thisentityContentHash and encode it into the buffer
            using (SHA256 SHA256Factory = SHA256.Create())
            {
                __thisentityContentHash = SHA256Factory.ComputeHash(buffer, 0, fieldBufferBase);
                fieldBuffer[this.___nfields -1].CopyTo(buffer, fieldBufferBase);
                fieldBufferBase += fieldBuffer[this.___nfields - 1].Length;
            }

            this.___entitystate = oldState;

            return buffer;
        }

        public static FileInfoLedgerEntry03 Deserialize(byte[] buffer)
        {
            FileInfoLedgerEntry03 e = FileInfoLedgerEntry03.New();

            int fieldBufferBase = 0;

            // Entity Header fields
            e.___entityserializationsignature = buffer[fieldBufferBase++];
            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            e.___entityserializationversion = buffer[fieldBufferBase++];
            if (!e.CheckEntitySerializationVersion()) { e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            e.___fieldserializationversion = buffer[fieldBufferBase++];
            if (!e.CheckFieldSerializationVersion())    { e.OnChangeState(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }

            e.___entitystate = (EntitySerialization03.EntityState)buffer[fieldBufferBase++];
            e.___nfields = buffer[fieldBufferBase++];

            // Entity System fields
            e.__entitytypehash = FieldSerialization03.DeserializeByteArray(buffer, ref fieldBufferBase);
            e.__created = FieldSerialization03.DeserializeInt64(buffer, ref fieldBufferBase);
            e.__modified = FieldSerialization03.DeserializeInt64(buffer, ref fieldBufferBase);
            e.__changeindex = FieldSerialization03.DeserializeInt64(buffer, ref fieldBufferBase);

            // Entity Data fields
            e._imageVersion = FieldSerialization03.DeserializeInt32(buffer, ref fieldBufferBase);
            e._imageName = FieldSerialization03.DeserializeString(buffer, ref fieldBufferBase);
            e._imageContent = FieldSerialization03.DeserializeByteArray(buffer, ref fieldBufferBase);

            e.OnChangeAllFieldValues(EntitySerialization03.EntityState.DESERIALIZED);

            return e;
        }

        public void Put(IPersistentState ctx, string key)
        {
            byte[] buffer = Serialize();
            ctx.SetByteArray(key, buffer);
        }

        public static FileInfoLedgerEntry03 Get(IPersistentState ctx, string key)
        {
            FileInfoLedgerEntry03 e;

            byte[] buffer = ctx.GetByteArray(key);
            if (buffer == Array.Empty<byte>())
            {
                e = new FileInfoLedgerEntry03();
                e.Initialize();
                e.OnChangeState(EntitySerialization03.EntityState.MISSING);
            }
            else
            {
                e = Deserialize(buffer);
            }

            return e;
        }
    }
}
