using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{

    public interface IBall : IDisposable
    {
        int  Id { get; }
        int Diameter { get; }

        [JsonConverter(typeof(Vector2Converter))]
        Vector2 Position { get; }
        [JsonConverter(typeof(Vector2Converter))]
        Vector2 Velocity { get; set; }

        int Mass { get; }

        event EventHandler? BallChanged;

    
    }
    internal class Vector2Converter : JsonConverter<Vector2>
    {
        public override Vector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Vector2 value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("X", value.X);
            writer.WriteNumber("Y", value.Y);
            writer.WriteEndObject();
        }
    }
}
