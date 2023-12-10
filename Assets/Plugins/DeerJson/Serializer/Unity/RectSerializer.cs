using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class RectSerializer : JsonSerializer<Rect>
    {
        public override void Serialize(Rect value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();

            gen.WriteMemberName("x");
            gen.WriteNumber(value.x);
            gen.WriteMemberName("y");
            gen.WriteNumber(value.y);
            gen.WriteMemberName("width");
            gen.WriteNumber(value.width);
            gen.WriteMemberName("height");
            gen.WriteNumber(value.height);

            gen.WriteObjectEnd();
        }
    }
}