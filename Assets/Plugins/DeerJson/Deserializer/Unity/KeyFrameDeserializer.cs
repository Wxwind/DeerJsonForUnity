using System;
using DeerJson;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using UnityEngine;

namespace Plugins.DeerJson.Deserializer.Unity
{
    public class KeyFrameDeserializer : JsonDeserializer<Keyframe>
    {
        public override Keyframe GetNullValue(DeserializeContext ctx)
        {
            return new Keyframe();
        }

        public override Keyframe Deserialize(JsonParser p, DeserializeContext ctx)
        {
            float time = 0, value = 0, inTangent = 0, outTangent = 0, inWeight = 0, outWeight = 0;

            p.GetObjectStart();

            string name;

            while ((name = p.GetMemberName()) != null)
            {
                switch (name)
                {
                    case "time":
                        time = Convert.ToSingle(p.GetNumber());
                        break;
                    case "value":
                        value = Convert.ToSingle(p.GetNumber());
                        break;
                    case "inTangent":
                        inTangent = Convert.ToSingle(p.GetNumber());
                        break;
                    case "outTangent":
                        outTangent = Convert.ToSingle(p.GetNumber());
                        break;
                    case "inWeight":
                        inWeight = Convert.ToSingle(p.GetNumber());
                        break;
                    case "outWeight":
                        outWeight = Convert.ToSingle(p.GetNumber());
                        break;
                }
            }

            p.GetObjectEnd();

            return new Keyframe(time, value, inTangent, outTangent, inWeight, outWeight);
        }
    }
}