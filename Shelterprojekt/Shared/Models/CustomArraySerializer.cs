using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Shelterprojekt.Shared.Models
{
    //class CustomArraySerializer: SerializerBase<Coordinates>
    //{
    //    public override Coordinates Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    //    {
    //        context.Reader.ReadStartArray();
    //        var lat = context.Reader.ReadDouble();
    //        var lon = context.Reader.ReadDouble();
    //        context.Reader.ReadEndArray();

    //        return new Coordinates() { Long = (float)lon, Lat = (float)lat };
    //    }

    //    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Coordinates value)
    //    {
    //        context.Writer.WriteStartArray();
    //        context.Writer.WriteDouble(value.Lat);
    //        context.Writer.WriteDouble(value.Long);
    //        context.Writer.WriteEndArray();
    //    }
    //}
}
