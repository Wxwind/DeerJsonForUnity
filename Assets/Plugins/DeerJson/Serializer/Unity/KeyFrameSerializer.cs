using UnityEngine;

namespace DeerJson.Serializer.Unity
{
    public class KeyFrameSerializer : JsonSerializer<Keyframe>
    {
        public override void Serialize(Keyframe value, JsonGenerator gen, SerializeContext ctx)
        {
            gen.WriteObjectStart();

            gen.WriteMemberName("time");
            gen.WriteNumber(value.time);
            gen.WriteMemberName("value");
            gen.WriteNumber(value.value);
            gen.WriteMemberName("inTangent");
            gen.WriteNumber(value.inTangent);
            gen.WriteMemberName("outTangent");
            gen.WriteNumber(value.outTangent);
            gen.WriteMemberName("inWeight");
            gen.WriteNumber(value.inWeight);
            gen.WriteMemberName("outWeight");
            gen.WriteNumber(value.outWeight);

            gen.WriteObjectEnd();
        }
    }
}