using Parallelspace.SerentityData;
using Parallelspace.SerentityData.Ledgers;
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// SerentityData.mwherman2000.ImageManager.Prototype - Level 1 Managed
///
/// Processed:       2018-03-19 11:02:51 PM by SerentityData Compiler (SDC) 3.0 v1.0.0.0
/// SDC Project:     https://github.com/mwherman2000/serentitydata/blob/master/README.md
/// SDC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace SerentityData.mwherman2000.ImageManager.Prototype
{
    public partial struct ImageLedgerEntry : IGenericLedgerEntry03L1Managed<ImageLedgerEntry> /* Level 1 Managed */
    {
        public static readonly string ENTITY_TYPE_NAME = "Parallelspace.SerentityData.Ledgers" + "." + "ImageLedgerEntry" + " " + "v0.3";
        public static readonly byte[] ENTITY_TYPE = SHA256Managed.Create().ComputeHash(Encoding.ASCII.GetBytes(ENTITY_TYPE_NAME));

        // Entity Header fields
        private byte ___entityserializationsignature;
        private byte ___entityserializationversion;
        private byte ___fieldserializationversion;
        private EntitySerialization03.EntityState ___entitystate;
        private byte ___nfields;

        public bool CheckEntitySerializationSignature() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationsignature == EntitySerialization03.ENTITYSERIALIZATION_SIGNATURE; }
        public bool CheckEntitySerializationVersion() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return ___entityserializationversion == EntitySerialization03.ENTITYSERIALIZATION_VERSION; }
        public bool CheckFieldSerializationVersion() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return ___fieldserializationversion == FieldSerialization03.FIELDSERIALIZATION_VERSION; }

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

        // Entity System fields
        private byte[] __entitytypehash;
        private Int64 __created;
        private Int64 __modified;
        private Int64 __changeindex;

        public byte[] GetEntityTypeHash() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __entitytypehash; }
        public Int64  GetCreated() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __created; }
        public Int64  GetModified() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __modified; }
        public Int64  GetChangeIndex() { if (___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize(); return __changeindex; }

        // Entity Data fields
        private const int __NENTITYFIELDS = 3;
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

        public ImageLedgerEntry(int imageVersion, string imageName, byte[] imageContent)
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

        private EntitySerialization03.EntityState OnChangeStateOnly(EntitySerialization03.EntityState newState)
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

        public static ImageLedgerEntry New()
        {
            ImageLedgerEntry e = new ImageLedgerEntry();
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
    }
}
