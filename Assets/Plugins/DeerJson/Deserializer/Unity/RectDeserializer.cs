using System;
using DeerJson;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using UnityEngine;

namespace Plugins.DeerJson.Deserializer.Unity
{
    public class RectDeserializer : JsonDeserializer<Rect>
    {
        public override Rect GetNullValue(DeserializeContext ctx)
        {
            return new Rect();
        }

        public override Rect Deserialize(JsonParser p, DeserializeContext ctx)
        {
            float x = 0, y = 0, width = 0, height = 0;

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
                    case "width":
                        width = Convert.ToSingle(p.GetNumber());
                        break;
                    case "height":
                        height = Convert.ToSingle(p.GetNumber());
                        break;
                }
            }

            p.GetObjectEnd();

            return new Rect(x, y, width, height);
        }
    }
}