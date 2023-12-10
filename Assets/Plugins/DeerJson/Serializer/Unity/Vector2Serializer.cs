using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class Vector2Serializer : JsonSerializer<Vector2>
    {
        public override void Serialize(Vector2 value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();
            
            gen.WriteMemberName("x");
            gen.WriteNumber(value.x);
            gen.WriteMemberName("y");
            gen.WriteNumber(value.y);
            
            gen.WriteObjectEnd();
        }
    }
}