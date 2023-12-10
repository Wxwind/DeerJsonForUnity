using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class Color32Serializer : JsonSerializer<Color32>
    {
        public override void Serialize(Color32 value, JsonGenerator gen, SerializeContext ctx)
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