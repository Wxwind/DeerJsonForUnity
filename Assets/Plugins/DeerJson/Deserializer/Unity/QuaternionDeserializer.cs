using System;
using DeerJson;
using DeerJson.Deserializer;
using DeerJson.Deserializer.std;
using UnityEngine;

namespace Plugins.DeerJson.Deserializer.Unity
{
    public class QuaternionDeserializer : JsonDeserializer<Quaternion>
    {
        public override Quaternion GetNullValue(DeserializeContext ctx)
        {
            return new Quaternion();
        }

        public override Quaternion Deserialize(JsonParser p, DeserializeContext ctx)
        {
            float x = 0, y = 0, z = 0, w = 0;

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
                    case "z":
                        z = Convert.ToSingle(p.GetNumber());
                        break;
                    case "w":
                        w = Convert.ToSingle(p.GetNumber());
                        break;
                }
            }

            p.GetObjectEnd();

            return new Quaternion(x, y, z, w);
        }
    }
}