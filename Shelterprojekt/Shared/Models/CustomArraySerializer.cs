using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Shelterprojekt.Shared.Models
{
    class CustomArraySerializer : SerializerBase<Coordinates>
    {
        public override Coordinates Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            context.Reader.ReadStartArray();
            var lon = context.Reader.ReadDouble();
            var lat = context.Reader.ReadDouble();
            context.Reader.ReadEndArray();
            context.Reader.ReadEndArray();

            return new Coordinates() { Long = (double)lon, Lat = (double)lat };
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Coordinates value)
        {
            context.Writer.WriteStartArray();
            context.Writer.WriteStartArray();
            context.Writer.WriteDouble(value.Long);
            context.Writer.WriteDouble(value.Lat);
            context.Writer.WriteEndArray();
            context.Writer.WriteEndArray();
        }
    }
}
