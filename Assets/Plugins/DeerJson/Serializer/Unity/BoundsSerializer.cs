using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class BoundsSerializer : JsonSerializer<Bounds>
    {
        public override void Serialize(Bounds value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();

            gen.WriteMemberName("center");
            gen.WriteObjectStart();

            gen.WriteMemberName("x");
            gen.WriteNumber(value.center.x);
            gen.WriteMemberName("y");
            gen.WriteNumber(value.center.y);
            gen.WriteMemberName("z");
            gen.WriteNumber(value.center.z);

            gen.WriteObjectEnd();

            gen.WriteMemberName("size");
            gen.WriteObjectStart();

            gen.WriteMemberName("x");
            gen.WriteNumber(value.size.x);
            gen.WriteMemberName("y");
            gen.WriteNumber(value.size.y);
            gen.WriteMemberName("z");
            gen.WriteNumber(value.size.z);

            gen.WriteObjectEnd();

            gen.WriteObjectEnd();
        }
    }
}