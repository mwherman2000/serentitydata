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
    public struct FileInfoLedgerEntry02 : IGenericLedgerEntry02<FileInfoLedgerEntry02>
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Ledgers" + "." + "FileInfoLedgerEntry02" + " " + "v0.2";
        public static readonly byte[] ENTITY_TYPE = SHA256Managed.Create().ComputeHash(Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME));
        //public static readonly byte[] ENTITY_TYPE = Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME);

        // Entity Header fields
        private byte ___entityserializationsignature;
        private byte ___entityserializationversion;
        private byte ___fieldserializationversion;
        private EntitySerialization02.EntityState ___entitystate;
        private byte ___nfields;

        public byte[] GetEntityTypeHash() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __entitytypehash; }
        public bool CheckEntitySerializationSignature() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationsignature == EntitySerialization02.ENTITYSERIALIZATION_SIGNATURE; }
        public bool CheckEntitySerializationVersion() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize();   return ___entityserializationversion == EntitySerialization02.ENTITYSERIALIZATION_VERSION; }
        public bool CheckFieldSerializationVersion() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize();    return ___fieldserializationversion == FieldSerialization02.FIELDSERIALIZATION_VERSION; }
        
        // Entity System fields
        private byte[] __entitytypehash;
        private Int64 __created;
        private Int64 __modified;
        private Int64 __changeindex;

        public Int64 GetCreated() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __created; }
        public Int64 GetModified() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __modified; }
        public Int64 GetChangeIndex() { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return __changeindex; }

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
            get { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return _imageVersion; }
            set { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); _imageVersion = value; OnChangeFieldValue(EntitySerialization02.FieldIndices.ENTITYFIELD0); }
        }
        public string ImageName
        {
            get { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return _imageName; }
            set { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); _imageName = value; OnChangeFieldValue(EntitySerialization02.FieldIndices.ENTITYFIELD1); }
        }
        public byte[] ImageContent
        {
            get { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); return _imageContent; }
            set { if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize(); _imageContent = value; OnChangeFieldValue(EntitySerialization02.FieldIndices.ENTITYFIELD2); }
        }

        public FileInfoLedgerEntry02(int imageversion, string imagename, byte[] imagecontent)
        {
            // Entity Header fields
            ___entityserializationsignature = EntitySerialization02.ENTITYSERIALIZATION_SIGNATURE;
            ___entityserializationversion = EntitySerialization02.ENTITYSERIALIZATION_VERSION;
            ___fieldserializationversion = FieldSerialization02.FIELDSERIALIZATION_VERSION;
            ___entitystate = EntitySerialization02.EntityState.INITIALIZED;
            ___nfields = EntitySerialization02.NSYSTEMFIELDS + __NENTITYFIELDS + __NBLOCKCHAINFIELDS;

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
            __previousentityTxhash = EntitySerialization02.TX_ZEROS_HASH_HEX;
            __previousentityContentHash = EntitySerialization02.SHA256_DUMMY_HASH;
            __thisentityRecentBlockIndex = 0;
            __thisentityContentHash = EntitySerialization02.SHA256_DUMMY_HASH; // Set in Serialize()
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

        public static FileInfoLedgerEntry02 New()
        {
            FileInfoLedgerEntry02 e = new FileInfoLedgerEntry02();
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
            ___nfields = EntitySerialization02.NSYSTEMFIELDS + __NENTITYFIELDS + __NBLOCKCHAINFIELDS;

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
            __previousentityTxhash = EntitySerialization02.TX_ZEROS_HASH_HEX;
            __previousentityContentHash = EntitySerialization02.SHA256_DUMMY_HASH;
            __thisentityRecentBlockIndex = 0;
            __thisentityContentHash = EntitySerialization02.SHA256_DUMMY_HASH; // Set in Serialize()
        }

        public void Set(FileSystemInfo fsi)
        {
            // TODO
        }

        public void Set(int imageversion, string imagename, byte[] imagecontent)
        {
            if (___entitystate == EntitySerialization02.EntityState.UNINITIALIZED) Initialize();

            // Entity Data fields
            _imageVersion = imageversion;
            _imageName = imagename;
            _imageContent = imagecontent;

            for (int fi = (int)EntitySerialization02.FieldIndices.ENTITYFIELD0; fi < (int)EntitySerialization02.FieldIndices.ENTITYFIELD0 + __NENTITYFIELDS; fi++)
                OnChangeFieldValue((EntitySerialization02.FieldIndices)fi, EntitySerialization02.EntityState.SET);
        }

        public void SetBlockchainFields(FileInfoLedgerEntry02 previousEntity, uint thisentityRecentBlockIndex)
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
            __thisentityContentHash = EntitySerialization02.SHA256_DUMMY_HASH; // Set in Serialize()
        }

        public bool IsNull() => (___entitystate == EntitySerialization02.EntityState.NULL);
        public bool IsInitialized() => (___entitystate == EntitySerialization02.EntityState.INITIALIZED);
        public bool IsSet() => (___entitystate == EntitySerialization02.EntityState.SET);
        public bool IsMissing() => (___entitystate == EntitySerialization02.EntityState.MISSING);

        public bool InErrorState() => (___entitystate == EntitySerialization02.EntityState.ERROR);
        public bool InExceptionOnlyState() => (___entitystate == EntitySerialization02.EntityState.EXCEPTION);
        public bool InExceptionState() => (___entitystate == EntitySerialization02.EntityState.EXCEPTION ||
                                           InSerializationExceptionState() ||
                                           InDeserializationExceptionState());
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
            fieldBuffer[4] = FieldSerialization02.GetFieldBuffer(this._imageVersion);
            fieldBuffer[5] = FieldSerialization02.GetFieldBuffer(this._imageName);
            fieldBuffer[6] = FieldSerialization02.GetFieldBuffer(this._imageContent);

            // Blockchain data fields
            fieldBuffer[7] = FieldSerialization02.GetFieldBuffer(this.__previousentityBlockindex);
            fieldBuffer[8] = FieldSerialization02.GetFieldBuffer(this.__previousentityTxhash, false); // FieldEncoding.ASCIIString
            fieldBuffer[9] = FieldSerialization02.GetFieldBuffer(this.__previousentityContentHash);
            fieldBuffer[10] = FieldSerialization02.GetFieldBuffer(this.__thisentityRecentBlockIndex);
            fieldBuffer[11] = FieldSerialization02.GetFieldBuffer(this.__thisentityContentHash);

            int lBuffer = EntitySerialization02.NHEADERFIELDS * sizeof(byte);
            for (int fi = 0; fi < ___nfields; fi++) lBuffer += fieldBuffer[fi].Length; // System + Entity + Blockchain data fields

            byte[] buffer = new byte[lBuffer];
            int fieldBufferBase = 0;

            // Entity Header fields
            buffer[fieldBufferBase++] = ___entityserializationsignature;
            buffer[fieldBufferBase++] = ___entityserializationversion;
            buffer[fieldBufferBase++] = ___fieldserializationversion;
            buffer[fieldBufferBase++] = (byte)___entitystate;
            buffer[fieldBufferBase++] = ___nfields;

            // System + Entity + Blockchain data fields - copy all fields except __thisentityContentHash
            for (int fi = 0; fi < ___nfields-1; fi++)
            {
                if (fieldBufferBase + fieldBuffer[fi].Length > lBuffer)
                {
                    OnChangeState(EntitySerialization02.EntityState.EXCEPTION_SERIALIZATION);
                    return Array.Empty<byte>();
                }

                fieldBuffer[fi].CopyTo(buffer, fieldBufferBase);
                fieldBufferBase += fieldBuffer[fi].Length;
            }

            // Set __thisentityContentHash and encode it into the buffer
            using (SHA256 SHA256Factory = SHA256.Create())
            {
                __thisentityContentHash = SHA256Factory.ComputeHash(buffer, 0, fieldBufferBase);
                fieldBuffer[___nfields-1].CopyTo(buffer, fieldBufferBase);
                fieldBufferBase += fieldBuffer[___nfields - 1].Length;
            }

            ___entitystate = oldState;

            return buffer;
        }

        public static FileInfoLedgerEntry02 Deserialize(byte[] buffer)
        {
            FileInfoLedgerEntry02 e = FileInfoLedgerEntry02.New();

            int fieldBufferBase = 0;

            // Entity Header fields
            e.___entityserializationsignature = buffer[fieldBufferBase++];
            if (!e.CheckEntitySerializationSignature()) { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            e.___entityserializationversion = buffer[fieldBufferBase++];
            if (!e.CheckEntitySerializationVersion()) { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            e.___fieldserializationversion = buffer[fieldBufferBase++];
            if (!e.CheckFieldSerializationVersion())    { e.OnChangeState(EntitySerialization02.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }

            e.___entitystate = (EntitySerialization02.EntityState)buffer[fieldBufferBase++];
            e.___nfields = buffer[fieldBufferBase++];

            // Entity System fields
            e.__entitytypehash = FieldSerialization02.GetByteArray(buffer, ref fieldBufferBase);
            e.__created = FieldSerialization02.GetInt64(buffer, ref fieldBufferBase);
            e.__modified = FieldSerialization02.GetInt64(buffer, ref fieldBufferBase);
            e.__changeindex = FieldSerialization02.GetInt64(buffer, ref fieldBufferBase);

            // Entity Data fields
            e._imageVersion = FieldSerialization02.GetInt32(buffer, ref fieldBufferBase);
            e._imageName = FieldSerialization02.GetString(buffer, ref fieldBufferBase);
            e._imageContent = FieldSerialization02.GetByteArray(buffer, ref fieldBufferBase);

            e.OnChangeAllFieldValues(EntitySerialization02.EntityState.DESERIALIZED);

            return e;
        }

        public void Put(IPersistentState ctx, string key)
        {
            byte[] buffer = Serialize();
            ctx.SetByteArray(key, buffer);
        }

        public static FileInfoLedgerEntry02 Get(IPersistentState ctx, string key)
        {
            FileInfoLedgerEntry02 e;

            byte[] buffer = ctx.GetByteArray(key);
            if (buffer == Array.Empty<byte>())
            {
                e = new FileInfoLedgerEntry02();
                e.Initialize();
                e.OnChangeState(EntitySerialization02.EntityState.MISSING);
            }
            else
            {
                e = Deserialize(buffer);
            }

            return e;
        }
    }
}
