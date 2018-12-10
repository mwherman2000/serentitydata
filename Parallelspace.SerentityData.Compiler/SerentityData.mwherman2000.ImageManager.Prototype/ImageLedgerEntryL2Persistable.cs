using Parallelspace.SerentityData;
using Parallelspace.SerentityData.Ledgers;
using System;

/// <summary>
/// SerentityData.mwherman2000.ImageManager.Prototype - Level 2 Persistable 
///
/// Processed:       2018-03-19 11:02:51 PM by SerentityData Compiler (SDC) 3.0 v1.0.0.0
/// SDC Project:     https://github.com/mwherman2000/serentitydata/blob/master/README.md
/// SDC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace SerentityData.mwherman2000.ImageManager.Prototype
{
    public partial struct ImageLedgerEntry : IGenericLedgerEntry03L2Persistable<ImageLedgerEntry> /* Level 2 Persistable */
    {
        public byte[] Serialize()
        {
            int bufferBase;

            if (this.___entitystate == EntitySerialization03.EntityState.UNINITIALIZED) Initialize();

            EntitySerialization03.EntityState oldState = OnChangeStateOnly(EntitySerialization03.EntityState.SERIALIZED);

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

        public static ImageLedgerEntry Deserialize(byte[] buffer)
        {
            ImageLedgerEntry e = ImageLedgerEntry.New();

            int bufferBase = 0;

            // Entity Header fields
            e.___entityserializationsignature = buffer[bufferBase++];
            if (!e.CheckEntitySerializationSignature()) { e.OnChangeStateOnly(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYSIGNATURE); return e; }
            e.___entityserializationversion = buffer[bufferBase++];
            if (!e.CheckEntitySerializationVersion()) { e.OnChangeStateOnly(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_ENTITYVERSION); return e; }
            e.___fieldserializationversion = buffer[bufferBase++];
            if (!e.CheckFieldSerializationVersion()) { e.OnChangeStateOnly(EntitySerialization03.EntityState.EXCEPTION_DESERIALIZATION_FIELDVERSION); return e; }
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

        //public static ImageLedgerEntry Get(IPersistentState ctx, string key)
        //{
        //    ImageLedgerEntry e;

        //    byte[] buffer = ctx.GetByteArray(key);
        //    if (buffer == Array.Empty<byte>())
        //    {
        //        e = new ImageLedgerEntry();
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
