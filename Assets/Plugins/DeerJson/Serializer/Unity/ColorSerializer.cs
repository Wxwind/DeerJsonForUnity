using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class ColorSerializer : JsonSerializer<Color>
    {
        public override void Serialize(Color value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();

            gen.WriteMemberName("r");
            gen.WriteNumber(value.r);
            gen.WriteMemberName("g");
            gen.WriteNumber(value.g);
            gen.WriteMemberName("b");
            gen.WriteNumber(value.b);
            gen.WriteMemberName("a");
            gen.WriteNumber(value.a);

            gen.WriteObjectEnd();
        }
    }
}