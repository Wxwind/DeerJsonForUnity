using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class Vector3Serializer : JsonSerializer<Vector3>
    {
        public override void Serialize(Vector3 value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();

            gen.WriteMemberName("x");
            gen.WriteNumber(value.x);
            gen.WriteMemberName("y");
            gen.WriteNumber(value.y);
            gen.WriteMemberName("z");
            gen.WriteNumber(value.z);

            gen.WriteObjectEnd();
        }
    }
}