using System;
using DeerJson;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using UnityEngine;

namespace Plugins.DeerJson.Deserializer.Unity
{
    public class Color32Deserializer : JsonDeserializer<Color32>
    {
        public override Color32 GetNullValue(DeserializeContext ctx)
        {
            return new Color32();
        }

        public override Color32 Deserialize(JsonParser p, DeserializeContext ctx)
        {
            float r = 0, g = 0, b = 0, a = 0;

            p.GetObjectStart();

            string name;

            while ((name = p.GetMemberName()) != null)
            {
                switch (name)
                {
                    case "r":
                        r = Convert.ToSingle(p.GetNumber());
                        break;
                    case "g":
                        g = Convert.ToSingle(p.GetNumber());
                        break;
                    case "b":
                        b = Convert.ToSingle(p.GetNumber());
                        break;
                    case "a":
                        a = Convert.ToSingle(p.GetNumber());
                        break;
                }
            }

            p.GetObjectEnd();

            return new Color(r, g, b, a);
        }
    }
}