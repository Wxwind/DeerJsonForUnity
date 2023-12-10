using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class Vector4Serializer : JsonSerializer<Vector4>
    {
        public override void Serialize(Vector4 value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();

            gen.WriteMemberName("x");
            gen.WriteNumber(value.x);
            gen.WriteMemberName("y");
            gen.WriteNumber(value.y);
            gen.WriteMemberName("z");
            gen.WriteNumber(value.z);
            gen.WriteMemberName("w");
            gen.WriteNumber(value.w);

            gen.WriteObjectEnd();
        }
    }
}