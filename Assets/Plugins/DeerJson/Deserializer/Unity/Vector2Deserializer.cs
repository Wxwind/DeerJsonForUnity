using System;
using DeerJson;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using UnityEngine;

namespace Plugins.DeerJson.Deserializer.Unity
{
    public class Vector2Deserializer : JsonDeserializer<Vector2>
    {
        public override Vector2 GetNullValue(DeserializeContext ctx)
        {
            return new Vector2();
        }

        public override Vector2 Deserialize(JsonParser p, DeserializeContext ctx)
        {
            float x = 0, y = 0;

            p.GetObjectStart();

            string name;

            while ((name = p.GetMemberName()) != null)
            {
                switch (name)
                {
                    case "x":
                        x = Convert.ToSingle(p.GetNumber());
                        break;
                    case "y":
                        y = Convert.ToSingle(p.GetNumber());
                        break;
                }
            }

            p.GetObjectEnd();

            return new Vector2(x, y);
        }
    }
}